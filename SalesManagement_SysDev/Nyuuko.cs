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

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveWarehousing();
        }

        private void RemoveWarehousing()
        {
            //変数の宣言
            string WaID;
            T_Warehousing warehousing = new T_Warehousing();
            //データグリッドビューで選択されているデータの入庫IDを受け取る
            WaID = GetWarehousingRecord();
            if(WaID == null)
            {
                return;
            }

            //取得した入庫IDでデータベースを検索する
            warehousing = SelectRemoveWarehousing(WaID);
            if (warehousing == null)
            {
                return;
            }

            //入庫管理フラグを0から2にする
            UpdateWaFlag(warehousing);
        }

        private void UpdateWaFlag(T_Warehousing warehousing)
        {
            //変数の宣言
            DialogResult result;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の入庫情報を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //入庫管理フラグの変更
            warehousing = ChangeWaFlag(warehousing);
            if (warehousing == null)
            {
                return;
            }
            //入庫の更新
            UpdateWarehousingRecord(warehousing);
        }

        private void UpdateWarehousingRecord(T_Warehousing warehousing)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            WarehousingDataAccess access = new WarehousingDataAccess();
            flg = access.UpdateWarehousingData(warehousing);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象入庫情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象入庫情報を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private T_Warehousing ChangeWaFlag(T_Warehousing warehousing)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }

            warehousing.WaFlag = 2;
            warehousing.WaHidden = Hidden;
            return warehousing;
        }

        private T_Warehousing SelectRemoveWarehousing(string WaID)
        {
            //変数の宣言
            T_Warehousing retwarehousing = new T_Warehousing();
            DispWarehousingDTO dispWarehousingDTO = new DispWarehousingDTO();
            List<DispWarehousingDTO> dispWarehousings = new List<DispWarehousingDTO>();
            //データベースからデータを取得する
            dispWarehousings = GetTableData();
            if (dispWarehousings == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("入庫情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った入庫IDで検索
            dispWarehousingDTO = dispWarehousings.Single(x => x.WaID == WaID);

            //検索結果を返却用にする
            retwarehousing = FormalizationWarehousingInputRecord(dispWarehousingDTO);

            return retwarehousing;
        }

        private T_Warehousing FormalizationWarehousingInputRecord(DispWarehousingDTO dispWarehousingDTO)
        {
            T_Warehousing retwarehousing = new T_Warehousing();
            retwarehousing.WaID = int.Parse(dispWarehousingDTO.WaID);
            retwarehousing.HaID = int.Parse(dispWarehousingDTO.HaID);
            retwarehousing.WaDate = dispWarehousingDTO.WaDate;
            retwarehousing.WaShelfFlag = int.Parse(dispWarehousingDTO.WaShelfFlag);
            retwarehousing.WaFlag = int.Parse(dispWarehousingDTO.WaFlag);
            retwarehousing.WaHidden = dispWarehousingDTO.WaHidden;
           


            return retwarehousing;
        }


        private T_WarehousingDetail FormalizationWarehousingDetailInputRecord(DispWarehousingDTO dispWarehousingDetailDTO)
        { 
            T_WarehousingDetail retwarehousingdetail = new T_WarehousingDetail();
            retwarehousingdetail.WaDetailID = int.Parse(dispWarehousingDetailDTO.WaDetailID);
            retwarehousingdetail.WaQuantity = int.Parse(dispWarehousingDetailDTO.WaQuantity);
            retwarehousingdetail.PrID = int.Parse(dispWarehousingDetailDTO.PrID);
            retwarehousingdetail.WaID = int.Parse(dispWarehousingDetailDTO.WaID);
            

                return retwarehousingdetail;
                }

        private string GetWarehousingRecord()
        {


            //変数の宣言
            string retWaID;
            if(dataGridView1.SelectedRows.Count<=0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください","エラー",MessageBoxIcon.Error);
                return null;
            }
            retWaID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retWaID;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Nyuuko_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox_Hattyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            textBox_Nyuukosyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox_Hattyuu_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
            comboBox_Kakutei_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
            comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            numericUpDown_Suuryou.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
         
        }
    }

} 
