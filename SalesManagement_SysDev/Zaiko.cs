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
                messageDsp.MessageBoxDsp("在庫情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
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


    }
}
