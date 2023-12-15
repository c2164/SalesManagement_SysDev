using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SalesManagement_SysDev.Entity
{
    //顧客管理画面表示用
    class DispClientDTO 
    {
        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("住所")]
        public string ClAddress { get; set; }

        [DisplayName("電話番号")]
        public string ClPhone { get; set; }

        [DisplayName("郵便番号")]
        public string ClPostal { get; set; }

        [DisplayName("FAX")]
        public string ClFAX { get; set; }

        [DisplayName("顧客管理フラグ")]
        public string ClFlag { get; set; }

        [DisplayName("非表示理由")]
        public string ClHidden { get; set; }
    }

    //社員管理画面表示用
    class DispEmplyeeDTO
    {
        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("役職ID")]
        public string PoID { get; set; }

        [DisplayName("役職名")]
        public string PoName { get; set; }

        [DisplayName("入社年月日")]
        public DateTime EmHiredate { get; set; }

        [DisplayName("パスワード")]
        public string EmPassword { get; set; }

        [DisplayName("電話番号")]
        public string EmPhone { get; set; }

        [DisplayName("社員管理フラグ")]
        public string EmFlag { get; set; }

        [DisplayName("非表示理由")]
        public string EmHidden { get; set; }
    }

    //商品管理画面表示用
    class DispProductDTO
    {
        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("メーカーID")]
        public string MaID { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("価格")]
        public string Price { get; set; }

        [DisplayName("安全在庫数")]
        public string PrSafetyStock { get; set; }

        [DisplayName("小分類ID")]
        public string ScID { get; set; }

        [DisplayName("小分類名")]
        public string ScName { get; set; }

        [DisplayName("型番")]
        public string PrModelNumber { get; set; }

        [DisplayName("色")]
        public string PrColor { get; set; }

        [DisplayName("発売日")]
        public DateTime PrReleaseDate { get; set; }

        [DisplayName("検索用発売日(開始期間)")]
        public DateTime? PrReleseFromDate { get; set; }

        [DisplayName("検索用発売日(終了期間)")]
        public DateTime? PrReleaseToDate { get; set; }

        [DisplayName("商品管理フラグ")]
        public string PrFlag { get; set; }

        [DisplayName("非表示理由")]
        public string PrHidden { get; set; }
    }

    //在庫管理画面表示用
    class DispStockDTO
    {

        [DisplayName("在庫ID")]
        public string StID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("在庫数")]
        public string StQuantity { get; set; }

        [DisplayName("在庫管理フラグ")]
        public string StFlag { get; set; }
    }

    //受注管理画面表示用
    class DispOrderDTO
    {
        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("受注詳細ID")]
        public string OrDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("数量")]
        public string OrQuantity { get; set; }

        [DisplayName("合計金額")]
        public string OrTotalPrice { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("顧客担当者名")]
        public string ClCharge { get; set; }

        [DisplayName("受注年月日")]
        public DateTime OrDate { get; set; }

        [DisplayName("受注状態フラグ")]
        public string OrStateFlag { get; set; }

        [DisplayName("受注管理フラグ")]
        public string OrFlag { get; set; }

        [DisplayName("非表示理由")]
        public string OrHidden { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("価格")]
        public string Price { get; set; }
    }

    //注文管理画面表示用
    class DispChumonDTO
    {
        [DisplayName("注文ID")]
        public string ChID { get; set; }

        [DisplayName("注文詳細ID")]
        public string ChDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("数量")]
        public string ChQuantity { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("注文年月日")]
        public DateTime ChDate { get; set; }

        [DisplayName("注文状態フラグ")]
        public string ChStateFlag { get; set; }

        [DisplayName("注文管理フラグ")]
        public string ChFlag { get; set; }

        [DisplayName("非表示理由")]
        public string ChHidden { get; set; }
    }

    //出庫管理画面表示用
    class DispSyukkoDTO
    {
        [DisplayName("出庫ID")]
        public string SyID { get; set; }

        [DisplayName("出庫詳細ID")]
        public string SyDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("数量")]
        public string SyQuantity { get; set; }

        [DisplayName("営業所")]
        public string SaleceOffice { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("注文ID")]
        public string ChID { get; set; }

        [DisplayName("注文社員ID")]
        public string ChumonEmID { get; set; }

        [DisplayName("注文社員名")]
        public string ChumonEmName { get; set; }

        [DisplayName("確定社員ID")]
        public string ConfEmID { get; set; }

        [DisplayName("確定社員名")]
        public string ConfEmName { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("出庫年月日")]
        public DateTime? SyDate { get; set; }

        [DisplayName("出庫状態フラグ")]
        public string SyStateFlag { get; set; }

        [DisplayName("出庫管理フラグ")]
        public string SyFlag { get; set; }

        [DisplayName("非表示理由")]
        public string SyHidden { get; set; }
    }

    //入荷管理画面表示用
    class DispArrivalDTO
    {
        [DisplayName("入荷ID")]
        public string ArID { get; set; }

        [DisplayName("入荷詳細ID")]
        public string ArDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("メーカーID")]
        public string MaID { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("数量")]
        public string ArQuantity { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }


        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("入荷社員ID")]
        public string ArrivalEmID { get; set; }

        [DisplayName("入荷社員名")]
        public string ArrivalEmName { get; set; }

        [DisplayName("確定社員ID")]
        public string ConfEmID { get; set; }

        [DisplayName("確定社員名")]
        public string ConfEmName { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("入荷年月日")]
        public DateTime? ArDate { get; set; }

        [DisplayName("入荷状態フラグ")]
        public string ArStateFlag { get; set; }

        [DisplayName("入荷管理フラグ")]
        public string ArFlag { get; set; }

        [DisplayName("非表示理由")]
        public string ArHidden { get; set; }
    }


    //出荷管理画面表示用
    class DispShipmentDTO
    {
        [DisplayName("出荷ID")]
        public string ShID { get; set; }

        [DisplayName("出荷詳細ID")]
        public string ShDetailID { get; set; }

        [DisplayName("メーカーID")]
        public string MaID { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("数量")]
        public string ArQuantity { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("入荷社員ID")]
        public string ArrivalEmID { get; set; }

        [DisplayName("入荷社員名")]
        public string ArrivalEmName { get; set; }

        [DisplayName("確定社員ID")]
        public string ConfEmID { get; set; }

        [DisplayName("確定社員名")]
        public string ConfEmName { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("出荷年月日")]
        public DateTime? ShDate { get; set; }

        [DisplayName("出荷状態フラグ")]
        public string ShStateFlag { get; set; }

        [DisplayName("出荷管理フラグ")]
        public string ShFlag { get; set; }

        [DisplayName("非表示理由")]
        public string ShHidden { get; set; }
    }


    //発注管理画面表示用
    class DispHattyuDTO
    {
        [DisplayName("発注ID")]
        public string HaID { get; set; }

        [DisplayName("発注詳細ID")]
        public string HaDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("メーカID")]
        public string MaID { get; set; }

        [DisplayName("メーカ名")]
        public string MaName { get; set; }

        [DisplayName("数量")]
        public string HaQuantity { get; set; }

        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("発注年月日")]
        public DateTime? HaDate { get; set; }

        [DisplayName("入庫済みフラグ")]
        public string H { get; set; }

        [DisplayName("発注管理フラグ")]
        public string HaFlag { get; set; }

        [DisplayName("非表示理由")]
        public string HaHidden { get; set; }

    }

    //入庫管理画面表示用
    class DispWarehousingDTO
    {
        [DisplayName("入庫ID")]
        public string WaID { get; set; }

        [DisplayName("入庫詳細ID")]
        public string WaDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("メーカーID")]
        public string MaID { get; set; }

        [DisplayName("メーカー名")]
        public string MaName { get; set; }

        [DisplayName("数量")]
        public string WaQuantity { get; set; }

        [DisplayName("発注ID")]
        public string HaID { get; set; }

        [DisplayName("発注社員ID")]
        public string HattyuEmID { get; set; }

        [DisplayName("発注社員名")]
        public string HattyuEmName { get; set; }

        [DisplayName("確定社員ID")]
        public string ConfEmID { get; set; }

        [DisplayName("確定社員名")]
        public string ConfEmName { get; set; }

        [DisplayName("入庫年月日")]
        public DateTime? WaDate { get; set; }

        [DisplayName("入庫済フラグ")]
        public string WaShelfFlag { get; set; }

        [DisplayName("入庫管理フラグ")]
        public string WaFlag { get; set; }

        [DisplayName("非表示理由")]
        public string WaHidden { get; set; }

    }

    //売上管理画面表示用
    class DispSaleDTO
    {
        [DisplayName("売上ID")]
        public string SaID { get; set; }

        [DisplayName("売上詳細ID")]
        public string SaDetailID { get; set; }

        [DisplayName("商品ID")]
        public string PrID { get; set; }

        [DisplayName("商品名")]
        public string PrName { get; set; }

        [DisplayName("個数")]
        public string SaQuantity { get; set; }

        [DisplayName("合計金額")]
        public string SaTotalPrice { get; set; }

        [DisplayName("顧客ID")]
        public string ClID { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("営業所ID")]
        public string SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("社員ID")]
        public string EmID { get; set; }

        [DisplayName("社員名")]
        public string EmName { get; set; }

        [DisplayName("受注ID")]
        public string OrID { get; set; }

        [DisplayName("売上日時")]
        public DateTime? SaDate { get; set; }

        [DisplayName("売上管理フラグ")]
        public string SaFlag { get; set; }

        [DisplayName("非表示理由")]
        public string SaHidden { get; set; }

        [DisplayName("検索用売上日(開始期間)")]
        public DateTime? SaReleseFromDate { get; set; }

        [DisplayName("検索用売上日(終了期間)")]
        public DateTime? SaReleaseToDate { get; set; }
    }

}
