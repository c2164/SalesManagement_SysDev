using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Zaiko : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        public Zaiko()
        {
            InitializeComponent();
        }

        private void Zaiko_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("在庫情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            StockDataAccess access = new StockDataAccess();
            //在庫情報の全件取得
            List<DispStockDTO> tb = access.GetStockData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetDataGridView(List<DispStockDTO> tb)
        {
            dataGridView1.DataSource = tb;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー文字位置、セル文字位置、列幅の設定
            //在庫ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //商品ID(非表示)
            dataGridView1.Columns[1].Visible = false;
            //商品名
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].Width = 80;
            //メーカーID(非表示)
            dataGridView1.Columns[3].Visible = false;
            //メーカー名
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 80;
            //在庫数
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 50;
            //在庫管理フラグ(非表示)
            dataGridView1.Columns[6].Visible = false;
        }

        private void SetCtrlFormat()
        {
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();

            //各テキストボックスに初期化(空白)
            textBox_Zaiko_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDateAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;
            comboBox_Syouhin_Namae.DisplayMember = "PrName";
            comboBox_Syouhin_Namae.ValueMember = "PrID";
            comboBox_Syouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBox_Syouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syouhin_Namae.SelectedIndex = -1;

            //各ドメインアップダウンを初期化
            domainUpDown_Zaikosuu.Value = 0;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveStock();
        }

        private void RemoveStock()
        {
            //変数の宣言
            string StID;
            T_Stock stock = new T_Stock();
            //データグリッドビューで選択されているデータの在庫IDを受け取る
            StID = GetStockRecord();

            //取得した在庫IDでデータベースを検索する
            stock = SelectRemoveStock(StID);
            if (stock == null)
            {
                messageDsp.MessageBoxDsp_OK("在庫情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //在庫管理フラグを0から2にする
            UpdateStFlag(stock);
        }

        private void UpdateStFlag(T_Stock stock)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の在庫を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //在庫管理フラグの変更
            stock = ChangeStFlag(stock);
            //在庫の更新
            flg = UpdateStockRecord(stock);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象在庫を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象在庫の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateStockRecord(T_Stock stock)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            StockDataAccess access = new StockDataAccess();
            flg = access.UpdateStockData(stock);

            SetCtrlFormat();
            GetSelectData();

            return flg;

        }

        private T_Stock ChangeStFlag(T_Stock stock)
        {
            stock.StFlag = 2;
            return stock;
        }

        private T_Stock SelectRemoveStock(string stID)
        {
            //変数の宣言
            T_Stock retstock = new T_Stock();
            DispStockDTO dispStockDTO = new DispStockDTO();
            List<DispStockDTO> dispStocks = new List<DispStockDTO>();
            //データベースからデータを取得する
            dispStocks = GetTableData();
            if (dispStocks == null) //データの取得失敗
            {
                return null;
            }

            //Listの中を受け取った在庫IDで検索
            dispStockDTO = dispStocks.Single(x => x.StID == stID);

            //検索結果を返却用にする
            retstock = FormalizationStockInputRecord(dispStockDTO);

            return retstock;
        }

        private T_Stock FormalizationStockInputRecord(DispStockDTO dispStockDTO)
        {
            T_Stock retstock = new T_Stock();
            retstock.StID = int.Parse(dispStockDTO.StID);
            retstock.PrID = int.Parse(dispStockDTO.PrID);
            retstock.PrID = int.Parse(dispStockDTO.PrID);
            retstock.StQuantity = int.Parse(dispStockDTO.StQuantity);
            return retstock;
        }

        private string GetStockRecord()
        {
            //変数の宣言
            string retStID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retStID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retStID;
        }


        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayStock();
        }

        private void ListDisplayStock()
        {
            //変数の宣言
            List<DispStockDTO> stock = new List<DispStockDTO>();
            List<DispStockDTO> sortedstock = new List<DispStockDTO>();

            //テーブルデータ受け取り
            stock = GetTableData();

            //昇順に並び替える
            sortedstock = SortStockData(stock);

            //データグリッドビュー表示
            SetDataGridView(sortedstock);
        }

        private List<DispStockDTO> GetTableData()
        {
            //変数の宣言
            List<DispStockDTO> stock = new List<DispStockDTO>();

            //インスタンス化
            StockDataAccess StAccess = new StockDataAccess();

            //データベースからデータを取得
            stock = StAccess.GetStockData();


            return stock;
        }

        private List<DispStockDTO> SortStockData(List<DispStockDTO> dispStocks)
        {
            //並び替え(昇順)
            dispStocks.OrderBy(x => x.StID);
            return dispStocks;

        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectStock();
        }

        private void SelectStock()
        {
            //変数の宣言
            DispStockDTO stockDTO = new DispStockDTO();
            List<DispStockDTO> DisplayStock = new List<DispStockDTO>();

            //データの読み取り
            stockDTO = GetStockInf();
            //データの検索
            DisplayStock = SelectStockInf(stockDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayStock);
        }

        private DispStockDTO GetStockInf()
        {
            //変数の宣言
            DispStockDTO retStockDTO = new DispStockDTO();

            //各コントロールから在庫情報を読み取る
            retStockDTO.StID = textBox_Zaiko_ID.Text.Trim();
            if(!(comboBox_Meka_Namae.SelectedIndex == -1))
                retStockDTO.MaID= comboBox_Meka_Namae.SelectedValue.ToString();
            retStockDTO.MaName = comboBox_Meka_Namae.Text.Trim();
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retStockDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();
                retStockDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();
            retStockDTO.StQuantity = domainUpDown_Zaikosuu.Value.ToString();
            retStockDTO.StFlag = "0";

            return retStockDTO;
        }

        private List<DispStockDTO> SelectStockInf(DispStockDTO stockDTO)
        {
            //変数の宣言
            List<DispStockDTO> retDispStock = new List<DispStockDTO>();
            //インスタンス化
            StockDataAccess access = new StockDataAccess();

            //在庫情報検索
            retDispStock = access.GetStockData(stockDTO);
            return retDispStock;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Zaiko_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            domainUpDown_Zaikosuu.Value = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());
        }

        private void button_Kousin_Click(object sender, EventArgs e)
        {
            UpdateStock();
        }

        private void UpdateStock()
        {
            // 変数の宣言
            DispStockDTO dispStockDTO = new DispStockDTO();
            string StID;
            bool flg;
            //チェック済みの入力情報を得る
            dispStockDTO = GetCheckedStockInf();
            if(dispStockDTO == null)
            {
                return;
            }
            StID = GetStockRecord();
            if (StID == null)
            {
                return;
            }
            dispStockDTO.StID = StID;

            //存在チェック
            flg = ExistsCheck(dispStockDTO);
            if (!flg)
            {
                return;
            }
            //入力情報で在庫情報を更新する
            UpdateStockInf(dispStockDTO);
        }

        private void UpdateStockInf(DispStockDTO dispStockDTO)
        {
            //変数の宣言
            T_Stock UpStock = new T_Stock();
            bool flg;
            DialogResult result;

            //表示用データからテーブル用データに変換
            UpStock = FormalizationStockInputRecord(dispStockDTO);

            //更新確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の在庫を更新してもよろしいですか", "更新確認", MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                return;
            }

            //更新実行
            flg = UpdateStockRecord(UpStock);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象在庫を更新しました", "更新完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象在庫の更新に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool ExistsCheck(DispStockDTO checkDispStock)
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            bool flg;

            //存在チェック
            flg = ExistsCheckStockInputRecord(checkDispStock, out msg, out title, out icon);

            return flg;
        }

        private bool ExistsCheckStockInputRecord(DispStockDTO checkDispStock, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            List<DispStockDTO> dispStock = new List<DispStockDTO>();
            StockDataAccess access = new StockDataAccess();

            //テーブルのデータを取得
            dispStock = access.GetStockData();
            if(dispStock == null)
            {
                msg = "在庫情報が取得できんせんでした";
                title = "エラー";
                return false;
            }

            return true;
        }

        private DispStockDTO GetCheckedStockInf()
        {
           //変数の宣言
            DispStockDTO retDispStock = new DispStockDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //入力情報を取得
            retDispStock = GetStockInf();
            //入力チェック
            flg = CheckStockInf(retDispStock, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return retDispStock;
        }

        private bool CheckStockInf(DispStockDTO checkDispStock, out string msg, out string title, out MessageBoxIcon icon)
        {
            //インスタンス化
            DataInputFormCheck formCheck = new DataInputFormCheck();

            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //メーカー名のチェック
            if (comboBox_Meka_Namae.SelectedIndex == -1)
            {
                msg = "メーカーを選択してください";
                title = "入力エラー";
                return false;
            }

            //商品名のチェック
            if (String.IsNullOrEmpty(checkDispStock.PrName))
            {
                msg = "商品名は必須入力です";
                title = "入力エラー";
                return false;
            }

            //在庫数のチェック
            if (!String.IsNullOrEmpty(checkDispStock.StQuantity))
            {
                if (!formCheck.CheckNumeric(checkDispStock.StQuantity))
                {
                    msg = "安全在庫数には数字を入力してください";
                    title = "入力エラー";
                    return false;
                }

            }
            else
            {
                msg = "安全在庫数は必須入力です";
                title = "入力エラー";
                return false;
            }

            return true;
        }
    }
}
