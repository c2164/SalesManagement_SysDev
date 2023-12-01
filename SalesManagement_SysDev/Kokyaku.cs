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
    public partial class Kokyaku : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();

        public Kokyaku()
        {
            InitializeComponent();
        }

        private void Kokyaku_Load(object sender, EventArgs e)
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
            ClientDataAccess access = new ClientDataAccess();
            //顧客情報の全件取得
            List<DispClientDTO> tb = access.GetClientData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Kokyaku_Namae.Text = "";
            textBox_Kokyaku_ID.Text = "";
            textBox_Yuubin.Text = "";
            textBox_Zyuusyo.Text = "";
            textBox_Dennwa.Text = "";
            textBox_FAX.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

        }

        private void SetDataGridView(List<DispClientDTO> tb)
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
            //顧客ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;
            //顧客名
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //営業所ID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //営業所名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //住所
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 190;
            //電話番号
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 80;
            //郵便番号
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 55;
            //FAX
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].Width = 80;
            //顧客管理フラグ(非表示)
            dataGridView1.Columns[8].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[9].Visible = false;

        }

        private void button_Touroku_Click(object sender, EventArgs e)
        {
            RegisterClient();
        }

        private void RegisterClient()
        {
            DispClientDTO dispClientDTO = new DispClientDTO();
            dispClientDTO = GetCheckedClientInf();
            if(dispClientDTO == null) 
            {
                return;
            }
            DuplicationCheckCliantInputRecord();
            RegisrationClientInf();
        }

        private DispClientDTO GetCheckedClientInf()
        {
            DispClientDTO retDispClient = new DispClientDTO();
            string msg;
            MessageBoxIcon icon;
            retDispClient = GetClientInf();
            //CheckClientInf(retDispClient, out msg, out icon);
            return retDispClient;
        }

        private DispClientDTO GetClientInf()
        {
            DispClientDTO retDispClient = new DispClientDTO();
            retDispClient.ClID = textBox_Kokyaku_ID.Text;
            retDispClient.ClName = textBox_Kokyaku_Namae.Text;
            retDispClient.ClPostal = textBox_Yuubin.Text;
            retDispClient.ClPhone = textBox_Dennwa.Text;
            retDispClient.ClFAX = textBox_FAX.Text;
            retDispClient.SoID = comboBox_Eigyousyo.SelectedValue.ToString();
            retDispClient.SoName = comboBox_Eigyousyo.Text;

            return retDispClient;
        }

        /*private bool CheckClientInf(DispClientDTO checkClientDTO, out string msg, out MessageBoxIcon icon)
        {

        }*/

        private void RegisrationClientInf()
        {

        }

        private bool DuplicationCheckCliantInputRecord()
        {
            bool ret = false;
            return ret;
        }

    }
}
