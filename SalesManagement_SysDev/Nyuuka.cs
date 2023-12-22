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
        private DispEmplyeeDTO loginEmployee;

        public Nyuuka(DispEmplyeeDTO dispEmplyee)
        {
            loginEmployee = dispEmplyee;
            InitializeComponent();
        }

        private void Nyuuka_Load(object sender, EventArgs e)
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
            ArraivalDataAccess access = new ArraivalDataAccess();
            //入荷情報の全件取得
            List<DispArrivalDTO> tb = access.GetArrivalData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
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
            //入荷ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 70;
            //入荷詳細ID
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

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            ClientDataAccess clientDataAccess = new ClientDataAccess();

            //各テキストボックスに初期化(空白)
            textBox_Nyuuka_ID.Text = "";
            textBox_Nyuuka_Syain_Namae.Text = "";
            textBox_Zyutyuu_ID.Text = "";
            textBox_Kakutei_Syain_Namae.Text = "";
            textBox_Nyuukasyousai_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Kokyaku_Namae.DisplayMember = "ClName";
            comboBox_Kokyaku_Namae.ValueMember = "ClID";
            comboBox_Kokyaku_Namae.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku_Namae.SelectedIndex = -1;

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

            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDateAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;
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
            List<DispArrivalDTO> arrival = new List<DispArrivalDTO>();
            List<DispArrivalDTO> sortedarrival = new List<DispArrivalDTO>();

            //テーブルデータ受け取り
            arrival = GetTableData();
            if (arrival == null)
            {
                messageDsp.MessageBoxDsp_OK("入荷情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
            }

            //昇順に並び替える
            sortedarrival = SortArrivalData(arrival);

            //データグリッドビュー表示
            SetDataGridView(sortedarrival);

        }

        private List<DispArrivalDTO> GetTableData()
        {
            //変数の宣言
            List<DispArrivalDTO> arrival = new List<DispArrivalDTO>();

            //インスタンス化
            ArraivalDataAccess ArAccess = new ArraivalDataAccess();

            //データベースからデータを取得
            arrival = ArAccess.GetArrivalData();


            return arrival;
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
            DispArrivalDTO arrivalDTO = new DispArrivalDTO();
            List<DispArrivalDTO> DisplayArrival = new List<DispArrivalDTO>();

            //データの読み取り
            arrivalDTO = GetArrivalInf();
            //データの検索
            DisplayArrival = SelectArrivalInf(arrivalDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayArrival);
        }

        private DispArrivalDTO GetArrivalInf()
        {
            //変数の宣言
            DispArrivalDTO retArrivalDTO = new DispArrivalDTO();

            //各コントロールから入荷情報を読み取る
            retArrivalDTO.ClName = comboBox_Kokyaku_Namae.Text.Trim();
            retArrivalDTO.ArID = textBox_Nyuuka_ID.Text.Trim();
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retArrivalDTO.SoName = comboBox_Eigyousyo.SelectedIndex.ToString();
            retArrivalDTO.SoID = comboBox_Eigyousyo.SelectedIndex.ToString();
            retArrivalDTO.ArrivalEmName = textBox_Nyuuka_Syain_Namae.Text.Trim();
            retArrivalDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retArrivalDTO.PrName = comboBox_Syouhin_Namae.SelectedIndex.ToString();
            retArrivalDTO.PrID = comboBox_Syouhin_Namae.Text.Trim();
            retArrivalDTO.ConfEmName = textBox_Kakutei_Syain_Namae.Text.Trim();
            retArrivalDTO.ArID = textBox_Nyuukasyousai_ID.Text.Trim();
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retArrivalDTO.MaName = comboBox_Meka_Namae.SelectedIndex.ToString();
            retArrivalDTO.MaID = comboBox_Meka_Namae.Text.Trim();
            retArrivalDTO.ArQuantity = numericUpDown_Suuryou.Text.Trim();

            return retArrivalDTO;
        }

        private List<DispArrivalDTO> SelectArrivalInf(DispArrivalDTO arrivalDTO)
        {
            //変数の宣言
            List<DispArrivalDTO> retDispArrival = new List<DispArrivalDTO>();
            //インスタンス化
            ArraivalDataAccess access = new ArraivalDataAccess();

            //商品情報検索
            retDispArrival = access.GetArrivalData(arrivalDTO);
            return retDispArrival;

        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveArrival();
        }

        private void RemoveArrival()
        {
            //変数の宣言
            string ArID;
            T_Arrival arrival = new T_Arrival();
            T_ArrivalDetail ArrivalDetail = new T_ArrivalDetail();
            //データグリッドビューで選択されているデータの商品IDを受け取る
            ArID = GetArrivalRecord();
            if (ArID == null)
            {
                return;
            }

            //取得した商品IDでデータベースを検索する
            arrival = SelectRemoveArrival(ArID, out ArrivalDetail);
            if (arrival == null)
            {
                messageDsp.MessageBoxDsp_OK("入荷情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //入荷管理フラグを0から2にする
            UpdateArFlag(arrival);
        }

        private void UpdateArFlag(T_Arrival arrival)
        {
            //変数の宣言
            DialogResult result;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の商品を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //入荷管理フラグの変更
            arrival = ChangeArFlag(arrival);
            if (arrival == null)
            {
                return;
            }
            //入荷の更新
            if (UpdateArrivalRecord(arrival))
            {
                messageDsp.MessageBoxDsp_OK("対象商品を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象商品の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateArrivalRecord(T_Arrival arrival)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ArraivalDataAccess access = new ArraivalDataAccess();
            flg = access.UpdateArrivalData(arrival);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private T_Arrival ChangeArFlag(T_Arrival arrival)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            arrival.ArFlag = 2;
            arrival.ArHidden = Hidden;
            return arrival;
        }

        private T_Arrival SelectRemoveArrival(string ArID, out T_ArrivalDetail ArrivalDetail)
        {
            //変数の宣言
            T_Arrival retarrival = new T_Arrival();
            DispArrivalDTO dispArrivalDTO = new DispArrivalDTO();
            List<DispArrivalDTO> dispArrivals = new List<DispArrivalDTO>();
            ArrivalDetail = null;

            //データベースからデータを取得する
            dispArrivals = GetTableData();
            if (dispArrivals == null) //データの取得失敗
            {
                return null;
            }

            //Listの中を受け取った入荷IDで検索
            dispArrivalDTO = dispArrivals.Single(x => x.ArID == ArID);

            //検索結果を返却用にする
            retarrival = FormalizationArrivalInputRecord(dispArrivalDTO);
            ArrivalDetail = FormalizationArrivalDetaillRecord(dispArrivalDTO);

            return retarrival;
        }

        private T_Arrival FormalizationArrivalInputRecord(DispArrivalDTO dispArrivalDTO)
        {
            T_Arrival retarrival = new T_Arrival();
            retarrival.ArID = int.Parse(dispArrivalDTO.ArID);
            retarrival.SoID = int.Parse(dispArrivalDTO.SoID);
            if (dispArrivalDTO.EmID != null)
                retarrival.EmID = int.Parse(dispArrivalDTO.EmID);
            retarrival.OrID = int.Parse(dispArrivalDTO.OrID);
            retarrival.ClID = int.Parse(dispArrivalDTO.ClID);
            retarrival.ArDate = dispArrivalDTO.ArDate;
            retarrival.ArStateFlag = int.Parse(dispArrivalDTO.ArStateFlag);
            retarrival.ArFlag = int.Parse(dispArrivalDTO.ArFlag);
            retarrival.ArHidden = dispArrivalDTO.ArHidden;

            return retarrival;
        }

        private T_ArrivalDetail FormalizationArrivalDetaillRecord(DispArrivalDTO dispArrivalDTO)
        {
            T_ArrivalDetail ArrivalDetail = new T_ArrivalDetail();
            ArrivalDetail.ArDetailID = int.Parse(dispArrivalDTO.ArDetailID);
            ArrivalDetail.ArID = int.Parse(dispArrivalDTO.ArID);
            ArrivalDetail.PrID = int.Parse(dispArrivalDTO.PrID);
            ArrivalDetail.ArQuantity = int.Parse(dispArrivalDTO.ArQuantity);

            return ArrivalDetail;
        }

        private string GetArrivalRecord()
        {
            //変数の宣言
            string retArID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retArID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retArID;
        }

        private void button_Nyuuka_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionArrival();
        }

        private void DecisionArrival()
        {
            //変数の宣言
            string ArID;
            bool flg;
            T_Arrival arrival = new T_Arrival();
            List<T_ArrivalDetail> arrivalDetail = new List<T_ArrivalDetail>();
            T_Shipment shipment = new T_Shipment();
            List<T_ShipmentDetail> ListShipmentDetail = new List<T_ShipmentDetail>();

            //確定対象の入荷IDを取得
            ArID = GetArrivalRecord();

            //入荷IDから入荷情報を取得
            arrival = GetArrivalAndArDetailRecord(ArID, out arrivalDetail);
            if (arrival == null)
            {
                return;
            }

            //出荷レコードの登録
            flg = RegisrationShipmentInf(arrival, arrivalDetail);
            if (!flg)
            {
                return;
            }

            //入荷状態フラグの変更
            UpdateArStateFlag(arrival, arrivalDetail[0]);

        }

        private void UpdateArStateFlag(T_Arrival arrival, T_ArrivalDetail arrivalDetail)
        {
            //変数の宣言
            bool flg;

            //入荷状態フラグを0から1にする
            arrival = ChangeArStateFlag(arrival);
            //入荷情報を更新する
            flg = UpdateArrivalRecord(arrival);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("入荷情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("入荷情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Arrival ChangeArStateFlag(T_Arrival arrival)
        {
            arrival.ArStateFlag = 1;
            return arrival;
        }

        private bool RegisrationShipmentInf(T_Arrival arrival, List<T_ArrivalDetail> arrivalDetails)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Shipment shipment;
            List<T_ShipmentDetail> ListShipmentDetail;

            //出荷と出荷詳細のレコードを作成
            shipment = CreateShipmentInputRecord(arrival, arrivalDetails, out ListShipmentDetail);

            //出荷と出荷詳細の情報を登録
            flg = RegisrationShipmentRecord(shipment, ListShipmentDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;

        }

        private bool RegisrationShipmentRecord(T_Shipment shipment, List<T_ShipmentDetail> ListShipmentDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            //インスタンス化
            ShipmentDataAccess access = new ShipmentDataAccess();
            flg = access.RegisterShipmentData(shipment, ListShipmentDetail);

            if (!flg)
            {
                msg = "出荷情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;
        }

        private T_Arrival GetArrivalAndArDetailRecord(string arID, out List<T_ArrivalDetail> ListArrivalDetail)
        {
            //変数の宣言
            List<DispArrivalDTO> arrivalDTO = new List<DispArrivalDTO>();
            T_Arrival arrival = new T_Arrival();
            string msg;
            string title;
            MessageBoxIcon icon;
            //初期値代入
            ListArrivalDetail = new List<T_ArrivalDetail>();

            //入荷情報取得
            arrivalDTO = CreateArrivalRecord(arID, out msg, out title, out icon);
            if (arrivalDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }
            //入荷情報をテーブルデータに形式化
            arrival = FormalizationArrivalInputRecord(arrivalDTO[0]);
            foreach (var ArrivalDTO in arrivalDTO)
            {
                ListArrivalDetail.Add(FormalizationArrivalDetaillRecord(ArrivalDTO));
            }

            return arrival;

        }

        private T_Shipment CreateShipmentInputRecord(T_Arrival arrival, List<T_ArrivalDetail> ListArrivalDetail, out List<T_ShipmentDetail> ListshipmentDetail)
        {
            //変数の宣言
            T_Shipment retShipment = new T_Shipment();
            ListshipmentDetail = new List<T_ShipmentDetail>();

            //出荷レコードの作成
            retShipment.ClID = arrival.ClID;
            retShipment.EmID = null;
            retShipment.SoID = arrival.SoID;
            retShipment.OrID = arrival.OrID;
            retShipment.ShFinishDate = null;
            retShipment.ShStateFlag = 0;
            retShipment.ShFlag = 0;
            retShipment.ShHidden = null;

            //出荷詳細レコードの作成
            foreach (var arrivaldetail in ListArrivalDetail)
            {
                T_ShipmentDetail shipmentDetail = new T_ShipmentDetail();
                shipmentDetail.PrID = arrivaldetail.PrID;
                shipmentDetail.ShQuantity = arrivaldetail.ArQuantity;
                ListshipmentDetail.Add(shipmentDetail);
            }

            return retShipment;

        }

        private List<DispArrivalDTO> CreateArrivalRecord(string arID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispArrivalDTO> DispArrivals = new List<DispArrivalDTO>();
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //入荷IDの一致する入荷情報を取得
            DispArrivals = GetTableData().Where(x => x.ArID == arID).ToList();
            if (DispArrivals == null || DispArrivals.Count == 0)
            {
                msg = "入荷情報を取得できませんでした";
                title = "エラー";
                return null;
            }
            if (DispArrivals[0].ArStateFlag == "1")
            {
                msg = "既に確定済みです";
                title = "エラー";
                return null;
            }

            return DispArrivals;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

