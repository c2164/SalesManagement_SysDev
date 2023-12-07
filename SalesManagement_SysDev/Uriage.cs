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

    
    public partial class Uriage : UserControl
    {

        private MessageDsp messageDsp = new MessageDsp();

        public Uriage()
        {
            InitializeComponent();
        }

        private void Uriage_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp("顧客情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            SaleDataAccess access = new SaleDataAccess();
            //顧客情報の全件取得
            List<DispSaleDTO> tb = access.GetSaleData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SaleDataAccess SaleDataAccess = new SaleDataAccess();
            ClientDataAccess clientDataAccess = new ClientDataAccess();
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            EmployeeDataAccess EmployeeDataAccess = new EmployeeDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Uriage_ID.Text = "";
            textBox_Uriagesyousai_ID.Text = "";
            textBox_Zyutyuu_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Kokyaku_Namae.DisplayMember = "ClName";
            comboBox_Kokyaku_Namae.ValueMember = "ClID";
            comboBox_Kokyaku_Namae.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku_Namae.SelectedIndex = -1;

            comboBox_Eigyousyo_Namae.DisplayMember = "SoName";
            comboBox_Eigyousyo_Namae.ValueMember = "SoID";
            comboBox_Eigyousyo_Namae.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo_Namae.DropDownStyle= ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo_Namae.SelectedIndex = -1;

            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = EmployeeDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex= -1;

            //  日時を初期化
            dateTimePicker_Nitizi.Value= DateTime.Now;
            dateTimePicker_Nitizi_2.Value= DateTime.Now;
            dateTimePicker_Nitizi_3.Value= DateTime.Now;

        }

        private void SetDataGridView(List<DispSaleDTO> tb)
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
            //売上ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 70;
            //売上詳細ID
            dataGridView1.Columns[1].Visible = false;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[3].Width = 70;
            //個数
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[4].Width = 60;
            //合計金額
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[5].Width = 60;
            //顧客ID
            dataGridView1.Columns[6].Visible = false;
            //顧客名
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[7].Width = 70;
            //営業所ID
            dataGridView1.Columns[8].Visible = false;
            //営業所名
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[9].Width = 90;
            //社員ID 
            dataGridView1.Columns[10].Visible = false;
            //社員名
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[11].Width = 60;
            //受注ID
            dataGridView1.Columns[12].Visible = false;
            //売上日時
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[13].Width = 80;
            //売上管理フラグ
            dataGridView1.Columns[14].Visible = false;
            //非表示理由
            dataGridView1.Columns[15].Visible = false;
        }



        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplaySale();
        }

        private void ListDisplaySale()
        {
            List<DispSaleDTO> sale = new List<DispSaleDTO>();
            List<DispSaleDTO> sortedsale = new List<DispSaleDTO>();

            sale = GetTableData();

            sortedsale = SortSaleData(sale);

            SetDataGridView(sortedsale);
        }

        private List<DispSaleDTO> GetTableData()
        {
            List<DispSaleDTO> sale = new List<DispSaleDTO>();

            SaleDataAccess saleacsess= new SaleDataAccess();

            sale = saleacsess.GetSaleData();

            return sale;
        }

        private List<DispSaleDTO> SortSaleData (List<DispSaleDTO> dispSales)

        {
            dispSales.OrderBy(x => x.SaID);
            return dispSales;

        }
    }
}
