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
    public partial class Nyuuko : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();

        public Nyuuko()
        {
            InitializeComponent();
        }

        private void Nyuuko_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("入庫情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            WarehousingDataAccess access = new WarehousingDataAccess();
            //入庫情報の全件取得
            List<DispWarehousingDTO> tb = access.GetWarehousingData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Hattyuu_ID.Text = "";
            textBox_Hattyuu_Syain_Namae.Text = "";
            textBox_Nyuukosyousai_ID.Text = "";
            textBox_Nyuuko_ID.Text = "";


            //各コンボボックスを初期化
            comboBox_Kakutei_Syain_Namae.DisplayMember = "SoName";
            comboBox_Kakutei_Syain_Namae.ValueMember = "SoID";
            comboBox_Kakutei_Syain_Namae.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Kakutei_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kakutei_Syain_Namae.SelectedIndex = -1;

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


            //数量の初期化
            numericUpDown_Suuryou.Value = 0;
        }

        private void SetDataGridView(List<DispWarehousingDTO> tb)
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
            //入庫ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;
            //入庫詳細ID
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 190;
            //メーカーID(非表示)
            dataGridView1.Columns[4].Visible = false;
            //メーカー名
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 80;
            //数量
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 55;
            //発注ID
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].Width = 80;
            //発注社員ID
            dataGridView1.Columns[8].Visible = false;
            //発注社員名
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 80;
            //確定社員ID
            dataGridView1.Columns[10].Visible = false;
            //確定社員名
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 80;
            //入庫年月日
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 80;
            //入庫済フラグ
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 80;
            //入庫管理フラグ(非表示)
            dataGridView1.Columns[14].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[15].Visible = false;

        }


        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayWarehousing();
        }

        private void ListDisplayWarehousing()
        {
            //変数の宣言
            List<DispWarehousingDTO> warehousing = new List<DispWarehousingDTO>();
            List<DispWarehousingDTO> sortedwarehousing = new List<DispWarehousingDTO>();

            //テーブルデータ受け取り
            warehousing = GetTableData();

            //昇順に並び替える
            sortedwarehousing = SortWarehousingData(warehousing);

            //データグリッドビュー表示
            SetDataGridView(sortedwarehousing);
        }

        private List<DispWarehousingDTO> GetTableData()
        {
            //変数の宣言
            List<DispWarehousingDTO> warehousing = new List<DispWarehousingDTO>();

            //インスタンス化
            WarehousingDataAccess WaAccess = new WarehousingDataAccess();

            //データベースからデータを取得
            warehousing = WaAccess.GetWarehousingData();


            return warehousing;
        }

        private List<DispWarehousingDTO> SortWarehousingData(List<DispWarehousingDTO> dispWarehousings)
        {
            //並び替え(昇順)
            dispWarehousings.OrderBy(x => x.WaID);
            return dispWarehousings;
        }

        private void button_Kennsaku_Click(object sender, EventArgs e)
        {
            SelectWarehousing();
        }

        private void SelectWarehousing()
        {
            //変数の宣言
            　DispWarehousingDTO warehousingDTO = new DispWarehousingDTO();
            List<DispWarehousingDTO> DisplayWarehousing = new List<DispWarehousingDTO>();

            //データの読み取り
            warehousingDTO = GetWarehousingInf();
            //データの検索
            DisplayWarehousing = SelectWarehousingInf(warehousingDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayWarehousing);
        }

        private DispWarehousingDTO GetWarehousingInf()
        {
            //変数の宣言
            DispWarehousingDTO retWarehousingDTO = new DispWarehousingDTO();

            //各コントロールから入庫情報を読み取る
            retWarehousingDTO.WaID = textBox_Nyuuko_ID.Text.Trim();
            retWarehousingDTO.HaID = textBox_Hattyuu_ID.Text.Trim();
            retWarehousingDTO.WaDetailID = textBox_Nyuukosyousai_ID.Text.Trim();
            retWarehousingDTO.HattyuEmID = textBox_Hattyuu_Syain_Namae.Text.Trim();
            if (!(comboBox_Kakutei_Syain_Namae.SelectedIndex == -1))
                retWarehousingDTO.ConfEmName = comboBox_Kakutei_Syain_Namae.SelectedValue.ToString();
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retWarehousingDTO.MaID = comboBox_Meka_Namae.SelectedValue.ToString();
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retWarehousingDTO.MaID = comboBox_Syouhin_Namae.SelectedValue.ToString();
            retWarehousingDTO.WaQuantity = numericUpDown_Suuryou.Value.ToString();

            return retWarehousingDTO;
        }

        private List<DispWarehousingDTO> SelectWarehousingInf (DispWarehousingDTO warehousingDTO)
        {
            //変数の宣言
            List<DispWarehousingDTO> retDispWarehousing = new List<DispWarehousingDTO>();
            //インスタンス化
            WarehousingDataAccess access = new WarehousingDataAccess();

            //入庫情報検索
            retDispWarehousing = access.GetWarehousingData(warehousingDTO);
            return retDispWarehousing;


        }
    }
}
