using Microsoft.VisualBasic;
using SalesManagement_SysDev.Common;
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
    public partial class Hattyuu : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        public Hattyuu()
        {
            InitializeComponent();
        }

        private void Hattyuu_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("商品情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            HattyuDataAccess access = new HattyuDataAccess();
            //商品情報の全件取得
            List<DispHattyuDTO> tb = access.GetHattyuData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            HattyuDataAccess hattyuDataAccess = new HattyuDataAccess();
            EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();

            //各テキストボックスに初期化(空白)
            textBox_Hattyuu_ID.Text = "";
            textBox_Syain_ID.Text = "";
            textBox_Syouhin_ID.Text = "";
            textBox_Suuryou.Text = "";
            textBox_Hattyuusyousai.Text = "";

            //各コンボボックスを初期化
            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = empDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex = -1;

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

            //日付を現在の日付にする
            dateTimePicker1.Value = DateTime.Now;
        }

        private void SetDataGridView(List<DispHattyuDTO> tb)
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
            //発注ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 80;
            //発注詳細ID
            dataGridView1.Columns[1].Visible = false;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[3].Width = 80;
            //メーカID
            dataGridView1.Columns[4].Visible = false;
            //メーカ名
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[5].Width = 90;
            //数量
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[6].Width = 70;
            //社員ID
            dataGridView1.Columns[7].Visible = false;
            //社員名
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[8].Width = 70;
            //発注年月日
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[9].Width = 80;
            //入庫済みフラグ
            dataGridView1.Columns[10].Visible = false;
            //発注管理フラグ
            dataGridView1.Columns[11].Visible = false;
            //非表示理由
            dataGridView1.Columns[12].Visible = false;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayHattyu();
        }

        private void ListDisplayHattyu()
        {
            List<DispHattyuDTO> hattyu = new List<DispHattyuDTO>();
            List<DispHattyuDTO> sortedhattyu = new List<DispHattyuDTO>();

            hattyu = GetTableData();

            sortedhattyu = SortHattyuData(hattyu);

            SetDataGridView(sortedhattyu);

        }

        private List<DispHattyuDTO> GetTableData()
        {
            List<DispHattyuDTO> hattyu = new List<DispHattyuDTO>();

            HattyuDataAccess hattyuDataAccess = new HattyuDataAccess();

            hattyu = hattyuDataAccess.GetHattyuData();

            return hattyu;
        }

        private List<DispHattyuDTO> SortHattyuData(List<DispHattyuDTO> dispHattyus)
        {
            dispHattyus.OrderBy(x => x.HaID);
            return dispHattyus;
        }

        private void button_Kennsaku_Click(object sender, EventArgs e)
        {
            SelectHattyu();
        }

        private void SelectHattyu()
        {
            DispHattyuDTO hattyuDTO = new DispHattyuDTO();
            List<DispHattyuDTO> displayHattyu = new List<DispHattyuDTO>();

            hattyuDTO = GetHattyuInf();

            displayHattyu = SelectHattyuInf(hattyuDTO);

            SetDataGridView(displayHattyu);
        }

        private DispHattyuDTO GetHattyuInf()
        {
            DispHattyuDTO retHattyuDTO = new DispHattyuDTO();

            //各コントロールの情報

            retHattyuDTO.HaID = textBox_Hattyuu_ID.Text.Trim();
            retHattyuDTO.EmID = textBox_Syain_ID.Text.Trim();

            if (!(comboBox_Syain_Namae.SelectedIndex == -1))
                retHattyuDTO.EmID = comboBox_Syain_Namae.SelectedValue.ToString();
            retHattyuDTO.EmName = comboBox_Syain_Namae.Text.Trim();


            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retHattyuDTO.MaID = comboBox_Meka_Namae.SelectedValue.ToString();
            retHattyuDTO.MaName = comboBox_Meka_Namae.Text.Trim();

            retHattyuDTO.PrID = textBox_Syouhin_ID.Text.Trim();

            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retHattyuDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();
            retHattyuDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();

            retHattyuDTO.HaQuantity = textBox_Suuryou.Text.Trim();
            retHattyuDTO.HaDetailID = textBox_Hattyuusyousai.Text.Trim();
            retHattyuDTO.HaDate = dateTimePicker1.Value;

            retHattyuDTO.HaFlag = "0";

            return retHattyuDTO;

        }

        private List<DispHattyuDTO> SelectHattyuInf(DispHattyuDTO HattyuDTO)
        {
            List<DispHattyuDTO> retDispHattyu = new List<DispHattyuDTO>();

            HattyuDataAccess HaAcsess = new HattyuDataAccess();

            retDispHattyu = HaAcsess.GetHattyuData(HattyuDTO);
            return retDispHattyu;

        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveHattyu();
        }

        private void RemoveHattyu()
        {
            //変数の宣言
            string HaID;
            T_Hattyu hattyu = new T_Hattyu();
            T_HattyuDetail hattyuDetail = new T_HattyuDetail();
            //データグリッドビューで選択されているデータの商品IDを受け取る
            HaID = GetHattyuRecode();

            //取得した商品IDでデータベースを検索する
            hattyu = SelectRemoveHattyu(HaID, out hattyuDetail);
            if (hattyu == null)
            {
                messageDsp.MessageBoxDsp_OK("商品情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //商品管理フラグを0から2にする
            UpdateHaFlag(hattyu, hattyuDetail);
        }

        private void UpdateHaFlag(T_Hattyu hattyu, T_HattyuDetail hattyuDetail)
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
            hattyu = ChangeHaFlg(hattyu);
            if (hattyu == null)
            {
                return;
            }
            //データの更新
            flg = UpdateHattyuRecord(hattyu, hattyuDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象のデータを非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象のデータの非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateHattyuRecord(T_Hattyu hattyu, T_HattyuDetail hattyuDetail)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            HattyuDataAccess access = new HattyuDataAccess();
            flg = access.UpdateHattyuData(hattyu, hattyuDetail);

            SetCtrlFormat();
            GetSelectData();

            return flg;


        }

        private T_Hattyu ChangeHaFlg(T_Hattyu hattyu)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }
            hattyu.HaFlag = 2;
            hattyu.HaHidden = Hidden;
            return hattyu;
        }

        private T_Hattyu SelectRemoveHattyu(string HaID, out T_HattyuDetail hattyuDetail)
        {
            //変数の宣言
            T_Hattyu rethattyu = new T_Hattyu();
            DispHattyuDTO dispHattyuDTO = new DispHattyuDTO();
            List<DispHattyuDTO> dispHattyus = new List<DispHattyuDTO>();
            hattyuDetail = null;
            //データベースからデータを取得する
            dispHattyus = GetTableData();

            if (dispHattyus == null) //データの取得失敗
            {
                return null;
            }

            //Listの中を受け取った商品IDで検索
            dispHattyuDTO = dispHattyus.Single(x => x.HaID == HaID);

            //検索結果を返却用にする
            rethattyu = FormalizationHattyuInputRecord(dispHattyuDTO);
            hattyuDetail = FormalizationHattyuDetailInputRecord(dispHattyuDTO);

            return rethattyu;
        }

        private T_Hattyu FormalizationHattyuInputRecord(DispHattyuDTO dispHattyuDTO)
        {
            T_Hattyu rethattyu = new T_Hattyu();

            if (dispHattyuDTO.HaID != "")
            {
                rethattyu.HaID = int.Parse(dispHattyuDTO.HaID);//受注ID
            }
            rethattyu.MaID = int.Parse(dispHattyuDTO.MaID);
            rethattyu.EmID = int.Parse(dispHattyuDTO.EmID);
            rethattyu.HaDate = dispHattyuDTO.HaDate.Value;
            rethattyu.HaFlag = int.Parse(dispHattyuDTO.HaFlag);
            rethattyu.HaHidden = dispHattyuDTO.HaHidden;


            return rethattyu;
        }

        private T_HattyuDetail FormalizationHattyuDetailInputRecord(DispHattyuDTO dispHattyuDTO)
        {
            T_HattyuDetail rethattyuDetail = new T_HattyuDetail();
            if (dispHattyuDTO.HaID != "")
            {
                rethattyuDetail.HaID=int.Parse(dispHattyuDTO.HaID);
            }

            if (dispHattyuDTO.HaID != "")
            {
                rethattyuDetail.HaDetailID = int.Parse(dispHattyuDTO.HaDetailID);
            }

            rethattyuDetail.PrID = int.Parse(dispHattyuDTO.PrID);
            rethattyuDetail.HaQuantity = int.Parse(dispHattyuDTO.HaQuantity);

            return rethattyuDetail;
        }

        private string GetHattyuRecode()
        {
            //変数の宣言
            string retHaID;

            retHaID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retHaID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Hattyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox_Syain_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox_Syouhin_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            textBox_Hattyuusyousai.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox_Suuryou.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            comboBox_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString());
        }

        private void button_Touroku_Click(object sender, EventArgs e)
        {
            RegisterHattyu();
        }

        private void RegisterHattyu()
        {
            string msg;
            string title;
            DialogResult result;
            MessageBoxIcon icon;
            DispHattyuDTO dispHattyuDTO = new DispHattyuDTO();

            //入力チェック済のデータを受け取る
            dispHattyuDTO = GetCheckedHattyuInf();
            //NULLなら失敗
            if (dispHattyuDTO == null)
            {
                return;
            }

            //重複チェックを行う
            if (!DuplicationCheckHattyuInputRecord(dispHattyuDTO, out msg, out title, out icon))
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

            //データ登録
            RegisrationHattyuInf(dispHattyuDTO);
        }

        private void RegisrationHattyuInf(DispHattyuDTO dispHattyuDTO)
        {
            //変数の宣言
            bool flg;
            T_Hattyu hattyu;
            T_HattyuDetail HattyuDetail;
            //インスタンス化
            HattyuDataAccess hattyuDataAccess = new HattyuDataAccess();

            //登録用データに変換
            hattyu = FormalizationHattyuInputRecord(dispHattyuDTO);
            HattyuDetail = FormalizationHattyuDetailInputRecord(dispHattyuDTO);
            //登録処理
            flg = hattyuDataAccess.RegisterHattyuData(hattyu, HattyuDetail);

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

        private T_Hattyu FormalizationHattyuInputRecord(DispHattyuDTO dispHattyu, T_HattyuDetail hattyuDetail)
        {
            //変数の宣言
            T_Hattyu hattyu = new T_Hattyu();
            T_HattyuDetail HattyuDetail = new T_HattyuDetail();

            //登録用データに形式化
            if (dispHattyu.HaID != "")
            {
                hattyu.HaID = int.Parse(dispHattyu.HaID);
                hattyuDetail.HaID = hattyu.HaID;
            }
            hattyu.MaID = int.Parse(dispHattyu.MaID);
            hattyu.EmID = int.Parse(dispHattyu.EmID);
            hattyu.HaDate = DateTime.Now;
            hattyu.HaFlag = 0;
            hattyu.HaHidden = dispHattyu.HaHidden;
            hattyuDetail.PrID = int.Parse(dispHattyu.PrID);
            hattyuDetail.HaQuantity = int.Parse(dispHattyu.HaQuantity);

            return hattyu;
        }

        private bool DuplicationCheckHattyuInputRecord(DispHattyuDTO dispHattyuDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispHattyuDTO> hattyutabledata = new List<DispHattyuDTO>();
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Question;

            //テーブルのデータを取得
            hattyutabledata = GetTableData();

            //同じ受注IDに同じ商品がないかチェックする
            flg = hattyutabledata.Any(x => x.HaID == dispHattyuDTO.HaID && x.PrID == dispHattyuDTO.PrID);
            if (flg)
            {
                msg = "同じデータが登録されているので、既にあるデータに加算しますがよろしいでしょうか？";
                title = "確認";
                return false;
            }

            return true;
        }

        private DispHattyuDTO GetCheckedHattyuInf()
        {
            //変数の宣言
            DispHattyuDTO dispHattyu = new DispHattyuDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //各コントロールから登録する受注情報を取得
            dispHattyu = GetHattyuInf();

            //取得した受注情報のデータ形式のチェック
            flg = CheckHattyuInf(dispHattyu, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return dispHattyu;

        }

        private bool CheckHattyuInf(DispHattyuDTO checkdata, out string msg, out string title, out MessageBoxIcon icon)
        {
            //チェッククラスのインスタンス化
            DataInputFormCheck inputFormCheck = new DataInputFormCheck();

            //初期値代入(返却時エラー解消のため)
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            if (string.IsNullOrEmpty(checkdata.EmName))
            {
                msg = "社員名は必須入力です";
                title = "入力エラー";
                return false;
            }
            if (string.IsNullOrEmpty(checkdata.MaName))
            {
                msg = "メーカ名は必須入力です";
                title = "入力エラー";
                return false;
            }
            if (string.IsNullOrEmpty(checkdata.PrName))
            {
                msg = "商品名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (int.Parse(checkdata.HaQuantity) <= 0)
            {
                msg = "数量には1以上を入力してください";
                title = "入力エラー";
                return false;
            }

            return true;
        }

        private void button_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionHattyu();
        }

        private void DecisionHattyu()
        {
            //変数宣言
            string HaID;
            bool flg;
            T_Hattyu hattyu = new T_Hattyu();
            List<T_HattyuDetail> hattyuDetails= new List<T_HattyuDetail>();
            T_Warehousing warehousing = new T_Warehousing();
            List<T_WarehousingDetail> warehousingDetails = new List<T_WarehousingDetail>();

            //確定対象の発注IDを取得
            HaID=GetHattyuRecode();

            //発注IDから発注情報を取得
            hattyu = GetHattyuAndDetailRecord(HaID, out hattyuDetails);
            if (hattyu == null)
            {
                return;
            }

            //入庫レコードの登録
            flg = RegisrationWarehousingInf(hattyu, hattyuDetails);
            if(!flg)
            {
                return;
            }

            UpdateHaFlagg(hattyu, hattyuDetails[0]);

        }

        private void UpdateHaFlagg(T_Hattyu hattyu,T_HattyuDetail hattyuDetail)
        {
            //変数の宣言
            bool flg;

            //入庫済みフラグを0から1にする
            hattyu = ChangeWaWarehousingFlag(hattyu);
            ///発注情報を更新
            flg = UpdateHattyuRecord (hattyu, hattyuDetail);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("発注情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("受注情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }

        }

        private T_Hattyu ChangeWaWarehousingFlag(T_Hattyu hattyu)
        {
            hattyu.WaWarehouseFlag = 1;
            return hattyu;
        }

        private bool RegisrationWarehousingInf(T_Hattyu hattyu,List<T_HattyuDetail> hattyuDetails)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Warehousing Warehousing;
            List<T_WarehousingDetail> warehousingDetail;

            //入庫と入庫詳細のレコード作成
            Warehousing = CreateWarehousingInputRecord(hattyu, hattyuDetails, out warehousingDetail);

            //注文と注文詳細の情報を登録
            flg = RegistrationWarehousingRecord(Warehousing, warehousingDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg,title, icon);
                return false;
            }

            return true;

        }

        private bool RegistrationWarehousingRecord(T_Warehousing warehousing, List<T_WarehousingDetail> warehousingDetail, out string msg,out string title, out MessageBoxIcon icon)
        {
            //変数宣言
            bool flg = false;
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            //インスタンス化
            WarehousingDataAccess access=new WarehousingDataAccess();
            flg = access.RegisterWerehousingData(warehousing, warehousingDetail);

            if(!flg)
            {
                msg = "注文情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;

        }

        private T_Hattyu GetHattyuAndDetailRecord(string  HaID,out List<T_HattyuDetail> hattyuDetail)
        {
            //変数の宣言
            List<DispHattyuDTO> hattyuDTO = new List<DispHattyuDTO>();
            T_Hattyu hattyu=new T_Hattyu();
            string msg;
            string title;
            MessageBoxIcon icon;
            //初期値代入
            hattyuDetail = new List<T_HattyuDetail>();

            //発注情報取得
            hattyuDTO = CreateHattyuRecord(HaID,out msg,out title,out icon);
            if (hattyuDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg,title,icon);
                return null;
            }

            //発注情報をテーブルデータに形式化
            hattyu = FormalizationHattyuInputRecord(hattyuDTO[0]);
            foreach (var HattyuDTO in hattyuDTO)
            {
                hattyuDetail.Add(FormalizationHattyuDetailInputRecord(HattyuDTO));
            }

            return hattyu;

        }

        private T_Warehousing CreateWarehousingInputRecord(T_Hattyu hattyu,List<T_HattyuDetail> hattyuDetails,out List<T_WarehousingDetail> warehousingDetail)
        {
            //変数の宣言
            T_Warehousing warehousing=new T_Warehousing();
            warehousingDetail = new List<T_WarehousingDetail>();

            //入庫レコードの作成

            warehousing.HaID = hattyu.HaID;
            warehousing.EmID = hattyu.EmID;
            warehousing.WaDate = DateTime.Now;
            warehousing.WaShelfFlag = 0;
            warehousing.WaFlag = 0;
            warehousing.WaHidden = null;

            //入庫詳細レコード  の作成
            foreach(var hattyudetail in hattyuDetails)
            {
                T_WarehousingDetail warehousingDetails=new T_WarehousingDetail();
                warehousingDetails.PrID = hattyudetail.PrID;
                warehousingDetails.WaQuantity = hattyudetail.HaQuantity;
                warehousingDetail.Add(warehousingDetails);
            }

            return warehousing;
        }

        private List<DispHattyuDTO> CreateHattyuRecord(string haID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispHattyuDTO> dispHattyu=new List<DispHattyuDTO>();
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //発注IDの一致する発注情報を取得
            dispHattyu=GetTableData().Where(x=>x.HaID==haID).ToList();
            if (dispHattyu == null)
            {
                msg = "発注情報を取得できませんでした";
                title = "エラー";
                return null;
            }

            return dispHattyu;
        }



    }

}