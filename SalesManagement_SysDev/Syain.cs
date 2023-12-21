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
    public partial class Syain : UserControl
    {

        private MessageDsp messageDsp = new MessageDsp();

        public Syain()
        {
            InitializeComponent();
        }

        private void Syain_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("社員情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            //社員情報の全件取得
            List<DispEmplyeeDTO> tb = access.GetEmployeeData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetDataGridView(List<DispEmplyeeDTO> tb)
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
            //社員ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //社員名
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //営業所ID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //営業所名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //役職ID(非表示)
            dataGridView1.Columns[4].Visible = false;
            //役職名
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 50;
            //入社年月日
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 120;
            //パスワード
            dataGridView1.Columns[7].Visible = false;
            //電話番号
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 55;
            //社員管理フラグ(非表示)
            dataGridView1.Columns[9].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[10].Visible = false;

        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesofficeDateAccess = new SalesOfficeDataAccess();
            PositionDataAccess positionDataAccess = new PositionDataAccess();

            //各テキストボックスに初期化(空白)
            textBox_Syain_Namae.Text = "";
            textBox_Syain_ID.Text = "";
            textBox_Yakusyoku.Text = "";
            textBox_Dennwa.Text = "";
            textBox_FAX.Text = "";
            textBox_Pass.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesofficeDateAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            //日付を現在の日付にする
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();            
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayEmployee();
        }

        private void ListDisplayEmployee()
        {
            //変数の宣言
            List<DispEmplyeeDTO> employee = new List<DispEmplyeeDTO>();
            List<DispEmplyeeDTO> sortedemployee = new List<DispEmplyeeDTO>();

            //テーブルデータ受け取り
            employee = GetTableData();

            //昇順に並び替える
            sortedemployee = SortEmployeeData(employee);

            //データグリッドビュー表示
            SetDataGridView(sortedemployee);
        }

        private List<DispEmplyeeDTO> GetTableData()
        {
            //変数の宣言
            List<DispEmplyeeDTO> employee = new List<DispEmplyeeDTO>();

            //インスタンス化
            EmployeeDataAccess EmAccess = new EmployeeDataAccess();

            //データベースからデータを取得
            employee = EmAccess.GetEmployeeData();


            return employee;
        }

        private List<DispEmplyeeDTO> SortEmployeeData(List<DispEmplyeeDTO> dispEmployees)
        {
            //並び替え(昇順)
            dispEmployees.OrderBy(x => x.EmID);
            return dispEmployees;

        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }

        private void SelectEmployee()
        {
            //変数の宣言
            DispEmplyeeDTO employeeDTO = new DispEmplyeeDTO();
            List<DispEmplyeeDTO> DisplayEmployee = new List<DispEmplyeeDTO>();

            //データの読み取り
            employeeDTO = GetEmployeeInf();
            //データの検索
            DisplayEmployee = SelectEmployeeInf(employeeDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayEmployee);
        }

        private DispEmplyeeDTO GetEmployeeInf()
        {
            //変数の宣言
            DispEmplyeeDTO retEmployeeDTO = new DispEmplyeeDTO();

            //各コントロールから社員情報を読み取る
            retEmployeeDTO.EmName = textBox_Syain_Namae.Text.Trim();
            retEmployeeDTO.EmID = textBox_Syain_ID.Text.Trim();
            if(!(comboBox_Eigyousyo.SelectedIndex == -1))
                retEmployeeDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();
            retEmployeeDTO.PoName = textBox_Yakusyoku.Text.Trim();
            retEmployeeDTO.EmHiredate = dateTimePicker1.Value;
            retEmployeeDTO.EmPhone = textBox_Dennwa.Text.Trim();
            //Fax削除予定
            retEmployeeDTO.EmPassword = textBox_Pass.Text.Trim();

            return retEmployeeDTO;
        }

        private List<DispEmplyeeDTO> SelectEmployeeInf(DispEmplyeeDTO employeeDTO)
        {
            //変数の宣言
            List<DispEmplyeeDTO> retDispEmployee = new List<DispEmplyeeDTO>();
            //インスタンス化
            EmployeeDataAccess access = new EmployeeDataAccess();

            //社員情報検索
            retDispEmployee = access.GetEmployeeData(employeeDTO);
            return retDispEmployee;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_FAX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
