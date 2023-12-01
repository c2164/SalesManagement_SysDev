using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class ShukkoDataAccess
    {
       
       
            //入庫情報登録(登録情報)
            public bool RegisterClientData(T_Syukko RegSyukko)
            {
                using (var context = new SalesManagement_DevContext())
                {
                    try
                    {
                        context.T_Syukkos.Add(RegSyukko);
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
            public bool UpdateClinetData(T_Syukko UpSyukko)
            {
                using (var context = new SalesManagement_DevContext())
                {
                    try
                    {
                        var UpdateTarget = context.T_Syukkos.Single(x => x.SyID == UpSyukko.SyID);
                        UpdateTarget = UpSyukko;

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
            public List<DispSyukkoDTO> GetWarehousingData(DispSyukkoDTO dispSyukkoDTO)
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
                             on Syukko.EmID equals Employee.EmID
                             join Chumon in context.T_Chumons
                            on Employee.EmID equals Chumon.EmID
                             join SalesOffice in context.M_SalesOffices
                             on Syukko.SoID equals SalesOffice.SoID
                             join Order in context.T_Orders
                             on Syukko.OrID equals Order.OrID
                             join ChumonEmployee in context.M_Employees
                             on Chumon.EmID equals ChumonEmployee.EmID
                            
                             where
                              ((dispSyukkoDTO.SyID == "") ? true :
                             Syukko.SyID == int.Parse(dispSyukkoDTO.SyID)) &&//出庫ID
                             SalesOffice.SoName.Contains(dispSyukkoDTO.SoName) && //営業所名
                             ChumonEmployee.EmName.Contains(dispSyukkoDTO.ChumonEmName) && //注文社員名
                             Client.ClName.Contains(dispSyukkoDTO.ClName) && //顧客名
                              ((dispSyukkoDTO.SyID == "") ? true :
                             Order.OrID == int.Parse(dispSyukkoDTO.OrID)) && //受注ID
                             Employee.EmID.ToString().Contains(dispSyukkoDTO.ConfEmName) && //確定社員名
                              ((dispSyukkoDTO.SyID == "") ? true :
                             SyukkoDetail.SyDetailID == int.Parse(dispSyukkoDTO.SyDetailID)) && //出庫詳細ID
                             Maker.MaName.Contains(dispSyukkoDTO.MaName) && //メーカー名
                             Product.PrName.Contains(dispSyukkoDTO.PrName) && //商品名
                             SyukkoDetail.ToString().Contains(dispSyukkoDTO.ArQuantity)  //数量



                             select new DispSyukkoDTO
                             {
                                 SyID = Syukko.SyID.ToString(),
                                 ChumonEmName = Chumon.ChID.ToString(),
                                 ClName = Client.ClName.ToString(),
                                 OrID = Order.OrID.ToString(),
                                 ConfEmName = Employee.EmName.ToString(),
                                 SyDetailID = SyukkoDetail.SyDetailID.ToString(),
                                 MaName = Maker.MaName.ToString(),
                                 PrName = Product.PrName.ToString(),
                                 ArQuantity = SyukkoDetail.ToString(),


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
            public List<DispSyukkoDTO> GetProductData()
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
                         on Syukko.EmID equals Employee.EmID
                         join SalesOffice in context.M_SalesOffices
                         on Syukko.SoID equals SalesOffice.SoID
                         join Order in context.T_Orders
                         on Syukko.OrID equals Order.OrID
                         join Chumon in context.T_Chumons
                       on Employee.EmID equals Chumon.EmID
                         join ChumonEmployee in context.M_Employees
                         on Chumon.EmID equals ChumonEmployee.EmID


                         select new DispSyukkoDTO
                         {
                             SyID = Syukko.SyID.ToString(),
                             ChumonEmName = Chumon.ChID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Order.OrID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             SyDetailID = SyukkoDetail.SyDetailID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             PrName = Product.PrName.ToString(),
                             ArQuantity = SyukkoDetail.ToString(),


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

