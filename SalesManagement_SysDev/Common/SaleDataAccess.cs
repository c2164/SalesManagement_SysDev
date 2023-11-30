﻿using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
        class SaleDataAccess
        {
            public bool RegisterSaleData(T_Sale RegSale, T_SaleDetail RegSaleDetail)
            {
                using (var context = new SalesManagement_DevContext())
                {
                    try
                    {
                        context.T_Sale.Add(RegSale);
                        context.T_SaleDetails.Add(RegSaleDetail);
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

            public bool UpdateSaleData(T_Sale UpSale, T_SaleDetail UpSaleDetail)
            {
                using (var context = new SalesManagement_DevContext())
                {
                    try
                    {
                        var UpdateTarget = context.T_Sale.Single(x => x.SaID == UpSale.SaID);
                        var UpdateTargetDetail = context.T_SaleDetails.Single(x => UpSale.SaID == UpSale.SaID);
                        UpdateTarget = UpSale;
                        UpdateTargetDetail = UpSaleDetail;

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

            public List<DispSaleDTO> GetSaleData(DispSaleDTO dispSaleDTO)
            {
                var context = new SalesManagement_DevContext();
                try
                {
                //「T_SaleDeteal」テーブルから　「T_Sale」「M_SalesOffice」「M_Employee] 「M_Client] [T_Order]　「M_Product」を参照
                var tb = from SaleDetail in context.T_SaleDetails
                         join Sale in context.T_Sale
                         on SaleDetail.SaDetailID equals Sale.SaID

                         join Client in context.M_Clients
                         on Sale.ClID equals Client.ClID

                         join SalesOffice in context.M_SalesOffices
                         on Sale.SoID equals SalesOffice.SoID

                         join Employee in context.M_Employees
                         on Sale.EmID equals Employee.EmID

                         join Order in context.T_Orders
                         on Sale.ChID equals Order.OrID

                         join Product in context.M_Products
                         on SaleDetail.PrID equals Product.PrID


                         where
                         ((dispSaleDTO.SaID == "") ? true :
                         Sale.SaID == int.Parse(dispSaleDTO.SaID)) && //売上ID

                         Client.ClName.Contains(dispSaleDTO.ClName) &&  //顧客名
                         SalesOffice.SoName.Contains(dispSaleDTO.SoName) && //営業所名

                         ((dispSaleDTO.SaDetailID == "") ? true :
                         SaleDetail.SaDetailID == int.Parse(dispSaleDTO.SaDetailID)) && //売上詳細ID

                         Employee.EmName.Contains(dispSaleDTO.EmName) && //社員名

                         //商品ID

                         ((dispSaleDTO.OrID == "") ? true :
                         Order.OrID == int.Parse(dispSaleDTO.OrID)) && //受注ID

                         //検索用日時

                         Sale.SaFlag == 0 //非表示フラグ



                         select new DispSaleDTO
                         {
                             SaID = Sale.SaID.ToString(),
                             SaDetailID = SaleDetail.SaDetailID.ToString(),
                             ClID = Sale.ClID.ToString(),
                             ClName = Client.ClName,
                             SoID = Sale.SoID.ToString(),
                             SoName=SalesOffice.SoName,
                             EmID = Sale.EmID.ToString(),
                             EmName=Employee.EmName,
                             OrID=Sale.ChID.ToString(),
                             PrID=SaleDetail.PrID.ToString(),
                             PrName=Product.PrName,
                             SaDate=Sale.SaDate,
                             SaQuantity=SaleDetail.SaQuantity.ToString(),
                             SaTotalPrice=SaleDetail.SaTotalPrice.ToString(),
                          };

                    return tb.ToList();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("売上データ取得時に例外エラーが発生しました", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;

            }

            public List<DispSaleDTO> GetSaleData()
            {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_SaleDeteal」テーブルから　「T_Sale」「M_SalesOffice」「M_Employee] 「M_Client] [T_Order]　「M_Product」を参照
                var tb = from SaleDetail in context.T_SaleDetails
                         join Sale in context.T_Sale
                         on SaleDetail.SaDetailID equals Sale.SaID

                         join Client in context.M_Clients
                         on Sale.ClID equals Client.ClID

                         join SalesOffice in context.M_SalesOffices
                         on Sale.SoID equals SalesOffice.SoID

                         join Employee in context.M_Employees
                         on Sale.EmID equals Employee.EmID

                         join Order in context.T_Orders
                         on Sale.ChID equals Order.OrID

                         join Product in context.M_Products
                         on SaleDetail.PrID equals Product.PrID

                         where

                         Sale.SaFlag == 0 //非表示フラグ



                         select new DispSaleDTO
                         {
                             SaID = Sale.SaID.ToString(),
                             SaDetailID = SaleDetail.SaDetailID.ToString(),
                             ClID = Sale.ClID.ToString(),
                             ClName = Client.ClName,
                             SoID = Sale.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             EmID = Sale.EmID.ToString(),
                             EmName = Employee.EmName,
                             OrID = Sale.ChID.ToString(),
                             PrID = SaleDetail.PrID.ToString(),
                             PrName = Product.PrName,
                             SaDate = Sale.SaDate,
                             SaQuantity = SaleDetail.SaQuantity.ToString(),
                             SaTotalPrice = SaleDetail.SaTotalPrice.ToString(),
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("売上データ取得時に例外エラーが発生しました", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }
        }
    
}
