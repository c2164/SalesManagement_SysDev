using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Nyuuka : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        public Nyuuka()
        {
            InitializeComponent();
        }

        private void Nyuuka_Load(object sender, EventArgs e)
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

        private bool GetSelectData()
        {
            ArraivalDataAccess access = new ArraivalDataAccess();
            //入荷情報の全件取得
            List<DispArrivalDTO> tb = access.GetArrivalData();
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
            ArraivalDataAccess ArrivalDataAccess = new ArraivalDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Kokyaku_Namae.Text = "";
            textBox_Nyuuka_ID.Text = "";
            textBox_Nyuuka_Syain_Namae.Text = "";
            textBox_Zyutyuu_ID.Text = "";
            textBox_Kakutei_Syain_Namae.Text = "";
            textBox_Nyuukasyousai_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            comboBox_Syouhin_Namae.DisplayMember = "PrName";
            comboBox_Syouhin_Namae.ValueMember = "PrID";
            comboBox_Syouhin_Namae.DataSource = ArrivalDataAccess.GetArrivalData();
            comboBox_Syouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syouhin_Namae.SelectedIndex = -1;

            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDateAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;
        }

        private void SetDataGridView(List<DispArrivalDTO> tb)
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
            //入荷ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;
            //入荷詳細ID
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //メーカーID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //メーカー名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //商品ID(非表示)
            dataGridView1.Columns[4].Visible = false;
            //商品名
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 80;
            //数量
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 80;
            //営業所ID(非表示)
            dataGridView1.Columns[7].Visible = false;
            //営業所名
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 80;
            //入荷社員ID(非表示)
            dataGridView1.Columns[9].Visible = false;
            //入荷社員名
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].Width = 80;
            //確定社員ID(非表示)
            dataGridView1.Columns[11].Visible = false;
            //確定社員名
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 80;
            //顧客ID(非表示)
            dataGridView1.Columns[13].Visible = false;
            //顧客名
            dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[14].Width = 80;
            //受注ID
            dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].Width = 80;
            //出荷年月日
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].Width = 80;
            //出荷状態フラグ
            dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[17].Width = 80;
            //出荷管理フラグ(非表示)
            dataGridView1.Columns[18].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[19].Visible = false;

        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }


        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayArrival();
        }

        private void ListDisplayArrival()
        {
            //変数の宣言
            List<DispArrivalDTO> Arrival = new List<DispArrivalDTO>();
            List<DispArrivalDTO> sortedArrival = new List<DispArrivalDTO>();

            //テーブルデータ受け取り
            Arrival = GetTableData();

            //昇順に並び替える
            sortedArrival = SortArrivalData(Arrival);

            //データグリッドビュー表示
            SetDataGridView(sortedArrival);

        }

        private List<DispArrivalDTO> GetTableData()
        {
            //変数の宣言
            List<DispArrivalDTO> Arrival = new List<DispArrivalDTO>();

            //インスタンス化
            ArraivalDataAccess ArAccess = new ArraivalDataAccess();

            //データベースからデータを取得
            Arrival = ArAccess.GetArrivalData();


            return Arrival;
        }

        private List<DispArrivalDTO> SortArrivalData(List<DispArrivalDTO> dispArrivals)
        {
            //並び替え(昇順)
            dispArrivals.OrderBy(x => x.ArID);
            return dispArrivals;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectArrival();
        }
        private void SelectArrival()
        {
            //変数の宣言
            DispArrivalDTO ArrivalDTO = new DispArrivalDTO();
            List<DispArrivalDTO> DisplayArrival = new List<DispArrivalDTO>();
            //データの読み取り
            ArrivalDTO = GetArrivalInf();
            //データの検索
            DisplayArrival = SelectArrivalInf(ArrivalDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayArrival);
        }

        private DispArrivalDTO GetArrivalInf()
        {
            //変数の宣言
            DispArrivalDTO retArrivalDTO = new DispArrivalDTO();

            //各コントロールから入荷情報を読み取る
            retArrivalDTO.ClName = textBox_Kokyaku_Namae.Text.Trim();
            retArrivalDTO.ArID = textBox_Nyuuka_ID.Text.Trim();
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retArrivalDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();
            retArrivalDTO.SoName = comboBox_Eigyousyo.Text.Trim();
            retArrivalDTO.ArrivalEmName = textBox_Nyuuka_Syain_Namae.Text.Trim();
            retArrivalDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retArrivalDTO.PrName = comboBox_Syouhin_Namae.SelectedIndex.ToString();
            retArrivalDTO.ConfEmName = textBox_Kakutei_Syain_Namae.Text.Trim();
            retArrivalDTO.ArID = textBox_Nyuukasyousai_ID.Text.Trim();
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retArrivalDTO.MaName = comboBox_Meka_Namae.Text.Trim();
            retArrivalDTO. ArQuantity = numericUpDown_Suuryou.Text.Trim();

            return retArrivalDTO;
        }
        private List<DispArrivalDTO> SelectArrivalInf(DispArrivalDTO ArrivalDTO)
        {
            //変数の宣言
            List<DispArrivalDTO> retDispArrival = new List<DispArrivalDTO>();
            //インスタンス化
            ArraivalDataAccess access = new ArraivalDataAccess();

            //商品情報検索
            retDispArrival = access.GetArrivalData(ArrivalDTO);
            return retDispArrival;

        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveArrival();
        }
        private void RemoveArrival()
        {
            //変数の宣言



        }
    }
}

