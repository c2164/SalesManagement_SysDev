using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class ChumonDataAccess
    {
        //注文情報登録(登録情報)
        public bool RegisterChumonData(T_Chumon RegChumon, T_ChumonDetail RegChumonDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Chumons.Add(RegChumon);
                    context.T_ChumonDetails.Add(RegChumonDetail);
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

        //注文情報アップデート(アップデート情報)
        public bool UpdateChumonData(T_Chumon UpChumon, T_ChumonDetail UpChumonDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Chumons.Single(x => x.ChID == UpChumon.ChID);
                    var UpdateTargetDetail = context.T_ChumonDetails.Single(x => x.ChDetailID == UpChumonDetail.ChID);
                    UpdateTarget = UpChumon;
                    UpdateTargetDetail = UpChumonDetail;

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

        //注文検索(検索項目)：オーバーロード
        public List<DispChumonDTO> GetChumonData(DispChumonDTO dispChumonDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Chumon」テーブルから「M_SalesOffice」「M_Employee」「M_Client」「T_Order」を参照
                var tb = from Chumon in context.T_Chumons
                         join Employee in context.M_Employees
                         on Chumon.EmID equals Employee.EmID
                         join SalesOffice in context.M_SalesOffices
                         on Chumon.SoID equals SalesOffice.SoID
                         join Client in context.M_Clients
                         on Chumon.ClID equals Client.ClID
                         join Order in context.T_Orders
                         on Chumon.OrID equals Order.OrID
                         join ChumonDetail in context.T_ChumonDetails
                         on Chumon.ChID equals ChumonDetail.ChID
                         join Product in context.M_Products
                         on ChumonDetail.PrID equals Product.PrID

                         where
                         ((dispChumonDTO.ChID == "") ? true :
                         Chumon.ChID == int.Parse(dispChumonDTO.ChID)) && //注文ID
                         Product.PrName.Contains(dispChumonDTO.PrName) && //商品名
                         SalesOffice.SoName.Contains(dispChumonDTO.SoName) && //営業所名
                         ((dispChumonDTO.ChDetailID == "") ? true :
                         ChumonDetail.ChDetailID == int.Parse(dispChumonDTO.ChDetailID)) && //注文詳細ID
                         ((dispChumonDTO.OrID == "") ? true :
                         Order.OrID == int.Parse(dispChumonDTO.OrID)) && //受注ID
                         Client.ClName.Contains(dispChumonDTO.ClName) && //顧客名
                         Employee.EmName.Contains(dispChumonDTO.EmName) &&//社員名
                         //Chumon.ChDate.(dispChumonDTO.ChDate)&&//注文年月日
                         ((dispChumonDTO.ChQuantity == "") ? true :
                         ChumonDetail.ChQuantity == int.Parse(dispChumonDTO.ChQuantity)) &&//数量
                         Chumon.ChFlag == 0 //非表示フラグ

                         select new DispChumonDTO
                         {
                             ChID = Chumon.ChID.ToString(),
                             PrName = Product.PrName,
                             SoName = SalesOffice.SoName,
                             ChDetailID = ChumonDetail.ChDetailID.ToString(),
                             OrID = Order.OrID.ToString(),
                             ClName = Client.ClName,
                             EmName = Employee.EmName,


                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //顧客全表示：オーバーロード
        public List<DispChumonDTO> GetChumonData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Chumon」テーブルから「M_SalesOffice」「M_Employee」「M_Client」「T_Order」を参照
                var tb = from Chumon in context.T_Chumons
                         join Employee in context.M_Employees
                         on Chumon.EmID equals Employee.EmID
                         join SalesOffice in context.M_SalesOffices
                         on Chumon.SoID equals SalesOffice.SoID
                         join Client in context.M_Clients
                         on Chumon.ClID equals Client.ClID
                         join Order in context.T_Orders
                         on Chumon.OrID equals Order.OrID
                         join ChumonDetail in context.T_ChumonDetails
                         on Chumon.ChID equals ChumonDetail.ChID
                         join Product in context.M_Products
                         on ChumonDetail.PrID equals Product.PrID

                         where
                         Chumon.ChFlag == 0 //非表示フラグ

                         select new DispChumonDTO
                         {
                             ChID = Chumon.ChID.ToString(),
                             PrName = Product.PrName,
                             SoName = SalesOffice.SoName,
                             ChDetailID = ChumonDetail.ChDetailID.ToString(),
                             OrID = Order.OrID.ToString(),
                             ClName = Client.ClName,
                             EmName = Employee.EmName,
                             ChQuantity = ChumonDetail.ChQuantity.ToString(),
                             ChDate = Chumon.ChDate,
                             ChStateFlag = Chumon.ChStateFlag.ToString(),


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
