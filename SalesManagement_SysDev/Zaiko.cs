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
            //メーカー名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //在庫数
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 50;
            //在庫管理フラグ(非表示)
            dataGridView1.Columns[5].Visible = false;
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

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の在庫を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //在庫管理フラグの変更
            stock = ChangeStFlag(stock);
            //在庫の更新
            UpdateStockRecord(stock);
        }

        private void UpdateStockRecord(T_Stock stock)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            StockDataAccess access = new StockDataAccess();
            flg = access.UpdateStockData(stock);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象在庫の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象在庫を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }

            SetCtrlFormat();
            GetSelectData();
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
            //dispStocks = GetTableData();
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

            return retstock;
        }

        private string GetStockRecord()
        {
            //変数の宣言
            string retStID;

            retStID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retStID;
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {

        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {

        }
    }
}
