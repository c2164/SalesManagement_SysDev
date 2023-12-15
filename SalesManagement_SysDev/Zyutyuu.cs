using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Sql;
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
                messageDsp.MessageBoxDsp_OK("出荷情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }


        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            ClientDataAccess clientDataAccess = new ClientDataAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            MakerDateAccess makerDataAccess = new MakerDateAccess();
            EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();


            //各テキストボックスに初期化(空白)
            textBox_Kokyaku_Tantou.Text = "";
            textBox_Zyutyuu_ID.Text = "";
            textBox_Zyutyuusyousai_ID.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;
            comboBox_Kokyaku_Namae.DisplayMember = "ClName";
            comboBox_Kokyaku_Namae.ValueMember = "ClID";
            comboBox_Kokyaku_Namae.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku_Namae.SelectedIndex = -1;
            comboBox_Syouhin_Namae.DisplayMember = "PrName";
            comboBox_Syouhin_Namae.ValueMember = "PrID";
            comboBox_Syouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBox_Syouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syouhin_Namae.SelectedIndex = -1;
            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDataAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;
            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = employeeDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex = -1;

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
            if (!(comboBox_Kokyaku_Namae.SelectedIndex == -1))
                retOrderDTO.ClID = comboBox_Kokyaku_Namae.SelectedValue.ToString();//顧客ID
            retOrderDTO.ClName = comboBox_Kokyaku_Namae.Text.Trim();//顧客名
            retOrderDTO.ClCharge = textBox_Kokyaku_Tantou.Text.Trim();//顧客担当者
            if (!(comboBox_Syain_Namae.SelectedIndex == -1))
                retOrderDTO.EmID = comboBox_Syain_Namae.SelectedValue.ToString();//社員ID
            retOrderDTO.EmName = comboBox_Syain_Namae.Text.Trim();//社員名
            retOrderDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();//受注ID
            retOrderDTO.OrDetailID = textBox_Zyutyuusyousai_ID.Text.Trim();//受注詳細ID
            retOrderDTO.MaName = comboBox_Meka_Namae.Text.Trim();//メーカー名
            if (!(comboBox_Eigyousyo.SelectedIndex == -1)) retOrderDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所名
            retOrderDTO.SoName = comboBox_Eigyousyo.Text.Trim();
            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retOrderDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();
            retOrderDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();//商品名
            retOrderDTO.OrQuantity = numericUpDown_Suuryou.Value.ToString();//数量
            retOrderDTO.OrFlag = "0";
            retOrderDTO.OrStateFlag = "0";


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

        private void button_Touroku_Click(object sender, EventArgs e)
        {
            RegisterOrder();
        }

        private void RegisterOrder()
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult result;
            DispOrderDTO dispOrderDTO = new DispOrderDTO();

            //入力チェック済のデータを受け取る
            dispOrderDTO = GetCheckedOrderInf();
            //NULLなら失敗
            if (dispOrderDTO == null)
            {
                return;
            }

            //重複チェックを行う
            if (!DuplicationCheckOrderInputRecord(dispOrderDTO, out msg, out title, out icon))
            {
                result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //登録確認
            //須田オーダー
            result = messageDsp.MessageBoxDsp_OKCancel("登録すりゅ～？", "かくにん(はーと)", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //データを登録する
            RegisrationOrderInf(dispOrderDTO);

        }

        private void RegisrationOrderInf(DispOrderDTO dispOrderDTO)
        {
            //変数の宣言
            bool flg;
            T_Order order;
            T_OrderDetail orderDetail;
            //インスタンス化
            OrderDataAccess orderDataAccess = new OrderDataAccess();

            //登録用データに変換
            order = FormalizationOrderInputRecord(dispOrderDTO, out orderDetail);
            //登録処理
            flg = orderDataAccess.RegisterOrderData(order, orderDetail);
            if (flg)
            {
                //須田オーダー
                messageDsp.MessageBoxDsp_OK("登録したおっ！", "とろくかんりょう！", MessageBoxIcon.Information);
            }
            else
            {
                //須田オーダー
                messageDsp.MessageBoxDsp_OK("はぁ(*´Д｀)", "とうろくしっぱい...", MessageBoxIcon.Error);
            }

        }

        private T_Order FormalizationOrderInputRecord(DispOrderDTO dispOrderDTO, out T_OrderDetail orderDetail)
        {
            //変数の宣言
            T_Order order = new T_Order();
            orderDetail = new T_OrderDetail();

            //登録用データに形式化
            if (dispOrderDTO.OrID != "")
            {
                order.OrID = int.Parse(dispOrderDTO.OrID);//受注ID
                orderDetail.OrID = order.OrID;//受注詳細ID
            }
            order.SoID = int.Parse(dispOrderDTO.SoID);//営業所ID
            order.EmID = int.Parse(dispOrderDTO.EmID);//社員ID
            order.ClID = int.Parse(dispOrderDTO.ClID);//顧客ID
            order.ClCharge = dispOrderDTO.ClCharge;//顧客担当者名
            order.OrDate = DateTime.Now;//日付
            order.OrStateFlag = int.Parse(dispOrderDTO.OrStateFlag);//受注状態フラグ
            order.OrFlag = int.Parse(dispOrderDTO.OrFlag);//受注管理フラグ
            orderDetail.PrID = int.Parse(dispOrderDTO.PrID);//商品ID
            orderDetail.OrQuantity = int.Parse(dispOrderDTO.OrQuantity);//数量
            //合計金額はデータベース接続の登録処理側で行う

            return order;
        }

        private bool DuplicationCheckOrderInputRecord(DispOrderDTO dispOrderDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispOrderDTO> ordertabledata = new List<DispOrderDTO>();
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Question;

            //テーブルのデータを取得
            ordertabledata = GetTableData();

            //同じ受注IDに同じ商品がないかチェックする
            flg = ordertabledata.Any(x => x.OrID == dispOrderDTO.OrID && x.PrID == dispOrderDTO.PrID);
            if (flg)
            {
                msg = "同じ商品が登録されているので、既にあるデータに加算しますがよろしいでしょうか？";
                title = "確認";
                return false;
            }



            return true;
        }

        private DispOrderDTO GetCheckedOrderInf()
        {
            //変数の宣言
            DispOrderDTO dispOrder = new DispOrderDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //各コントロールから登録する受注情報を取得
            dispOrder = Getorderinf();

            //取得した受注情報のデータ形式のチェック
            flg = CheckOrderInf(dispOrder, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return dispOrder;

        }

        private bool CheckOrderInf(DispOrderDTO checkdata, out string msg, out string title, out MessageBoxIcon icon)
        {
            //チェッククラスのインスタンス化
            DataInputFormCheck inputFormCheck = new DataInputFormCheck();

            //初期値代入(返却時エラー解消のため)
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;


            if (String.IsNullOrEmpty(checkdata.ClName))
            {
                msg = "顧客名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.ClCharge))
            {
                msg = "顧客担当者名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.SoName))
            {
                msg = "営業所は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (!inputFormCheck.CheckNumeric(checkdata.OrID))
            {
                msg = "受注IDには半角数字を入力してください";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.PrName))
            {
                msg = "商品は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (int.Parse(checkdata.OrQuantity) <= 0)
            {
                msg = "数量には1以上を入力してください";
                title = "入力エラー";
                return false;
            }

            return true;
        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveOrder();
        }

        private void RemoveOrder()
        {
            //変数の宣言
            string OrID;
            T_Order Order = new T_Order();
            T_OrderDetail OrderDetail = new T_OrderDetail();

            //データグリッドビューに表示されているデータの受注IDを受け取る
            OrID = GetOrderRecord();
            if (OrID == null)
            {
                return;
            }


            //取得した受注IDでデータベースを検索する
            Order = SelectRemoveOrder(OrID, out OrderDetail);
            if (Order == null)
            {
                return;
            }

            //受注フラグを0から2へ変更する
            UpdateOrFlag(Order, OrderDetail);
        }

        private string GetOrderRecord()
        {
            //変数の宣言
            string retOrID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }

            retOrID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retOrID;
        }

        private T_Order SelectRemoveOrder(string OrID, out T_OrderDetail orderDetail)
        {
            //変数の宣言
            T_Order retorder = new T_Order();
            DispOrderDTO dispOrderDTO = new DispOrderDTO();
            List<DispOrderDTO> dispOrders = new List<DispOrderDTO>();
            orderDetail = null;

            //データベースからデータを取得する
            dispOrders = GetTableData();
            if (dispOrders == null)
            {
                messageDsp.MessageBoxDsp_OK("受注情報を取得できませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受けとった受注IDで検索
            dispOrderDTO = dispOrders.First(x => x.OrID == OrID);

            //検索結果を返却用にする
            retorder = FormalizationOrderInputRecord(dispOrderDTO);
            orderDetail = FormalizationOrderDetailRecord(dispOrderDTO);

            return retorder;
        }

        private T_Order FormalizationOrderInputRecord(DispOrderDTO dispOrderDTO)
        {
            T_Order retorder = new T_Order();

            retorder.OrID = int.Parse(dispOrderDTO.OrID);
            retorder.SoID = int.Parse(dispOrderDTO.SoID);
            retorder.EmID = int.Parse(dispOrderDTO.EmID);
            retorder.ClID = int.Parse(dispOrderDTO.ClID);
            retorder.ClCharge = dispOrderDTO.ClCharge;
            retorder.OrDate = dispOrderDTO.OrDate;
            retorder.OrStateFlag = int.Parse(dispOrderDTO.OrStateFlag);
            retorder.OrFlag = int.Parse(dispOrderDTO.OrFlag);
            retorder.OrHidden = dispOrderDTO.OrHidden;

            return retorder;
        }

        private T_OrderDetail FormalizationOrderDetailRecord(DispOrderDTO dispOrderDTO)
        {
            T_OrderDetail retorderDetail = new T_OrderDetail();

            retorderDetail.OrDetailID = int.Parse(dispOrderDTO.OrDetailID);
            retorderDetail.OrID = int.Parse(dispOrderDTO.OrID);
            retorderDetail.PrID = int.Parse(dispOrderDTO.PrID);
            retorderDetail.OrQuantity = int.Parse(dispOrderDTO.OrQuantity);
            retorderDetail.OrTotalPrice = int.Parse(dispOrderDTO.OrTotalPrice);

            return retorderDetail;
        }

        private void UpdateOrFlag(T_Order order, T_OrderDetail orderDetail)
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

            //受注管理フラグの変更
            order = ChangeOrFlag(order);
            if (order == null)
            {
                return;
            }

            //受注の更新
            flg = UpdateOrderRecord(order, orderDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("受注情報を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("受注情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Order ChangeOrFlag(T_Order order)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }
            order.OrFlag = 2;
            order.OrHidden = Hidden;
            return order;
        }

        private bool UpdateOrderRecord(T_Order order, T_OrderDetail orderDetail)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            OrderDataAccess access = new OrderDataAccess();
            flg = access.UpdateOrderData(order, orderDetail);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox_Kokyaku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
            textBox_Kokyaku_Tantou.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString();
            comboBox_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
            textBox_Zyutyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox_Zyutyuusyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[17].Value.ToString();
            comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            numericUpDown_Suuryou.Value = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString()); ;
        }

        private void button_Zyutyuu_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionOrder();
        }

        private void DecisionOrder()
        {
            //変数の宣言
            string OrID;
            bool flg;
            T_Order order = new T_Order();
            List<T_OrderDetail> orderDetail = new List<T_OrderDetail>();
            T_Chumon chumon = new T_Chumon();
            List<T_ChumonDetail> ListChumonDetail = new List<T_ChumonDetail>();

            //確定対象の受注IDを取得
            OrID = GetOrderRecord();

            //受注IDから受注情報を取得
            order = GetOrderAndOrDetailRecord(OrID, out orderDetail);
            if (order == null)
            {
                return;
            }

            //注文レコードの登録
            flg = RegisrationChumonInf(order, orderDetail);
            if (!flg)
            {
                return;
            }

            //受注状態フラグの変更
            UpdateOrStateFlag(order, orderDetail[0]);

        }

        private void UpdateOrStateFlag(T_Order order, T_OrderDetail orderDetail)
        {
            //変数の宣言
            bool flg;

            //受注状態フラグを0から1にする
            order = ChangeOrStateFlag(order);
            //受注情報を更新する
            flg = UpdateOrderRecord(order, orderDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("受注情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("受注情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Order ChangeOrStateFlag(T_Order order)
        {
            order.OrStateFlag = 1;
            return order;
        }

        private bool RegisrationChumonInf(T_Order order, List<T_OrderDetail> orderDetails)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Chumon chumon;
            List<T_ChumonDetail> ListChumonDetail;

            //注文と注文詳細のレコードを作成
            chumon = CreateChumonInputRecord(order, orderDetails, out ListChumonDetail);

            //注文と注文詳細の情報を登録
            flg = RegisrationChumonRecord(chumon, ListChumonDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;

        }

        private bool RegisrationChumonRecord(T_Chumon chumon, List<T_ChumonDetail> ListChumonDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            //インスタンス化
            ChumonDataAccess access = new ChumonDataAccess();
            flg = access.RegisterChumonData(chumon, ListChumonDetail);

            if (!flg)
            {
                msg = "注文情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;
        }

        private T_Order GetOrderAndOrDetailRecord(string orID, out List<T_OrderDetail> ListOrderDetail)
        {
            //変数の宣言
            List<DispOrderDTO> orderDTO = new List<DispOrderDTO>();
            T_Order order = new T_Order();
            string msg;
            string title;
            MessageBoxIcon icon;
            //初期値代入
            ListOrderDetail = new List<T_OrderDetail>();

            //受注情報取得
            orderDTO = CreateOrderRecord(orID, out msg, out title, out icon);
            if (orderDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }
            //受注情報をテーブルデータに形式化
            order = FormalizationOrderInputRecord(orderDTO[0]);
            foreach (var OrderDTO in orderDTO)
            {
                ListOrderDetail.Add(FormalizationOrderDetailRecord(OrderDTO));
            }

            return order;

        }

        private T_Chumon CreateChumonInputRecord(T_Order order, List<T_OrderDetail> ListOrderDetail, out List<T_ChumonDetail> ListchumonDetail)
        {
            //変数の宣言
            T_Chumon retChumon = new T_Chumon();
            ListchumonDetail = new List<T_ChumonDetail>();

            //注文レコードの作成
            retChumon.OrID = order.OrID;
            retChumon.EmID = null;
            retChumon.SoID = order.SoID;
            retChumon.ClID = order.ClID;
            retChumon.ChDate = DateTime.Now;
            retChumon.ChStateFlag = 0;
            retChumon.ChFlag = 0;
            retChumon.ChHidden = null;

            //注文詳細レコードの作成
            foreach (var orderdetail in ListOrderDetail)
            {
                T_ChumonDetail chumonDetail = new T_ChumonDetail();
                chumonDetail.PrID = orderdetail.PrID;
                chumonDetail.ChQuantity = orderdetail.OrQuantity;
                ListchumonDetail.Add(chumonDetail);
            }

            return retChumon;

        }

        private List<DispOrderDTO> CreateOrderRecord(string orID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispOrderDTO> DispOrders = new List<DispOrderDTO>();
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //受注IDの一致する受注情報を取得
            DispOrders = GetTableData().Where(x => x.OrID == orID).ToList();
            if (DispOrders == null)
            {
                msg = "受注情報を取得できませんでした";
                title = "エラー";
                return null;
            }
            if (DispOrders[0].OrStateFlag == "1")
            {
                msg = "既に確定済みです";
                title = "エラー";
                return null;
            }

            return DispOrders;

        }
    }
}
