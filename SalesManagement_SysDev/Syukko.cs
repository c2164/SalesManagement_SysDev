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
    public partial class Syukko : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();

        public Syukko()
        {
            InitializeComponent();
        }

        private void Syukko_load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("出庫情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            SyukkoDataAccess access = new SyukkoDataAccess();
            //入庫情報の全件取得
            List<DispSyukkoDTO> tb = access.GetSyukkoData();
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
            textBox_Kakutei_Syain_Namae.Text = "";
            textBox_Syain.Text = "";
            textBox_Syukkosyousai_ID.Text = "";
            textBox_Zyutyuu_ID.Text = "";


            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            comboBox_Kokyaku.DisplayMember = "ClName";
            comboBox_Kokyaku.ValueMember = "ClID";
            comboBox_Kokyaku.DataSource = productDataAccess.GetProductData();
            comboBox_Kokyaku.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku.SelectedIndex = -1;

            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDateAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;

            comboBoxSyouhin_Namae.DisplayMember = "PrName";
            comboBoxSyouhin_Namae.ValueMember = "PrID";
            comboBoxSyouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBoxSyouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSyouhin_Namae.SelectedIndex = -1;

            //数量の初期化
            domainUpDown_Suuryou.Value = 0;
        }
        private void SetDataGridView(List<DispSyukkoDTO> tb)
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
            //出庫ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 40;
            //出庫詳細ID
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 190;
            //数量
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 80;
            //営業所
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 55;
            //営業所ID
            dataGridView1.Columns[6].Visible = false;
            //営業所名
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].Width = 80;
            //社員ID
            dataGridView1.Columns[8].Visible = false;
            //社員名
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 80;
            //顧客ID
            dataGridView1.Columns[10].Visible = false;
            //顧客名
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 80;
            //注文ID
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 80;
            //注文社員ID
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 80;
            //確定社員ID
            dataGridView1.Columns[14].Visible = false;
            //確定社員名
            dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].Width = 80;
            //メーカー名
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].Width = 80;
            //受注ID
            dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[17].Width = 80;
            //出庫年月日
            dataGridView1.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[18].Width = 80;
            //出庫状態フラグ
            dataGridView1.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[19].Width = 80;
            //出庫管理フラグ(非表示)
            dataGridView1.Columns[20].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[21].Visible = false;

        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            //GetSelectData();
            //SetCtrlFormat();
        }

        private void button_Itiranhyouzi_Click(object sender, EventArgs e)
        {

            ListDisplaySyukko();
        }

        private void ListDisplaySyukko()
        {
            //変数の宣言
            List<DispSyukkoDTO> syukko = new List<DispSyukkoDTO>();
            List<DispSyukkoDTO> sortedsyukko = new List<DispSyukkoDTO>();

            //テーブルデータ受け取り
            syukko = GetTableData();

            //昇順に並び替える
            sortedsyukko = SortSyukkoData(syukko);

            //データグリッドビュー表示
            SetDataGridView(sortedsyukko);

        }

        private List<DispSyukkoDTO> GetTableData()
        {
            //変数の宣言
            List<DispSyukkoDTO> syukko = new List<DispSyukkoDTO>();

            //インスタンス化
            SyukkoDataAccess SyAccess = new SyukkoDataAccess();

            //データベースからデータを取得
            syukko = SyAccess.GetSyukkoData();


            return syukko;
        }

        private List<DispSyukkoDTO> SortSyukkoData(List<DispSyukkoDTO> dispSyukkos)
        {
            //並び替え(昇順)
            dispSyukkos.OrderBy(x => x.SyID);
            return dispSyukkos;
        }

        private void button_Kennsaku_Click(object sender, EventArgs e)
        {
            SelectSyukko();
        }

        private void SelectSyukko()
        {

            //変数の宣言
            DispSyukkoDTO syukkoDTO = new DispSyukkoDTO();
            List<DispSyukkoDTO> DisplaySyukko = new List<DispSyukkoDTO>();

            //データ読み取り
            syukkoDTO = GetSyukkoInf();
            //データの検索
            DisplaySyukko = SelectSyukkoInf(syukkoDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplaySyukko);
        }


        private DispSyukkoDTO GetSyukkoInf()
        {
            //変数の宣言
            DispSyukkoDTO retSyukkoDTO = new DispSyukkoDTO();

            //各コントロールから出庫情報を読み取る
            retSyukkoDTO.SyID = numericUpDown_Syukko_ID.Value.ToString();
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retSyukkoDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();
            retSyukkoDTO.ChumonEmID = textBox_Syain.Text.Trim();
            if (!(comboBox_Kokyaku.SelectedIndex == -1))
                retSyukkoDTO.ClName = comboBox_Kokyaku.SelectedValue.ToString();
            retSyukkoDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();
            retSyukkoDTO.ConfEmID = textBox_Kakutei_Syain_Namae.Text.Trim();
            retSyukkoDTO.SyDetailID = textBox_Syukkosyousai_ID.Text.Trim();
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retSyukkoDTO.MaName = comboBox_Meka_Namae.SelectedValue.ToString();
            if (!(comboBoxSyouhin_Namae.SelectedIndex == -1))
                retSyukkoDTO.PrName = comboBoxSyouhin_Namae.SelectedValue.ToString();
            retSyukkoDTO.SyQuantity = domainUpDown_Suuryou.Value.ToString();
           
            
            return retSyukkoDTO;
        }

        private List<DispSyukkoDTO> SelectSyukkoInf (DispSyukkoDTO syukkoDTO)
        {
            //変数の宣言
            List<DispSyukkoDTO> retDispSyukko = new List<DispSyukkoDTO>();
            //インスタンス化
            SyukkoDataAccess access = new SyukkoDataAccess();
            //出庫情報検索
            retDispSyukko = access.GetSyukkoData(syukkoDTO);
            return retDispSyukko;



        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveSyukko();
        }

        private void RemoveSyukko()
        {
            //変数の宣言
            string SyID;
            T_Syukko syukko = new T_Syukko();
            //データグリッドビューで選択されているデータの出庫IDを受け取る
            SyID = GetSyukkoRecord();
            if(SyID==null)
            {
                return;
            }

            //取得した出庫IDでデータベースを検索する
            syukko = SelectRemoveSyukko(SyID);
            if (syukko == null)
            {
                return;
            }

            //出庫管理フラグを0から2にする
            UpdateSyFlag(syukko);
        }

        private void UpdateSyFlag(T_Syukko syukko)
        {
            //変数の宣言
            DialogResult result;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の出庫情報を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //出庫管理フラグの変更
            syukko = ChangeSyFlag(syukko);
            if (syukko == null)
            {
                return;
            }
            //出庫の更新
            UpdateSyukkoRecord(syukko);
        }

        private void UpdateSyukkoRecord(T_Syukko syukko)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            SyukkoDataAccess access = new SyukkoDataAccess();
            flg = access.UpdateSyukkoData(syukko);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象出庫情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象出庫情報を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private T_Syukko ChangeSyFlag(T_Syukko syukko)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            syukko.SyFlag = 2;
            syukko.SyHidden = Hidden;
            return syukko;
        }

        private T_Syukko SelectRemoveSyukko(string SyID)
        {
            //変数の宣言
            T_Syukko retsyukko = new T_Syukko();
            DispSyukkoDTO dispSyukkoDTO = new DispSyukkoDTO();
            List<DispSyukkoDTO> dispSyukkos = new List<DispSyukkoDTO>();
            //データベースからデータを取得する
            dispSyukkos = GetTableData();
            if (dispSyukkos == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("出庫情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った出庫IDで検索
            dispSyukkoDTO = dispSyukkos.Single(x => x.SyID == SyID);

            //検索結果を返却用にする
            retsyukko = FormalizationSyukkoInputRecord(dispSyukkoDTO);

            return retsyukko;
        }

        private T_Syukko FormalizationSyukkoInputRecord(DispSyukkoDTO dispSyukkoDTO)
        {
            T_Syukko retsyukko = new T_Syukko();
            retsyukko.SyID = int.Parse(dispSyukkoDTO.SyID);
            retsyukko.EmID = int.Parse(dispSyukkoDTO.EmID);
            retsyukko.ClID = int.Parse(dispSyukkoDTO .ClID);    
            retsyukko.SoID = int.Parse (dispSyukkoDTO .SoID);
            retsyukko.OrID = int.Parse(dispSyukkoDTO.OrID);
            retsyukko.SyDate = dispSyukkoDTO.SyDate;
            retsyukko.SyStateFlag = int.Parse(dispSyukkoDTO.SyStateFlag);
            retsyukko.SyFlag = int.Parse(dispSyukkoDTO.SyFlag);
            retsyukko.SyHidden = dispSyukkoDTO.SyHidden;
            return retsyukko;
        }

        private T_SyukkoDetail FormalizationSyukkoDetailInputRecord(DispSyukkoDTO dispSyukkoDetailDTO)
        {
            T_SyukkoDetail retsyukkodetail = new T_SyukkoDetail();
            retsyukkodetail.SyDetailID = int.Parse(dispSyukkoDetailDTO.SyDetailID);
            retsyukkodetail.SyID = int.Parse(dispSyukkoDetailDTO .SyID);
            retsyukkodetail.PrID = int.Parse(dispSyukkoDetailDTO.PrID);
            retsyukkodetail.SyQuantity = int.Parse(dispSyukkoDetailDTO.SyQuantity);


            return retsyukkodetail;

        }

            private string GetSyukkoRecord()
        {
            //変数の宣言
            string retSyID;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retSyID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retSyID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}