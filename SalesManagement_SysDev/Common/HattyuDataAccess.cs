using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class HattyuDataAccess
    {
        public bool RegisterHattyuData(T_Hattyu RegHattyu,T_HattyuDetail HattyuDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    int HaID = RegHattyu.HaID;
                    if (!context.T_Hattyus.Any(x => x.HaID == HaID))
                    {
                        context.T_Hattyus.Add(RegHattyu);
                        context.SaveChanges();
                        HaID = context.T_Hattyus.Max(x => x.HaID);
                    }
                    HattyuDetail.HaID=HaID;
                    context.T_HattyuDetails.Add(HattyuDetail);
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

        public bool UpdateHattyuData(T_Hattyu UpHattyu,T_HattyuDetail UpHattyuDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {

                    var UpdateTarget = context.T_Hattyus.Single(x => x.HaID == UpHattyu.HaID);
                    UpdateTarget.HaID = UpHattyu.HaID;
                    UpdateTarget.MaID=UpHattyu.MaID;
                    UpdateTarget.EmID=UpHattyu.EmID;
                    UpdateTarget.WaWarehouseFlag=UpHattyu.WaWarehouseFlag;
                    UpdateTarget.HaFlag=UpHattyu.HaFlag;
                    UpdateTarget.HaHidden=UpHattyu.HaHidden;

                    var UpdateTarget2 = context.T_HattyuDetails.Single(x => x.HaID == UpHattyu.HaID);
                    UpdateTarget2.HaDetailID = UpHattyuDetail.HaDetailID;
                    UpdateTarget2.HaID=UpHattyuDetail.HaID;
                    UpdateTarget2.PrID=UpHattyuDetail.PrID;
                    UpdateTarget2.HaQuantity=UpHattyuDetail.HaQuantity;

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

        //商品検索(検索項目)：オーバーロード
        public List<DispHattyuDTO> GetHattyuData(DispHattyuDTO dispHattyuDTO)
        {

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from HattyuDetail in context.T_HattyuDetails
                         join Hattyu in context.T_Hattyus
                         on HattyuDetail.HaID equals Hattyu.HaID
                         join Product in context.M_Products
                         on HattyuDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Hattyu.MaID equals Maker.MaID
                         join Employee in context.M_Employees
                         on Hattyu.EmID equals Employee.EmID



                         //dispSaleDTO.SaID.Equals("") ? true :Sale.SaID.ToString().Equals(dispSaleDTO.SaID) && //売上ID
                         where
                         (dispHattyuDTO.HaID.Equals("")? true:
                         Hattyu.HaID.ToString().Equals(dispHattyuDTO.HaID)) &&//発注ID

                         (dispHattyuDTO.EmID.Equals("")? true:
                         Employee.EmID.ToString().Equals(dispHattyuDTO.EmID))&& //社員ID

                         Employee.EmName.Contains(dispHattyuDTO.EmName) && //社員名

                         Maker.MaName.Contains(dispHattyuDTO.MaName) && //メーカ名

                        (dispHattyuDTO.PrID.Equals("")? true:
                        Product.PrID.ToString().Equals(dispHattyuDTO.PrID))&& //商品ID

                        Product.PrName.Contains(dispHattyuDTO.PrName) && //商品名

                        //発注年月日

                        Hattyu.HaFlag == 0 //非表示フラグ

                         select new DispHattyuDTO
                         {
                             HaID= Hattyu.HaID.ToString(),
                             HaDetailID=HattyuDetail.HaDetailID.ToString(),
                             EmID= Hattyu.EmID.ToString(),
                             EmName=Employee.EmName,
                             MaID=Maker.MaID.ToString(),
                             MaName = Maker.MaName,
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             HaDate= Hattyu.HaDate,
                             HaQuantity=HattyuDetail.HaQuantity.ToString(),
                             HaFlag=Hattyu.HaFlag.ToString(),
                             HaHidden=Hattyu.HaHidden.ToString(),
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //続きから

        //商品全表示：オーバーロード
        public List<DispHattyuDTO> GetHattyuData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from HattyuDetail in context.T_HattyuDetails
                         join Hattyu in context.T_Hattyus
                         on HattyuDetail.HaID equals Hattyu.HaID
                         join Product in context.M_Products
                         on HattyuDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Hattyu.MaID equals Maker.MaID
                         join Employee in context.M_Employees
                         on Hattyu.EmID equals Employee.EmID

                         where 

                         Hattyu.HaFlag == 0 //非表示フラグ

                         select new DispHattyuDTO
                         {
                             HaID = Hattyu.HaID.ToString(),
                             HaDetailID = HattyuDetail.HaDetailID.ToString(),
                             EmID = Hattyu.EmID.ToString(),
                             EmName = Employee.EmName,
                             MaID=Maker.MaID.ToString(),
                             MaName = Maker.MaName,
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             HaDate = Hattyu.HaDate,
                             HaQuantity = HattyuDetail.HaQuantity.ToString(),
                             HaFlag=Hattyu.HaFlag.ToString(),
                             HaHidden = Hattyu.HaHidden.ToString(),
                             
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }
    }
}
