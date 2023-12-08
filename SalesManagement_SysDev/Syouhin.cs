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
            dataGridView1.Columns[1].Width = 80;
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
            dataGridView1.Columns[5].Width = 50;
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
            dataGridView1.Columns[10].Width = 60;
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

            combobox_Syoubunnrui_ID.DisplayMember = "ScName";
            combobox_Syoubunnrui_ID.ValueMember = "ScID";
            combobox_Syoubunnrui_ID.DataSource = SCDataAccess.GetSCData();
            combobox_Syoubunnrui_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Syoubunnrui_ID.SelectedIndex = -1;

            //日付を現在の日付にする
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker_Nitizi_2.Value = DateTime.Now;
            dateTimePicker_Nitizi_3.Value = DateTime.Now;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();
            GetSelectData();
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
            if(product == null)
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
            retProductDTO.PrID = textbox_Syouhin_ID.Text.Trim();
            retProductDTO.PrName = textbox_Syouhin_Namae.Text.Trim();
            if (!(combobox_Meka_ID.SelectedIndex == -1))
                retProductDTO.MaID = combobox_Meka_ID.SelectedValue.ToString();
            retProductDTO.MaName = combobox_Syoubunnrui_ID.Text.Trim();
            if (!(combobox_Syoubunnrui_ID.SelectedIndex == -1))
                retProductDTO.ScID = combobox_Syoubunnrui_ID.SelectedIndex.ToString();
            retProductDTO.ScName = combobox_Syoubunnrui_ID.Text.Trim();
            retProductDTO.Price = textbox_Kakaku.Text.Trim();
            retProductDTO.PrSafetyStock = textbox_Anzen.Text.Trim();
            retProductDTO.PrModelNumber = textbox_Kataban.Text.Trim();
            retProductDTO.PrColor = textbox_Iro.Text.Trim();
            retProductDTO.PrReleseFromDate = dateTimePicker_Nitizi_2.Value;
            retProductDTO.PrReleaseToDate = dateTimePicker_Nitizi_3.Value;

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

            //取得した商品IDでデータベースを検索する
            product = SelectRemoveProduct(PrID);
            if (product == null)
            {
                messageDsp.MessageBoxDsp_OK("商品情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //商品管理フラグを0から2にする
            UpdatePrFlag(product);
        }

        private void UpdatePrFlag(M_Product product)
        {
            //変数の宣言
            DialogResult result;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の商品を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                return;
            }

            //商品管理フラグの変更
            product = ChangePrFlag(product);
            //商品の更新
            UpdateProductRecord(product);
        }

        private void UpdateProductRecord(M_Product product)
        {   
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ProductDataAccess access = new ProductDataAccess();
            flg = access.UpdateProductData(product);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象商品の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象商品を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private M_Product ChangePrFlag(M_Product product)
        {
            product.PrFlag = 2;
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
            if(dispProducts == null) //データの取得失敗
            {
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
            M_Product retproduct = new M_Product();
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

            retPrID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retPrID;
        }

        private void button_Sakujyo_Click(object sender, EventArgs e)
        {

        }
    }
}
