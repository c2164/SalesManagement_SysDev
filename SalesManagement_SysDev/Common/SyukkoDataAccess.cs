using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class SyukkoDataAccess
    {


        //出庫情報登録(登録情報)
        public bool RegisterSyukkoData(T_Syukko RegSyukko, List<T_SyukkoDetail> listRegSyukkoDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Syukkos.Add(RegSyukko);
                    context.SaveChanges();
                    int SyID = context.T_Syukkos.Max(x => x.SyID);
                    foreach (var RegSyukkoDetail in listRegSyukkoDetail)
                    {
                        RegSyukkoDetail.SyID = SyID;
                        context.T_SyukkoDetails.Add(RegSyukkoDetail);
                        context.SaveChanges();
                    }
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
        public bool UpdateSyukkoData(T_Syukko UpSyukko)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Syukkos.Single(x => x.SyID == UpSyukko.SyID);
                    UpdateTarget.SyID = UpSyukko.SyID;
                    UpdateTarget.EmID = UpSyukko.EmID;
                    UpdateTarget.ClID = UpSyukko.ClID;
                    UpdateTarget.SoID = UpSyukko.SoID;
                    UpdateTarget.OrID = UpSyukko.OrID;
                    UpdateTarget.SyDate = UpSyukko.SyDate;
                    UpdateTarget.SyStateFlag = UpSyukko.SyStateFlag;
                    UpdateTarget.SyFlag = UpSyukko.SyFlag;
                    UpdateTarget.SyHidden = UpSyukko.SyHidden;

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
        public List<DispSyukkoDTO> GetSyukkoData(DispSyukkoDTO dispSyukkoDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Syukko」テーブルから「T_SyukkoDetail」「M_Product] 「M_Maker] 「M_Client] 「M_SalesOffice]「M_Employee] 「T_Order]「M_Chumon]「M_ChumonEmployee] を参照
                var tb = from SyukkoDetail in context.T_SyukkoDetails
                         join Syukko in context.T_Syukkos
                         on SyukkoDetail.SyID equals Syukko.SyID
                         join Product in context.M_Products
                         on SyukkoDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         join Client in context.M_Clients
                         on Syukko.ClID equals Client.ClID
                         join Employee in context.M_Employees
                         on Syukko.EmID equals Employee.EmID into em
                         from Employee in em.DefaultIfEmpty()
                         join Chumon in context.T_Chumons
                         on Syukko.OrID equals Chumon.OrID
                         join SalesOffice in context.M_SalesOffices
                         on Syukko.SoID equals SalesOffice.SoID
                         join Order in context.T_Orders
                         on Syukko.OrID equals Order.OrID
                         join ChumonEmployee in context.M_Employees
                         on Chumon.EmID equals ChumonEmployee.EmID

                         where
                          ((dispSyukkoDTO.SyID == "") ? true :
                         Syukko.SyID.ToString().Equals(dispSyukkoDTO.SyID)) &&//出庫ID
                         SalesOffice.SoName.Contains(dispSyukkoDTO.SoName) && //営業所名
                         ChumonEmployee.EmName.Contains(dispSyukkoDTO.ChumonEmName) && //注文社員名
                         Client.ClName.Contains(dispSyukkoDTO.ClName) && //顧客名
                          ((dispSyukkoDTO.OrID == "") ? true :
                         Order.OrID.ToString().Equals(dispSyukkoDTO.OrID)) && //受注ID
                         (Employee.EmName == null && dispSyukkoDTO.ConfEmName == "" ? true :
                         Employee.EmName.ToString().Contains(dispSyukkoDTO.ConfEmName)) && //確定社員名
                          ((dispSyukkoDTO.SyDetailID == "") ? true :
                         SyukkoDetail.SyDetailID.ToString().Equals(dispSyukkoDTO.SyDetailID)) && //出庫詳細ID
                         Maker.MaName.Contains(dispSyukkoDTO.MaName) && //メーカー名
                         Product.PrName.Contains(dispSyukkoDTO.PrName) &&  //商品名
                         (dispSyukkoDTO.SyStateFlag == "1" ? true :
                         Syukko.SyStateFlag == 0) &&

                         Syukko.SyFlag == 0


                         select new DispSyukkoDTO
                         {
                             SyID = Syukko.SyID.ToString(),
                             ClName = Client.ClName,
                             OrID = Order.OrID.ToString(),
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName,
                             SyDetailID = SyukkoDetail.SyDetailID.ToString(),
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             SyQuantity = SyukkoDetail.SyQuantity.ToString(),
                             ClID = Client.ClID.ToString(),
                             ChID = Chumon.ChID.ToString(),
                             ChumonEmID = ChumonEmployee.EmID.ToString(),
                             ChumonEmName = ChumonEmployee.EmName,
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             SyDate = Syukko.SyDate,
                             SyStateFlag = Syukko.SyStateFlag.ToString(),
                             SyFlag = Syukko.SyFlag.ToString(),
                             SyHidden = Syukko.SyHidden.ToString(),
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
        public List<DispSyukkoDTO> GetSyukkoData(int stateFlag)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Syukko」テーブルから「T_SyukkoDetail」「M_Product] 「M_Maker] 「M_Client] 「M_SalesOffice]「M_Employee] 「T_Order]「M_Chumon]「M_ChumonEmployee] を参照
                var tb = from SyukkoDetail in context.T_SyukkoDetails
                         join Syukko in context.T_Syukkos
                         on SyukkoDetail.SyID equals Syukko.SyID
                         join Product in context.M_Products
                         on SyukkoDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         join Client in context.M_Clients
                         on Syukko.ClID equals Client.ClID
                         join Employee in context.M_Employees
                         on Syukko.EmID equals Employee.EmID into em
                         from Employee in em.DefaultIfEmpty()
                         join SalesOffice in context.M_SalesOffices
                         on Syukko.SoID equals SalesOffice.SoID
                         join Order in context.T_Orders
                         on Syukko.OrID equals Order.OrID
                         join Chumon in context.T_Chumons
                         on Syukko.OrID equals Chumon.OrID
                         join ChumonEmployee in context.M_Employees
                         on Chumon.EmID equals ChumonEmployee.EmID

                         where Syukko.SyFlag == 0 &&
                         (stateFlag == 1 ? true :
                         Syukko.SyStateFlag == 0)

                         select new DispSyukkoDTO
                         {
                             SyID = Syukko.SyID.ToString(),
                             SyDetailID = SyukkoDetail.SyDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             SyQuantity = SyukkoDetail.SyQuantity.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ClID = Client.ClID.ToString(),
                             ClName = Client.ClName,
                             ChID = Chumon.ChID.ToString(),
                             ChumonEmID = ChumonEmployee.EmID.ToString(),
                             ChumonEmName = ChumonEmployee.EmName,
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName,
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             OrID = Order.OrID.ToString(),
                             EmID = Syukko.EmID.ToString(),
                             SyDate = Syukko.SyDate,
                             SyStateFlag = Syukko.SyStateFlag.ToString(),
                             SyFlag = Syukko.SyFlag.ToString(),
                             SyHidden = Syukko.SyHidden.ToString(),
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

