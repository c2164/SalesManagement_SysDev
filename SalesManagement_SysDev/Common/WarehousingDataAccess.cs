using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class WarehousingDataAccess
    {
        //入庫情報登録(登録情報)
        public bool RegisterClientData(T_Warehousing RegWerehousing)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Warehousings.Add(RegWerehousing);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        //入庫情報アップデート(アップデート情報)
        public bool UpdateClinetData(T_Warehousing UpWarehousing)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Warehousings.Single(x => x.WaID == UpWarehousing.WaID);
                    UpdateTarget = UpWarehousing;

                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        //入庫検索(検索項目)：オーバーロード
        public List<DispWerehousingDTO> GetWarehousingData(DispWerehousingDTO dispWarehousingDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Werehousing」テーブルから「M_SalesOffice」「M_Employee] 「M_Client] [T_Order]を参照
                var tb = from WarehousingDetail in context.T_WarehousingDetails
                         join Warehousing in context.T_Warehousings
                         on WarehousingDetail.WaID equals Warehousing.WaID
                         join Product in context.M_Products
                         on WarehousingDetail.PrID equals Product.PrID
                         join Hattyuu in context.T_Hattyus
                         on Warehousing.HaID equals Hattyuu.HaID
                         join Employee in context.M_Employees
                         on Warehousing.EmID equals Employee.EmID
                         where
                          ((dispWarehousingDTO.WaID == "") ? true :
                         Warehousing.WaID == int.Parse(dispWarehousingDTO.WaID)) &&//入庫ID
                          ((dispWarehousingDTO.WaID == "") ? true :
                         Hattyuu.HaID == int.Parse(dispWarehousingDTO.HaID)) && //発注ID
                          ((dispWarehousingDTO.WaID == "") ? true :
                         WarehousingDetail.WaDetailID == int.Parse(dispWarehousingDTO.WaID)) && //入庫詳細ID
                         Hattyuu.EmID.Contains(dispWarehousingDTO.EmName) && //発注社員名
                         Employee.EmID.ToString().Contains(dispWarehousingDTO.ConfEmName) && //確定社員名
                         Maker.MaName.Contains(dispWarehousingDTO.MaName) && //メーカー名
                         Product.PrName.Contains(dispWarehousingDTO.PrName) && //商品名
                         WarehousingDetail.ToString().Contains(dispWarehousingDTO.ArQuantity) && //数量



                         select new DispArrivalDTO
                         {
                             ArID = Arrival.ArID.ToString(),
                             ArDetailID = ArrivalDetail.ArDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             ArQuantity = ArrivalDetail.ArQuantity.ToString(),
                             SoID = Arrival.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ArrivalEmID = Chumon.ClID.ToString(),
                             ArrivalEmName = ChumonEm.EmName.ToString(),
                             ConfEmID = Arrival.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             ClID = Arrival.ClID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Arrival.OrID.ToString(),
                             ArDate = Arrival.ArDate,
                             ArStateFlag = Arrival.ArStateFlag.ToString()

                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //入庫全表示：オーバーロード
        public List<DispProductDTO> GetProductData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「M_Product」テーブルから「M_SmallClassfication」「M_Maker」を参照
                var tb = from Product in context.M_Products
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         join SmallClassification in context.M_SmallClassifications
                         on Product.ScID equals SmallClassification.ScID
                         join MajorCassifications in context.M_MajorCassifications
                         on SmallClassification.McID equals MajorCassifications.McID

                         where
                         Product.PrFlag == 0 //非表示フラグ

                         select new DispProductDTO
                         {
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName,
                             Price = Product.Price.ToString(),
                             PrSafetyStock = Product.PrSafetyStock.ToString(),
                             ScID = Product.ScID.ToString(),
                             ScName = SmallClassification.ScName,
                             PrModelNumber = Product.PrModelNumber,
                             PrColor = Product.PrColor,
                             PrReleaseDate = Product.PrReleaseDate,
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("在庫データ取得時に例外エラーが発生しました", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
    }
}

