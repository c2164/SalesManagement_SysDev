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
    public partial class Syukka : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        private DispEmplyeeDTO loginEmployee;
        public Syukka(DispEmplyeeDTO dispEmplyee)
        {
            InitializeComponent();
            loginEmployee = dispEmplyee;
        }

        private void Syukka_Load(object sender, EventArgs e)
        {

            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("出荷情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            ShipmentDataAccess access = new ShipmentDataAccess();
            //出荷情報の全件取得
            List<DispShipmentDTO> tb = access.GetShipmentData();
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
            ClientDataAccess clientDataAccess = new ClientDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Kakutei_Syain_Namae.Text = "";
            textBox_Nyuuka_Syain_Namae.Text = "";
            textBox_Syukkasyousai_ID.Text = "";
            textBox_Syukka_ID.Text = "";
            textBox_Zyutyuu_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

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

            comboBox_Kokyaku_Namae.DisplayMember = "ClName";
            comboBox_Kokyaku_Namae.ValueMember = "ClID";
            comboBox_Kokyaku_Namae.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku_Namae.SelectedIndex = -1;
        }

        private void SetDataGridView(List<DispShipmentDTO> tb)
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
            //出荷ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //出荷詳細ID
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 45;
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
            dataGridView1.Columns[15].Width = 30;
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
            //社員ID
            dataGridView1.Columns[20].Visible = false;
            //出荷完了年月日
            dataGridView1.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void comrareInt(int i, int k)
        {

        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayShipment();
        }

        private void ListDisplayShipment()
        {
            //変数の宣言
            List<DispShipmentDTO> shipment = new List<DispShipmentDTO>();
            List<DispShipmentDTO> sortedshipment = new List<DispShipmentDTO>();

            //テーブルデータ受け取り
            shipment = GetTableData();

            //昇順に並び替える
            sortedshipment = SortShipmentData(shipment);

            //データグリッドビュー表示
            SetDataGridView(sortedshipment);

        }

        private List<DispShipmentDTO> GetTableData()
        {
            //変数の宣言
            List<DispShipmentDTO> shipment = new List<DispShipmentDTO>();

            //インスタンス化
            ShipmentDataAccess ShAccess = new ShipmentDataAccess();

            //データベースからデータを取得
            shipment = ShAccess.GetShipmentData();


            return shipment;
        }

        private List<DispShipmentDTO> SortShipmentData(List<DispShipmentDTO> dispShipment)
        {
            //並び替え(昇順)
            dispShipment.OrderBy(x => x.PrID);
            return dispShipment;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectShipment();
        }

        private void SelectShipment()
        {
            //変数の宣言
            DispShipmentDTO shipmentDTO = new DispShipmentDTO();
            List<DispShipmentDTO> DisplayShipment = new List<DispShipmentDTO>();

            //データの読み取り
            shipmentDTO = GetShipmentInf();
            //データの検索
            DisplayShipment = SelectShipmentInf(shipmentDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayShipment);
        }

        private DispShipmentDTO GetShipmentInf()
        {
            //変数の宣言
            DispShipmentDTO retShipmentDTO = new DispShipmentDTO();

            //各コントロールから商品情報を読み取る
            retShipmentDTO.ShID = textBox_Syukka_ID.Text.Trim(); //出荷ID
            if (!(comboBox_Kokyaku_Namae.SelectedIndex == -1))
                retShipmentDTO.ClID = comboBox_Kokyaku_Namae.SelectedValue.ToString();//顧客ID
            retShipmentDTO.ClName = comboBox_Kokyaku_Namae.Text.Trim();//顧客名
            retShipmentDTO.ArrivalEmName = textBox_Nyuuka_Syain_Namae.Text.Trim(); //入荷社員名
            retShipmentDTO.ConfEmName = textBox_Kakutei_Syain_Namae.Text.Trim(); //確定社員名
            retShipmentDTO.ShDetailID = textBox_Syukkasyousai_ID.Text.Trim(); //出荷詳細ID
            retShipmentDTO.OrID = textBox_Zyutyuu_ID.Text.Trim(); //受注ID
            retShipmentDTO.ShQuantity = numericUpDown_Suuryou.Value.ToString(); //数量
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retShipmentDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所ID
            retShipmentDTO.SoName = comboBox_Eigyousyo.Text.Trim();//営業所名
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retShipmentDTO.MaID = comboBox_Meka_Namae.SelectedValue.ToString();//メーカーID
            retShipmentDTO.MaName = comboBox_Meka_Namae.Text.Trim();//メーカー名
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retShipmentDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();//商品ID
            retShipmentDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();//商品名
            retShipmentDTO.ShFlag = "0";
            retShipmentDTO.ShStateFlag = "0";
            /*if (radioButton_Mikakutei.Checked) //出荷状態フラグ
                retShipmentDTO.ShStateFlag = "0";
            else if (radioButton_Kakutei.Checked)
                retShipmentDTO.ShStateFlag = "1";
            else
                retShipmentDTO.ShStateFlag = "2";*/
            return retShipmentDTO;
        }

        private List<DispShipmentDTO> SelectShipmentInf(DispShipmentDTO shipomentDTO)
        {
            //変数の宣言
            List<DispShipmentDTO> retDispShipment = new List<DispShipmentDTO>();
            //インスタンス化
            ShipmentDataAccess access = new ShipmentDataAccess();

            //顧客情報検索
            retDispShipment = access.GetShipmentData(shipomentDTO);
            return retDispShipment;
        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveShipment();
        }

        private void RemoveShipment()
        {
            //変数の宣言
            string ShID;
            T_Shipment Shipment = new T_Shipment();
            T_ShipmentDetail ShipmentDetail = new T_ShipmentDetail();

            //データグリッドビューに表示されているデータの出荷IDを受け取る
            ShID = GetShipmentRecord();
            if (ShID == null)
            {
                return;
            }

            //取得した出荷IDでデータベースを検索する
            Shipment = SelectRemoveShipment(ShID, out ShipmentDetail);
            if (Shipment == null)
            {
                return;
            }

            //出荷フラグを0から2へ変更する
            UpdateShFlag(Shipment, ShipmentDetail);

        }

        private string GetShipmentRecord()
        {
            //変数の宣言
            string retShID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }

            retShID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retShID;
        }

        private T_Shipment SelectRemoveShipment(string ShID, out T_ShipmentDetail shipmentDetail)
        {
            //変数の宣言
            T_Shipment retshipment = new T_Shipment();
            DispShipmentDTO shipmentDTO = new DispShipmentDTO();
            List<DispShipmentDTO> disipShipments = new List<DispShipmentDTO>();
            shipmentDetail = null;

            //データベースからデータを取得する
            disipShipments = GetTableData();
            if (disipShipments == null)
            {
                messageDsp.MessageBoxDsp_OK("出荷情報を取得できませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの仲を受け取った出荷IDで検索
            shipmentDTO = disipShipments.First(x => x.ShID == ShID);

            //検索結果を返却用にする
            retshipment = FormalizationShipmentInputRecord(shipmentDTO);
            shipmentDetail = FormalizationShipmentDetailRecord(shipmentDTO);

            return retshipment;
        }

        private T_Shipment FormalizationShipmentInputRecord(DispShipmentDTO dispshipmentDTO)
        {
            T_Shipment retshipment = new T_Shipment();

            retshipment.ShID = int.Parse(dispshipmentDTO.ShID);
            retshipment.ClID = int.Parse(dispshipmentDTO.ClID);
            if (!String.IsNullOrEmpty(dispshipmentDTO.EmID))
                retshipment.EmID = int.Parse(dispshipmentDTO.EmID);
            retshipment.SoID = int.Parse(dispshipmentDTO.SoID);
            retshipment.OrID = int.Parse(dispshipmentDTO.OrID);
            retshipment.ShStateFlag = int.Parse(dispshipmentDTO.ShStateFlag);
            retshipment.ShFinishDate = dispshipmentDTO.ShFinishDate;
            retshipment.ShFlag = int.Parse(dispshipmentDTO.ShFlag);
            retshipment.ShHidden = dispshipmentDTO.ShHidden;

            return retshipment;
        }

        private T_ShipmentDetail FormalizationShipmentDetailRecord(DispShipmentDTO shipmentDTO)
        {
            T_ShipmentDetail retshipmentDetail = new T_ShipmentDetail();

            retshipmentDetail.ShDetailID = int.Parse(shipmentDTO.ShDetailID);
            retshipmentDetail.ShID = int.Parse(shipmentDTO.ShID);
            retshipmentDetail.PrID = int.Parse(shipmentDTO.PrID);
            retshipmentDetail.ShQuantity = int.Parse(shipmentDTO.ShQuantity);

            return retshipmentDetail;
        }

        private void UpdateShFlag(T_Shipment shipment, T_ShipmentDetail shipmentDetail)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示の実行
            result = messageDsp.MessageBoxDsp_OKCancel("非表示にしてよろしいですか", "エラー", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //出荷状態フラグの変更
            shipment = ChangeShFlag(shipment);
            if (shipment == null)
            {
                return;
            }

            //出荷の更新
            flg = UpdateShipmentRecord(shipment, shipmentDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("出荷情報を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("出荷情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Shipment ChangeShFlag(T_Shipment shipment)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }
            shipment.ShFlag = 2;
            shipment.ShHidden = Hidden;
            return shipment;
        }

        private bool UpdateShipmentRecord(T_Shipment shipment, T_ShipmentDetail shipmentDetail)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ShipmentDataAccess access = new ShipmentDataAccess();
            flg = access.UpdateShipmentData(shipment, shipmentDetail);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private void button_Syukka_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionShipment();
        }

        private void DecisionShipment()
        {
            //変数の宣言
            string ShID;
            bool flg;
            T_Shipment shipment = new T_Shipment();
            List<T_ShipmentDetail> shipmentDetail = new List<T_ShipmentDetail>();
            T_Sale sale = new T_Sale();
            List<T_SaleDetail> saleDetail = new List<T_SaleDetail>();
            DialogResult result;

            //確定対象の出荷IDを取得
            ShID = GetShipmentRecord();

            //出荷IDから出荷情報を取得
            shipment = GetShipmentAndShipmentDetailRecord(ShID, out shipmentDetail);
            if (shipment == null)
            {
                return;
            }

            //確定確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の注文を確定してもよろしいですか？", "確定確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //売上レコードに登録
            flg = RegisrationSaleInf(shipment, shipmentDetail);
            if (!flg)
            {
                return;
            }

            //出荷状態フラグの変更
            UpdateShStateFlag(shipment, shipmentDetail[0]);
        }

        private T_Shipment GetShipmentAndShipmentDetailRecord(string shID, out List<T_ShipmentDetail> ListShipmentDetail)
        {
            //変数の宣言
            List<DispShipmentDTO> shipmentDTO = new List<DispShipmentDTO>();
            T_Shipment shipment = new T_Shipment();
            string msg;
            string title;
            MessageBoxIcon icon;

            //初期値代入
            ListShipmentDetail = new List<T_ShipmentDetail>();

            //出荷情報取得
            shipmentDTO = CreateShipmentRecord(shID, out msg, out title, out icon);
            if (shipmentDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            //出荷情報をテーブルデータに形式化
            shipment = FormalizationShipmentInputRecord(shipmentDTO[0]);
            foreach (var ShipmentDTO in shipmentDTO)
            {
                ListShipmentDetail.Add(FormalizationShipmentDetailRecord(ShipmentDTO));
            }

            return shipment;
        }

        private List<DispShipmentDTO> CreateShipmentRecord(string shID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispShipmentDTO> dispShipments = new List<DispShipmentDTO>();

            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //出荷IDの一致する出荷情報を取得
            dispShipments = GetTableData().Where(x => x.ShID == shID).ToList();
            if (dispShipments == null || dispShipments.Count == 0)
            {
                msg = "出荷情報を取得できませんでした";
                title = "エラー";
                return null;
            }
            if (dispShipments[0].ShStateFlag == "1")
            {
                msg = "既に確定済みです";
                title = "エラー";
                return null;
            }

            return dispShipments;
        }

        private bool RegisrationSaleInf(T_Shipment shipment, List<T_ShipmentDetail> shipmentDetails)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Sale sale;
            List<T_SaleDetail> ListSaleDetail;

            //売上と売上詳細のレコードを作成
            sale = CreateSaleInputRecord(shipment, shipmentDetails, out ListSaleDetail);

            //売上と売上詳細の情報を登録
            flg = RegisrationSaleRecord(sale, ListSaleDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;
        }

        private T_Sale CreateSaleInputRecord(T_Shipment shipment, List<T_ShipmentDetail> ListShipmentDetail, out List<T_SaleDetail> ListSaleDetail)
        {
            //変数の宣言
            T_Sale retSale = new T_Sale();
            ListSaleDetail = new List<T_SaleDetail>();
            ProductDataAccess access = new ProductDataAccess();

            //売上レコードの作成
            retSale.ClID = shipment.ClID;
            retSale.SoID = shipment.SoID;
            retSale.EmID = int.Parse(loginEmployee.EmID);//営業担当の社員IDにする
            retSale.ChID = shipment.ClID;
            retSale.SaDate = DateTime.Now;//売上処理がされた日付にする
            retSale.SaHidden = shipment.ShHidden;
            retSale.SaFlag = shipment.ShFlag;

            //売上詳細レコードの作成
            foreach (var saledetail in ListShipmentDetail)
            {
                T_SaleDetail saleDetail = new T_SaleDetail();
                saleDetail.PrID = saledetail.PrID;
                saleDetail.SaQuantity = saledetail.ShQuantity;
                saleDetail.SaTotalPrice = saledetail.ShQuantity * decimal.Parse(access.GetProductData().Single(x => x.PrID == saledetail.PrID.ToString()).Price);
                ListSaleDetail.Add(saleDetail);
            }

            return retSale;
        }

        private bool RegisrationSaleRecord(T_Sale sale, List<T_SaleDetail> ListSaleDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;

            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //インスタンス化
            SaleDataAccess access = new SaleDataAccess();

            flg = access.RegisterSaleData(sale, ListSaleDetail);
            if (!flg)
            {
                msg = "売上情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;
        }

        private void UpdateShStateFlag(T_Shipment shipment, T_ShipmentDetail shipmentDetail)
        {
            //変数の宣言
            bool flg;

            //出荷状態フラグを0から1にする
            shipment = ChangeShipmentFlag(shipment);

            //出荷情報を更新する
            flg = UpdateShipmentRecord(shipment, shipmentDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("出荷情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("受注情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Shipment ChangeShipmentFlag(T_Shipment shipment)
        {
            shipment.ShStateFlag = 1;
            shipment.EmID = int.Parse(loginEmployee.EmID);
            shipment.ShFinishDate = DateTime.Now;
            return shipment;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_Kokyaku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[14].Value.ToString();
            textBox_Syukka_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            textBox_Nyuuka_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
            textBox_Zyutyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[15].Value.ToString();
            comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value != null)
                textBox_Kakutei_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString();
            else
            {
                textBox_Kakutei_Syain_Namae.Text = "";
            }
            textBox_Syukkasyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            numericUpDown_Suuryou.Value = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString());
        }
    }
}
