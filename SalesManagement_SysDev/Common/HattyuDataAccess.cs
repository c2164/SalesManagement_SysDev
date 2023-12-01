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
        public bool RegisterHattyuData(T_Hattyu RegHattyu)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Hattyus.Add(RegHattyu);
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

        public bool UpdateHattyuData(T_Hattyu UpHattyu)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Hattyus.Single(x => x.HaID == UpHattyu.HaID);
                    UpdateTarget = UpHattyu;

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



                         where
                         ((dispHattyuDTO.HaID == "") ? true :
                         Hattyu.HaID == int.Parse(dispHattyuDTO.HaID)) &&//発注ID

                         ((dispHattyuDTO.EmID == "") ? true :
                         Employee.EmID == int.Parse(dispHattyuDTO.EmID)) && //社員ID

                         Employee.EmName.Contains(dispHattyuDTO.EmName) && //社員名

                         Maker.MaName.Contains(dispHattyuDTO.MaName) && //メーカ名

                        ((dispHattyuDTO.PrID == "") ? true :
                        Product.PrID == int.Parse(dispHattyuDTO.PrID)) && //商品ID

                        Product.PrName.Contains(dispHattyuDTO.PrName) && //商品名

                        

                        HattyuDetail.HaQuantity.ToString().Contains(dispHattyuDTO.HaQuantity) && //数量

                        //発注年月日

                        Hattyu.HaFlag == 0 //非表示フラグ

                         select new DispHattyuDTO
                         {
                             HaID= Hattyu.HaID.ToString(),
                             HaDetailID=HattyuDetail.HaDetailID.ToString(),
                             EmID= Hattyu.EmID.ToString(),
                             EmName=Employee.EmName,
                             MaName = Maker.MaName,
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             HaDate= Hattyu.HaDate,
                             HaQuantity=HattyuDetail.HaQuantity.ToString()
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
                             MaName = Maker.MaName,
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             HaDate = Hattyu.HaDate,
                             HaQuantity = HattyuDetail.HaQuantity.ToString()
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
