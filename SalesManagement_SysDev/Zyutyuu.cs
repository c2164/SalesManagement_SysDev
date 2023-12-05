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
    public partial class Zyutyuu : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();


        public Zyutyuu()
        {
            InitializeComponent();
        }

        private void Zyutyuu_Load(object sender, EventArgs e)
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

            //各テキストボックスに初期化(空白)
            textBox_Kokyaku_Namae.Text = "";
            textBox_Kokyaku_Tantou.Text = "";
            textBox_Syain_Namae.Text = "";
            textBox_Zyutyuu_ID.Text = "";
            textBox_Zyutyuusyousai_ID.Text = "";
            textBox_Meka_Namae.Text = "";
            textBox_Syouhin_Namae.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;
        }

        private bool GetSelectData()
        {
            OrderDataAccess access = new OrderDataAccess();
            //出荷情報の全件取得
            List<DispOrderDTO> tb = access.GetOrderData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetDataGridView(List<DispOrderDTO> tb)
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

            //受注ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;

            //受注詳細ID
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

            //合計金額
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 80;

            //営業所ID(非表示)
            dataGridView1.Columns[6].Visible = false;

            //営業所名
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].Width = 80;

            //社員ID(非表示)
            dataGridView1.Columns[8].Visible = false;

            //社員名
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 80;

            //顧客ID(非表示)
            dataGridView1.Columns[10].Visible = false;

            //顧客名
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 80;

            //顧客担当者名
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 80;

            //受注年月日
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 80;

            //受注状態フラグ
            dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[14].Width = 80;

            //受注管理フラグ
            dataGridView1.Columns[15].Visible = false;

            //非表示理由(非表示)
            dataGridView1.Columns[16].Visible = false;



        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayOrder();
        }

        private void ListDisplayOrder()
        {
            //変数の宣言
            List<DispOrderDTO> order = new List<DispOrderDTO>();
            List<DispOrderDTO> sortedorder = new List<DispOrderDTO>();

            //テーブルデータの受け取り
            order = GetTableData();

            //昇順に並び変え
            sortedorder = SortOrderDate(order);

            //データグリッドビューに表示
            SetDataGridView(sortedorder);
        }

        private List<DispOrderDTO> GetTableData()
        {
            //変数の宣言
            List<DispOrderDTO> order = new List<DispOrderDTO>();

            //インスタンス化
            OrderDataAccess OrAccess = new OrderDataAccess();

            //データベースからデータを取得
            order = OrAccess.GetOrderData();

            return order;
        }

        private List<DispOrderDTO> SortOrderDate(List<DispOrderDTO> disporders)
        {
            //並び変え(昇順)
            disporders.OrderBy(x => x.OrID);
            return disporders;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectOrder();
        }

        private void SelectOrder()
        {
            //変数の宣言
            DispOrderDTO orderDTO = new DispOrderDTO();
            List<DispOrderDTO> DisplayOrder = new List<DispOrderDTO>();

            //データの読み取り
            orderDTO = Getorderinf();

            //データの検索
            DisplayOrder = SelectOrderInf(orderDTO);

            //データグリッドビューに表示
            SetDataGridView(DisplayOrder);
        }

        private DispOrderDTO Getorderinf()
        {
            //変数の宣言
            DispOrderDTO retOrderDTO = new DispOrderDTO();

            //各コントロールから情報を読み取る
            retOrderDTO.ClName = textBox_Kokyaku_Namae.Text.Trim();//顧客名
            retOrderDTO.ClCharge = textBox_Kokyaku_Tantou.Text.Trim();//顧客担当者
            retOrderDTO.EmName = textBox_Syain_Namae.Text.Trim();//社員名
            retOrderDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();//受注ID 
            retOrderDTO.OrDetailID = textBox_Zyutyuusyousai_ID.Text.Trim();//受注詳細ID
            retOrderDTO.MaName = textBox_Meka_Namae.Text.Trim();//メーカー名
            if (!(comboBox_Eigyousyo.SelectedIndex == -1)) retOrderDTO.SoID = comboBox_Eigyousyo.SelectedIndex.ToString();//営業所名
            retOrderDTO.PrName = textBox_Syouhin_Namae.Text.Trim();//商品名
            retOrderDTO.OrQuantity = numericUpDown_Suuryou.Value.ToString();//数量

            return retOrderDTO;
        }

        private List<DispOrderDTO> SelectOrderInf(DispOrderDTO orderDTO)
        {
            //変数の宣言
            List<DispOrderDTO> retDispOrder = new List<DispOrderDTO>();

            //インスタンス化
            OrderDataAccess OrAccess = new OrderDataAccess();

            //商品検索
            retDispOrder = OrAccess.GetOrderData(orderDTO);

            return retDispOrder;
        }
    }
}
