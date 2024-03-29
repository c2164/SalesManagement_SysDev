﻿using SalesManagement_SysDev.Common;
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
    public partial class Syouhin : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        public Syouhin()
        {
            InitializeComponent();
        }

        private void Syouhin_Load(object sender, EventArgs e)
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
            ProductDataAccess access = new ProductDataAccess();
            //商品情報の全件取得
            List<DispProductDTO> tb = access.GetProductData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetDataGridView(List<DispProductDTO> tb)
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
            //商品ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //商品名
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 95;
            //メーカーID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //メーカー名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //価格
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 80;
            //安全在庫数
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 60;
            //小分類ID(非表示)
            dataGridView1.Columns[6].Visible = false;
            //小分類名
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].Width = 120;
            //型番
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 55;
            //色
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 30;
            //発売日
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].Width = 67;
            //検索用発売日(開始期間)(非表示)
            dataGridView1.Columns[11].Visible = false;
            //検索用発売日(終了期間)(非表示)
            dataGridView1.Columns[12].Visible = false;
            //顧客管理フラグ(非表示)
            dataGridView1.Columns[13].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[14].Visible = false;

        }

        private void SetCtrlFormat()
        {
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            SmallClassificationDataAccess SCDataAccess = new SmallClassificationDataAccess();

            //各テキストボックスに初期化(空白)
            textbox_Syouhin_ID.Text = "";
            textbox_Syouhin_Namae.Text = "";
            textbox_Kataban.Text = "";
            textbox_Anzen.Text = "";
            textbox_Iro.Text = "";
            textbox_Kakaku.Text = "";


            //各コンボボックスを初期化
            combobox_Meka_ID.DisplayMember = "MaName";
            combobox_Meka_ID.ValueMember = "MaID";
            combobox_Meka_ID.DataSource = makerDateAccess.GetMakerData();
            combobox_Meka_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Meka_ID.SelectedIndex = -1;

            combobox_Syoubunnrui_Namae.DisplayMember = "ScName";
            combobox_Syoubunnrui_Namae.ValueMember = "ScID";
            combobox_Syoubunnrui_Namae.DataSource = SCDataAccess.GetSCData();
            combobox_Syoubunnrui_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Syoubunnrui_Namae.SelectedIndex = -1;

            //日付を現在の日付にする
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker_Nitizi_2.Value = DateTime.Now;
            dateTimePicker_Nitizi_3.Value = DateTime.Now;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();
            GetSelectData();
            cmbclia();
        }

        private void button_Itiran_Click(object sender, EventArgs e)
        {
            ListDisplayProduct();
        }

        private void ListDisplayProduct()
        {
            //変数の宣言
            List<DispProductDTO> product = new List<DispProductDTO>();
            List<DispProductDTO> sortedproduct = new List<DispProductDTO>();

            //テーブルデータ受け取り
            product = GetTableData();
            if (product == null)
            {
                messageDsp.MessageBoxDsp_OK("商品情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
            }

            //昇順に並び替える
            sortedproduct = SortProductData(product);

            //データグリッドビュー表示
            SetDataGridView(sortedproduct);

        }

        private List<DispProductDTO> GetTableData()
        {
            //変数の宣言
            List<DispProductDTO> product = new List<DispProductDTO>();

            //インスタンス化
            ProductDataAccess PrAccess = new ProductDataAccess();

            //データベースからデータを取得
            product = PrAccess.GetProductData();


            return product;
        }

        private List<DispProductDTO> SortProductData(List<DispProductDTO> dispProducts)
        {
            //並び替え(昇順)
            dispProducts.OrderBy(x => x.PrID);
            return dispProducts;
        }

        private void button_Kennsaku_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void SelectProduct()
        {
            //変数の宣言
            DispProductDTO productDTO = new DispProductDTO();
            List<DispProductDTO> DisplayProduct = new List<DispProductDTO>();

            //データの読み取り
            productDTO = GetProductInf();
            //データの検索
            DisplayProduct = SelectProductInf(productDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayProduct);
        }

        private DispProductDTO GetProductInf()
        {
            //変数の宣言
            DispProductDTO retProductDTO = new DispProductDTO();

            //各コントロールから商品情報を読み取る
            retProductDTO.PrID = textbox_Syouhin_ID.Text.Trim();//商品ID

            retProductDTO.PrName = textbox_Syouhin_Namae.Text.Trim();//商品名

            if (!(combobox_Meka_ID.SelectedIndex == -1))
                retProductDTO.MaID = combobox_Meka_ID.SelectedValue.ToString();//メーカーID

            retProductDTO.MaName = combobox_Meka_ID.Text.Trim();//メーカー名

            if (!(combobox_Syoubunnrui_Namae.SelectedIndex == -1))
                retProductDTO.ScID = combobox_Syoubunnrui_Namae.SelectedValue.ToString();//小分類ID

            retProductDTO.ScName = combobox_Syoubunnrui_Namae.Text.Trim();//小分類名

            retProductDTO.Price = textbox_Kakaku.Text.Trim();//価格

            retProductDTO.PrSafetyStock = textbox_Anzen.Text.Trim();//安全在庫数

            retProductDTO.PrModelNumber = textbox_Kataban.Text.Trim();//型番

            retProductDTO.PrColor = textbox_Iro.Text.Trim();//色

            retProductDTO.PrReleaseDate = dateTimePicker1.Value;//発売日

            retProductDTO.PrReleseFromDate = dateTimePicker_Nitizi_2.Value;//検索日時(から)

            retProductDTO.PrReleaseToDate = dateTimePicker_Nitizi_3.Value;//検索日時(まで)

            retProductDTO.PrFlag = "0";
            //retProductDTO.PrHidden = null;
            return retProductDTO;
        }

        private List<DispProductDTO> SelectProductInf(DispProductDTO productDTO)
        {
            //変数の宣言
            List<DispProductDTO> retDispProduct = new List<DispProductDTO>();
            //インスタンス化
            ProductDataAccess access = new ProductDataAccess();

            //商品情報検索
            retDispProduct = access.GetProductData(productDTO);
            return retDispProduct;

        }

        private void button_Sakujyo_Click(object sender, EventArgs e)
        {
            RemoveProduct();
        }

        private void RemoveProduct()
        {
            //変数の宣言
            string PrID;
            M_Product product = new M_Product();
            //データグリッドビューで選択されているデータの商品IDを受け取る
            PrID = GetProductRecord();
            if (PrID == null)
            {
                return;
            }

            //取得した商品IDでデータベースを検索する
            product = SelectRemoveProduct(PrID);
            if (product == null)
            {
                return;
            }

            //商品管理フラグを0から2にする
            UpdatePrFlag(product);
        }

        private void UpdatePrFlag(M_Product product)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の商品を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //商品管理フラグの変更
            product = ChangePrFlag(product);
            if (product == null)
            {
                return;
            }
            //商品の更新
            flg = UpdateProductRecord(product);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象商品の情報を更新しました", "完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("商品情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateProductRecord(M_Product product)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ProductDataAccess access = new ProductDataAccess();
            flg = access.UpdateProductData(product);

            SetCtrlFormat();
            GetSelectData();

            return flg;

        }

        private M_Product ChangePrFlag(M_Product product)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            product.PrFlag = 2;
            product.PrHidden = Hidden;
            return product;
        }

        private M_Product SelectRemoveProduct(string PrID)
        {
            //変数の宣言
            M_Product retproduct = new M_Product();
            DispProductDTO dispProductDTO = new DispProductDTO();
            List<DispProductDTO> dispProducts = new List<DispProductDTO>();
            //データベースからデータを取得する
            dispProducts = GetTableData();
            if (dispProducts == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("商品情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った商品IDで検索
            dispProductDTO = dispProducts.Single(x => x.PrID == PrID);

            //検索結果を返却用にする
            retproduct = FormalizationProductInputRecord(dispProductDTO);

            return retproduct;
        }

        private M_Product FormalizationProductInputRecord(DispProductDTO dispProductDTO)
        {
            //変数の宣言
            M_Product retproduct = new M_Product();

            //表示用からテーブル用にする
            retproduct.PrID = int.Parse(dispProductDTO.PrID);
            retproduct.PrName = dispProductDTO.PrName;
            retproduct.MaID = int.Parse(dispProductDTO.MaID);
            retproduct.Price = decimal.Parse(dispProductDTO.Price);
            retproduct.PrSafetyStock = int.Parse(dispProductDTO.PrSafetyStock);
            retproduct.ScID = int.Parse(dispProductDTO.ScID);
            retproduct.PrModelNumber = dispProductDTO.PrModelNumber;
            retproduct.PrColor = dispProductDTO.PrColor;
            retproduct.PrReleaseDate = dispProductDTO.PrReleaseDate;
            retproduct.PrFlag = int.Parse(dispProductDTO.PrFlag);
            retproduct.PrHidden = dispProductDTO.PrHidden;

            return retproduct;
        }

        private string GetProductRecord()
        {
            //変数の宣言
            string retPrID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retPrID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retPrID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textbox_Syouhin_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textbox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textbox_Kakaku.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textbox_Anzen.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textbox_Kataban.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            textbox_Iro.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
            combobox_Meka_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            combobox_Syoubunnrui_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString());
        }

        private void button_Kousin_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            //変数の宣言
            string PrID;
            DispProductDTO dispProductDTO = new DispProductDTO();
            bool flg;
            //チェック済みの入力情報を得る
            dispProductDTO = GetCheckedProductInf();
            PrID = GetProductRecord();
            if (dispProductDTO == null)
            {
                return;
            }
            //存在チェック
            flg = ExistsCheck(dispProductDTO);
            if (!flg)
            {
                return;
            }
            //入力情報で商品情報を更新する
            UpdateProductInf(dispProductDTO);
        }

        private void UpdateProductInf(DispProductDTO dispProductDTO)
        {
            //変数の宣言
            M_Product UpProduct = new M_Product();
            bool flg;

            //表示用データからテーブル用データに変換
            UpProduct = FormalizationProductInputRecord(dispProductDTO);
            flg = UpdateProductRecord(UpProduct);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("商品情報の更新に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象商品の情報を更新しました", "完了", MessageBoxIcon.Information);
            }


        }

        private bool ExistsCheck(DispProductDTO checkDispProduct)
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult Result = DialogResult.OK;

            //存在チェック
            ExistsCheckProductInputRecord(checkDispProduct, out msg, out title, out icon);

            Result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
            if (Result == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void ExistsCheckProductInputRecord(DispProductDTO checkDispProduct, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            List<DispProductDTO> dispProduct = new List<DispProductDTO>();
            ProductDataAccess access = new ProductDataAccess();

            //テーブルのデータを取得
            dispProduct = access.GetProductData();

            //ID以外が同じ内容か確認
            flg = dispProduct.Any(x => x.PrName == checkDispProduct.PrName && x.MaID == checkDispProduct.MaID && x.ScID == checkDispProduct.ScID && x.Price == checkDispProduct.Price && x.PrSafetyStock == checkDispProduct.PrSafetyStock && x.PrModelNumber == checkDispProduct.PrModelNumber && x.PrColor == checkDispProduct.PrColor && x.PrReleaseDate == checkDispProduct.PrReleaseDate);
            if (flg)
            {
                msg = "既に同じ内容のデータが存在します\n本当に更新してもよろしいですか？";
                title = "警告";
                icon = MessageBoxIcon.Warning;
            }
            else
            {
                msg = "データを更新してもよろしいですか";
                title = "更新確認";
                icon = MessageBoxIcon.Information;
            }

        }

        private DispProductDTO GetCheckedProductInf()
        {
            //変数の宣言
            DispProductDTO retDispProduct = new DispProductDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //入力情報を取得
            retDispProduct = GetProductInf();
            //入力チェック
            flg = CheckProductInf(retDispProduct, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return retDispProduct;

        }

        private bool CheckProductInf(DispProductDTO checklDispProduct, out string msg, out string title, out MessageBoxIcon icon)
        {
            //インスタンス化
            DataInputFormCheck formCheck = new DataInputFormCheck();

            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //商品名のチェック
            if (String.IsNullOrEmpty(checklDispProduct.PrName))
            {
                msg = "商品名は必須入力です";
                title = "入力エラー";
                return false;
            }

            //メーカー名のチェック
            if (combobox_Meka_ID.SelectedIndex == -1)
            {
                msg = "メーカーを選択してください";
                title = "入力エラー";
                return false;
            }

            //小分類名のチェック
            if (combobox_Syoubunnrui_Namae.SelectedIndex == -1)
            {
                msg = "小分類名を選択してください";
                title = "入力エラー";
                return false;
            }

            //価格のチェック
            if (!String.IsNullOrEmpty(checklDispProduct.Price))
            {
                if (!formCheck.CheckPrice(checklDispProduct.Price))
                {
                    msg = "価格には半角数字を入力してください";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "価格は必須入力です";
                title = "入力エラー";
                return false;
            }

            //安全在庫数のチェック
            if (!String.IsNullOrEmpty(checklDispProduct.PrSafetyStock))
            {
                if (!formCheck.CheckNumeric(checklDispProduct.PrSafetyStock))
                {
                    msg = "安全在庫数には半角数字を入力してください";
                    title = "入力エラー";
                    return false;
                }

            }
            else
            {
                msg = "安全在庫数は必須入力です";
                title = "入力エラー";
                return false;
            }

            //型番のチェック
            if (String.IsNullOrEmpty(checklDispProduct.PrModelNumber))
            {
                msg = "型番は必須入力です";
                title = "入力エラー";
                return false;
            }

            //色のチェック
            if (String.IsNullOrEmpty(checklDispProduct.PrColor))
            {
                msg = "色は必須入力です";
                title = "入力エラー";
                return false;
            }



            return true;
        }


        private void button_Touroku_Click(object sender, EventArgs e)
        {
            RegisterProduct();
        }

        private void RegisterProduct()
        {
            //変数の宣言
            DispProductDTO dispProductDTO = new DispProductDTO();
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult result;

            //チェック済みデータの取得
            dispProductDTO = GetCheckedProductInf();
            if (dispProductDTO == null)
            {
                return;
            }
            dispProductDTO.PrID = "0";

            if (!DuplicationCheckProductInputRecord(dispProductDTO, out msg, out title, out icon))
            {
                result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //登録確認
            result = messageDsp.MessageBoxDsp_OKCancel("登録しますか?", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //データを登録する
            RegisrationProductInf(dispProductDTO);
        }

        private bool DuplicationCheckProductInputRecord(DispProductDTO productDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispProductDTO> productTabledeta = new List<DispProductDTO>();
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Question;

            //テーブルのデータを取得
            productTabledeta = GetTableData();

            //商品IDに同じ商品がないかチェックする
            flg = productTabledeta.Any(x => x.PrName == productDTO.PrName && x.MaID == productDTO.MaID && x.ScID == productDTO.ScID && x.Price == productDTO.Price && x.PrSafetyStock == productDTO.PrSafetyStock && x.PrModelNumber == productDTO.PrModelNumber && x.PrColor == productDTO.PrColor && x.PrReleaseDate == productDTO.PrReleaseDate);
            if (flg)
            {
                msg = "同じ商品が登録されていますがよろしいですか?";
                title = "確認";
                return false;
            }

            return true;
        }

        private void RegisrationProductInf(DispProductDTO dispProductDTO)
        {
            //変数の宣言
            bool flg;
            M_Product product;

            //インスタンス化
            ProductDataAccess productDataAccess = new ProductDataAccess();

            //登録用にデータに変換
            product = FormalizationProductInputRecord(dispProductDTO);

            //登録処理
            flg = productDataAccess.RegisterProductData(product);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("登録しました", "登録完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("失敗しました", "登録失敗", MessageBoxIcon.Error);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textbox_Syouhin_ID.Enabled = false;
            textbox_Syouhin_ID.BackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.CalendarTitleBackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textbox_Syouhin_ID.Enabled = false;
            textbox_Syouhin_ID.BackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label9.ForeColor = Color.LightGray;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.CalendarTitleBackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textbox_Syouhin_ID.Enabled = false;
            textbox_Syouhin_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            textbox_Syouhin_Namae.Enabled = false;
            textbox_Syouhin_Namae.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            combobox_Meka_ID.Enabled = false;
            combobox_Meka_ID.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            combobox_Syoubunnrui_Namae.Enabled = false;
            combobox_Syoubunnrui_Namae.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textbox_Kakaku.Enabled = false;
            textbox_Kakaku.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            textbox_Anzen.Enabled = false;
            textbox_Anzen.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            textbox_Kataban.Enabled = false;
            textbox_Kataban.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            textbox_Iro.Enabled = false;
            textbox_Iro.BackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.CalendarTitleBackColor = Color.LightGray;
            groupBox1.ForeColor = Color.LightGray;
            dateTimePicker_Nitizi_2.Enabled = false;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.LightGray;
            dateTimePicker_Nitizi_3.Enabled = false;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
        }

        private void cmbclia()
        {
            label1.ForeColor = Color.Black;
            textbox_Syouhin_ID.Enabled = true;
            textbox_Syouhin_ID.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            textbox_Syouhin_Namae.Enabled = true;
            textbox_Syouhin_Namae.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            combobox_Meka_ID.Enabled = true;
            combobox_Meka_ID.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            combobox_Syoubunnrui_Namae.Enabled = true;
            combobox_Syoubunnrui_Namae.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            textbox_Kakaku.Enabled = true;
            textbox_Kakaku.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            textbox_Anzen.Enabled = true;
            textbox_Anzen.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            textbox_Kataban.Enabled = true;
            textbox_Kataban.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            textbox_Iro.Enabled = true;
            textbox_Iro.BackColor = Color.White;
            label9.ForeColor = Color.Black;
            dateTimePicker1.Enabled = true;
            dateTimePicker1.CalendarTitleBackColor = Color.White;
            groupBox1.ForeColor = Color.Black;
            dateTimePicker_Nitizi_2.Enabled = true;
            dateTimePicker_Nitizi_2.CalendarTitleBackColor = Color.White;
            dateTimePicker_Nitizi_3.Enabled = true;
            dateTimePicker_Nitizi_3.CalendarTitleBackColor = Color.White;
            label10.ForeColor = Color.Black;
        }
    }
}
