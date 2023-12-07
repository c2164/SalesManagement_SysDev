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
    public partial class Tyuumon : UserControl
    {

        private MessageDsp messageDsp = new MessageDsp();

        public Tyuumon()
        {
            InitializeComponent();
        }

        private void Tyuumon_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp("出荷情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }


        }
        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

            textbox_Tyuumon_ID.Text = "";
            textbox_Tyuumonsyousai_ID.Text = "";
            textbox_Zyutyuusyousai.Text = "";
            textbox_Kokyaku_Namae.Text = "";


            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            comboBox_Syouhin_Namae.DisplayMember = "PrName";
            comboBox_Syouhin_Namae.ValueMember = "PrID";
            comboBox_Syouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBox_Syouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syouhin_Namae.SelectedIndex = -1;

            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = employeeDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex = -1;


        }

        private bool GetSelectData()
        {
            ChumonDataAccess access = new ChumonDataAccess();
            //出荷情報の全件取得
            List<DispChumonDTO> tb = access.GetChumonData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }




        private void SetDataGridView(List<DispChumonDTO> tb)
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

            //注文ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;

            //注文詳細ID
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;

            //商品ID(非表示)
            dataGridView1.Columns[2].Visible = false;

            //商品名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;

            //数量
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 80;

            //営業所ID(非表示)
            dataGridView1.Columns[5].Visible = false;

            //営業所名
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 80;

            //社員ID(非表示)
            dataGridView1.Columns[7].Visible = false;

            //社員名
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 80;

            //顧客ID(非表示)
            dataGridView1.Columns[9].Visible = false;

            //顧客名
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].Width = 80;

            //受注ID
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 80;

            //注文年月日
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 80;

            //注文状態フラグ
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 80;

            //注文管理フラグ(非表示)
            dataGridView1.Columns[14].Visible = false;

            //非表示理由(非表示)
            dataGridView1.Columns[15].Visible = false;


        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            //GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayChumon();
        }

        private void ListDisplayChumon()
        {
            //変数の宣言
            List<DispChumonDTO> chumon = new List<DispChumonDTO>();
            List<DispChumonDTO> sortedchumon = new List<DispChumonDTO>();

            //データの受け取り
            chumon = GetTableDate();

            //昇順に並び変え
            sortedchumon = SortChumonDate(chumon);

            //データグリッドビューに表示
            SetDataGridView(sortedchumon);
        }

        private List<DispChumonDTO> GetTableDate()
        {
            //変数の宣言
            List<DispChumonDTO> chumon = new List<DispChumonDTO>();

            //インスタンス化
            ChumonDataAccess chAccess = new ChumonDataAccess();

            //データベースからデータを取得
            chumon = chAccess.GetChumonData();

            return chumon;
        }

        private List<DispChumonDTO> SortChumonDate(List<DispChumonDTO> dispchumons)
        {
            //並び変え(昇順)
            dispchumons.OrderBy(x => x.ChID);
            return dispchumons;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectChumon();
        }

        private void SelectChumon()
        {
            //変数の宣言
            DispChumonDTO chumonDTO = new DispChumonDTO();
            List<DispChumonDTO> DisplayChumon = new List<DispChumonDTO>();

            //データの読み取り
            chumonDTO = GetChumonInf();

            //データの検索
            DisplayChumon = SelectChumonInf(chumonDTO);

            //データグリッドビューに表示
            SetDataGridView(DisplayChumon);
        }

        private DispChumonDTO GetChumonInf()
        {
            //変数の宣言
            DispChumonDTO retChumonDTO = new DispChumonDTO();

            //各コントロールから情報を読み取る
            retChumonDTO.ChID = textbox_Tyuumon_ID.Text.Trim();//注文ID

            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retChumonDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();//商品ID

            retChumonDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();//商品名

            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retChumonDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所ID

            retChumonDTO.SoName = comboBox_Eigyousyo.Text;//営業所名

            retChumonDTO.ChDetailID = textbox_Tyuumonsyousai_ID.Text.Trim();//注文詳細ID

            retChumonDTO.OrID = textbox_Tyuumonsyousai_ID.Text.Trim();//受注ID

            retChumonDTO.ClName = textbox_Kokyaku_Namae.Text.Trim();//顧客名

            if (!(comboBox_Syain_Namae.SelectedIndex == -1))
                retChumonDTO.EmID = comboBox_Syain_Namae.SelectedValue.ToString();//社員ID

            retChumonDTO.EmName = comboBox_Syain_Namae.Text.Trim();//社員名

            //retChumonDTO.ChDate = dateTimePicker_Tyuumon_Nenngetu.Value;//注文年月日

            retChumonDTO.ChQuantity = numericUPDown_Syouhin_Namae.Value.ToString();//数量

            return retChumonDTO;
        }

        private List<DispChumonDTO> SelectChumonInf(DispChumonDTO ChumonDTO)
        {
            //変数の宣言
            List<DispChumonDTO> retDispChumon = new List<DispChumonDTO>();

            //インスタンス化
            ChumonDataAccess access = new ChumonDataAccess();

            //注文情報検索
            retDispChumon = access.GetChumonData(ChumonDTO);

            return retDispChumon;
        }
    }
}
