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
        private int DataGridViewState;
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
                messageDsp.MessageBoxDsp_OK("顧客情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            SaleDataAccess access = new SaleDataAccess();
            //売上情報の全件取得
            List<DispSaleDTO> tb = access.GetSaleData();
            List<DispSaleDTO> disptb = new List<DispSaleDTO>();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            disptb = GetDataGridViewData(tb);
            SetDataGridView(disptb);
            return true;
        }

        private bool GetSelectDetailData(string SaID)
        {
            SaleDataAccess access = new SaleDataAccess();
            DispSaleDTO dispSale = new DispSaleDTO()
            {
                SaID = SaID,
                OrID = "",
                ClName = "",
                SoName = "",
                PrName = "",
                SaDetailID = "",
                EmName = "",
            };

            //売上情報の全件取得
            List<DispSaleDTO> tb = access.GetSaleData(dispSale);
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDetailDataGridView(tb);
            return true;
        }

        private List<DispSaleDTO> GetDataGridViewData(List<DispSaleDTO> tb)
        {
            List<DispSaleDTO> disptb = new List<DispSaleDTO>();
            var grouptb = tb.GroupBy(x => x.SaID).ToList();
            foreach (var groupinguriagetb in grouptb)
            {
                foreach (var saletb in groupinguriagetb)
                {
                    DispSaleDTO saleDTO = new DispSaleDTO();
                    saleDTO.SaID = saletb.SaID;
                    saleDTO.OrID = saletb.OrID;
                    saleDTO.ClID = saletb.ClID;
                    saleDTO.ClName = saletb.ClName;
                    saleDTO.EmID = saletb.EmID;
                    saleDTO.EmName = saletb.EmName;
                    saleDTO.SoID = saletb.SoID;
                    saleDTO.SoName = saletb.SoName;
                    saleDTO.SaDate = saletb.SaDate;
                    saleDTO.SaFlag = saletb.SaFlag;
                    saleDTO.SaHidden = saletb.SaHidden;

                    disptb.Add(saleDTO);
                    break;
                }
            }
            return disptb;
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
            comboBox_Eigyousyo_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo_Namae.SelectedIndex = -1;

            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = EmployeeDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex = -1;

            //  日時を初期化
            dateTimePicker_Nitizi.Value = DateTime.Now;
            dateTimePicker_Nitizi_2.Value = DateTime.Now;
            dateTimePicker_Nitizi_3.Value = DateTime.Now;

            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void SetDataGridView(List<DispSaleDTO> tb)
        {
            dataGridView1.DataSource = tb;
            DataGridViewState = 1;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー文字位置、セル文字位置、列幅の設定
            dataGridView1.TopLeftHeaderCell.Value = "";
            //売上ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //売上詳細ID
            dataGridView1.Columns[1].Visible = false;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].Visible = false;
            //個数
            dataGridView1.Columns[4].Visible = false;
            //合計金額
            dataGridView1.Columns[5].Visible = false;
            //顧客ID
            dataGridView1.Columns[6].Visible = false;
            //顧客名
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[7].Width = 70;
            //営業所ID
            dataGridView1.Columns[8].Visible = false;
            //営業所名
            dataGridView1.Columns[9].Visible = true;
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[9].Width = 90;
            //社員ID 
            dataGridView1.Columns[10].Visible = false;
            //社員名
            dataGridView1.Columns[11].Visible = true;
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[11].Width = 90;
            //受注ID
            dataGridView1.Columns[12].Visible = false;
            //売上日時
            dataGridView1.Columns[13].Visible = true;
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[13].Width = 80;
            //売上管理フラグ
            dataGridView1.Columns[14].Visible = false;
            //非表示理由
            dataGridView1.Columns[15].Visible = false;
            //検索用日時（前）
            dataGridView1.Columns[16].Visible = false;
            //検索用日時（後）
            dataGridView1.Columns[17].Visible = false;
        }

        private void SetDetailDataGridView(List<DispSaleDTO> tb)
        {
            dataGridView1.DataSource = tb;
            DataGridViewState = 2;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー文字位置、セル文字位置、列幅の設定
            dataGridView1.TopLeftHeaderCell.Value = "戻る";
            //売上ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //売上詳細ID
            dataGridView1.Columns[1].Visible = false;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[3].Width = 70;
            //個数
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[4].Width = 60;
            //合計金額
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[5].Width = 60;
            //顧客ID
            dataGridView1.Columns[6].Visible = false;
            //顧客名
            dataGridView1.Columns[7].Visible = false;
            //営業所ID
            dataGridView1.Columns[8].Visible = false;
            //営業所名
            dataGridView1.Columns[9].Visible = false;
            //社員ID 
            dataGridView1.Columns[10].Visible = false;
            //社員名
            dataGridView1.Columns[11].Visible = false;
            //受注ID
            dataGridView1.Columns[12].Visible = false;
            //売上日時
            dataGridView1.Columns[13].Visible = false;
            //売上管理フラグ
            dataGridView1.Columns[14].Visible = false;
            //非表示理由
            dataGridView1.Columns[15].Visible = false;
            //検索用日時（前）
            dataGridView1.Columns[16].Visible = false;
            //検索用日時（後）
            dataGridView1.Columns[17].Visible = false;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
            cmbclia();
        }

        private DispSaleDTO GetSaleInf()
        {
            DispSaleDTO retSaleDTO = new DispSaleDTO();

            //各コントロールの情報
            retSaleDTO.SaID = textBox_Uriage_ID.Text.Trim();

            if (!(comboBox_Kokyaku_Namae.SelectedIndex == -1))
                retSaleDTO.ClID = comboBox_Kokyaku_Namae.SelectedValue.ToString();
            retSaleDTO.ClName = comboBox_Kokyaku_Namae.Text.Trim();

            if (!(comboBox_Eigyousyo_Namae.SelectedIndex == -1))
                retSaleDTO.SoID = comboBox_Eigyousyo_Namae.SelectedValue.ToString();
            retSaleDTO.SoName = comboBox_Eigyousyo_Namae.Text.Trim();

            retSaleDTO.SaDetailID = textBox_Uriagesyousai_ID.Text.Trim();

            if (!(comboBox_Syain_Namae.SelectedIndex == -1))
                retSaleDTO.EmID = comboBox_Syain_Namae.SelectedValue.ToString();
            retSaleDTO.EmName = comboBox_Syain_Namae.Text.Trim();

            retSaleDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();

            retSaleDTO.SaReleseFromDate = dateTimePicker_Nitizi_2.Value;

            retSaleDTO.SaReleaseToDate = dateTimePicker_Nitizi_3.Value;

            return retSaleDTO;

        }

        private List<DispSaleDTO> SelectSaleInf(DispSaleDTO SaleDTO)
        {
            List<DispSaleDTO> retDispSale = new List<DispSaleDTO>();

            SaleDataAccess SaAcsess = new SaleDataAccess();

            retDispSale = SaAcsess.GetSaleData(SaleDTO);
            return retDispSale;

        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveSale();
        }

        private void RemoveSale()
        {
            //変数の宣言
            string SaID;
            T_Sale sale = new T_Sale();
            T_SaleDetail saleDetail = new T_SaleDetail();
            //データグリッドビューで選択されているデータの商品IDを受け取る
            SaID = GetSaleRecode();
            if (SaID == null)
            {
                return;
            }

            //取得した商品IDでデータベースを検索する
            sale = SelectRemoveSale(SaID, out saleDetail);
            if (sale == null)
            {
                messageDsp.MessageBoxDsp_OK("商品情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //商品管理フラグを0から2にする
            UpdateSaFlag(sale, saleDetail);
        }

        private void UpdateSaFlag(T_Sale sale, T_SaleDetail saleDetail)
        {
            //変数宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象のデータを非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //売上管理フラグ変更
            sale = ChangeSaFlg(sale);
            if (sale == null)
            {
                return;
            }
            //データの更新
            flg = UpdateSaleRecord(sale, saleDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象のデータを非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象のデータの非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateSaleRecord(T_Sale sale, T_SaleDetail saleDetail)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            SaleDataAccess access = new SaleDataAccess();
            flg = access.UpdateSaleData(sale, saleDetail);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private T_Sale ChangeSaFlg(T_Sale sale)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }
            sale.SaFlag = 2;
            sale.SaHidden = Hidden;
            return sale;
        }

        private T_Sale SelectRemoveSale(string SaID, out T_SaleDetail saleDetail)
        {
            //変数の宣言
            T_Sale retsale = new T_Sale();
            DispSaleDTO dispSaleDTO = new DispSaleDTO();
            List<DispSaleDTO> dispSales = new List<DispSaleDTO>();
            saleDetail = null;
            //データベースからデータを取得する
            dispSales = GetTableData();

            if (dispSales == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("売上情報を取得できませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った商品IDで検索
            dispSaleDTO = dispSales.First(x => x.SaID == SaID);

            //検索結果を返却用にする
            retsale = FormalizationSaleInputRecord(dispSaleDTO);
            saleDetail = FormalizationSaleDetailInputRecord(dispSaleDTO);

            return retsale;
        }

        private T_Sale FormalizationSaleInputRecord(DispSaleDTO dispSaleDTO)
        {
            T_Sale retsale = new T_Sale();


            retsale.SaID = int.Parse(dispSaleDTO.SaID);
            retsale.ClID = int.Parse(dispSaleDTO.ClID);
            retsale.SoID = int.Parse(dispSaleDTO.SoID);
            retsale.EmID = int.Parse(dispSaleDTO.EmID);
            retsale.ChID = int.Parse(dispSaleDTO.OrID);
            retsale.SaDate = dispSaleDTO.SaDate.Value;
            retsale.SaHidden = dispSaleDTO.SaHidden;
            retsale.SaFlag = int.Parse(dispSaleDTO.SaFlag);

            return retsale;
        }

        private T_SaleDetail FormalizationSaleDetailInputRecord(DispSaleDTO dispSaleDTO)
        {
            T_SaleDetail retsaleDetail = new T_SaleDetail();


            retsaleDetail.SaDetailID = int.Parse(dispSaleDTO.SaDetailID);
            retsaleDetail.SaID = int.Parse(dispSaleDTO.SaID);
            retsaleDetail.PrID = int.Parse(dispSaleDTO.PrID);
            retsaleDetail.SaQuantity = int.Parse(dispSaleDTO.SaQuantity);
            retsaleDetail.SaTotalPrice = decimal.Parse(dispSaleDTO.SaTotalPrice);

            return retsaleDetail;
        }

        private string GetSaleRecode()
        {
            //変数の宣言
            string retSaID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retSaID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retSaID;
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

            SaleDataAccess saleacsess = new SaleDataAccess();

            sale = saleacsess.GetSaleData();

            return sale;
        }

        private List<DispSaleDTO> SortSaleData(List<DispSaleDTO> dispSales)

        {
            dispSales.OrderBy(x => x.SaID);
            return dispSales;

        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectSale();
        }

        private void SelectSale()
        {
            DispSaleDTO saleDTO = new DispSaleDTO();
            List<DispSaleDTO> displaySale = new List<DispSaleDTO>();

            saleDTO = GetSaleInf();

            displaySale = SelectSaleInf(saleDTO);

            SetDataGridView(displaySale);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewState == 1)
            {
                string ArID;
                ArID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                GetSelectDetailData(ArID);
            }
            else
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    if ((e.ColumnIndex == -1) && (e.RowIndex == -1))
                    {
                        GetSelectData();
                    }
                    else
                    {
                        textBox_Uriage_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        textBox_Uriagesyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                        textBox_Zyutyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString();
                        comboBox_Kokyaku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
                        comboBox_Eigyousyo_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
                        comboBox_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
                        dateTimePicker_Nitizi.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[13].Value.ToString());
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label7.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi.Enabled = false;
            dateTimePicker_Nitizi.CalendarTitleBackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textBox_Uriage_ID.Enabled = false;
            textBox_Uriage_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            comboBox_Kokyaku_Namae.Enabled = false;
            comboBox_Kokyaku_Namae.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            comboBox_Eigyousyo_Namae.Enabled = false;
            comboBox_Eigyousyo_Namae.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            textBox_Uriagesyousai_ID.Enabled = false;
            textBox_Uriagesyousai_ID.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            comboBox_Syain_Namae.Enabled = false;
            comboBox_Syain_Namae.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            textBox_Zyutyuu_ID.Enabled = false;
            textBox_Zyutyuu_ID.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi.Enabled = false;
            dateTimePicker_Nitizi.CalendarTitleBackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
        }

        private void cmbclia()
        {
            label1.ForeColor = Color.Black;
            textBox_Uriage_ID.Enabled = true;
            textBox_Uriage_ID.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            comboBox_Kokyaku_Namae.Enabled = true;
            comboBox_Kokyaku_Namae.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            comboBox_Eigyousyo_Namae.Enabled = true;
            comboBox_Eigyousyo_Namae.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            textBox_Uriagesyousai_ID.Enabled = true;
            textBox_Uriagesyousai_ID.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            comboBox_Syain_Namae.Enabled = true;
            comboBox_Syain_Namae.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            textBox_Zyutyuu_ID.Enabled = true;
            textBox_Zyutyuu_ID.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            dateTimePicker_Nitizi.Enabled = true;
            dateTimePicker_Nitizi.CalendarTitleBackColor = Color.White;
            groupBox1.ForeColor = Color.Black;
            dateTimePicker_Nitizi_2.Enabled = true;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.White;
            dateTimePicker_Nitizi_3.Enabled = true;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.White;
            label8.ForeColor = Color.Black;
        }
    }
}
