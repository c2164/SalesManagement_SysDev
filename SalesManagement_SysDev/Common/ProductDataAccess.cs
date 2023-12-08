using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class ProductDataAccess
    {
        //商品情報登録(登録情報)
        public bool RegisterProductData(M_Product RegProduct)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.M_Products.Add(RegProduct);
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

        //商品情報アップデート(アップデート情報)
        public bool UpdateProductData(M_Product UpProduct)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.M_Products.Single(x => x.PrID == UpProduct.PrID);
                    UpdateTarget.PrID = UpProduct.PrID;
                    UpdateTarget.PrName = UpProduct.PrName;
                    UpdateTarget.MaID = UpProduct.MaID;
                    UpdateTarget.Price = UpProduct.Price;
                    UpdateTarget.PrSafetyStock = UpProduct.PrSafetyStock;
                    UpdateTarget.ScID =UpProduct.ScID;
                    UpdateTarget.PrModelNumber = UpProduct.PrModelNumber;
                    UpdateTarget.PrColor = UpProduct.PrColor;
                    UpdateTarget.PrReleaseDate = UpProduct.PrReleaseDate;
                    UpdateTarget.PrFlag = UpProduct.PrFlag;
                    UpdateTarget.PrHidden = UpProduct.PrHidden;

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
        public List<DispProductDTO> GetProductData(DispProductDTO dispProductDTO)
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
                         Product.PrName.Contains(dispProductDTO.PrName) && //商品名
                         dispProductDTO.PrID.Equals("") ? true:
                         Product.PrID.ToString().Equals(dispProductDTO.PrID)&&//商品ID
                         Maker.MaName.Contains(dispProductDTO.MaName) && //メーカー名
                         SmallClassification.ScName.Contains(dispProductDTO.ScName) && //小分類名
                         dispProductDTO.Price.Equals("") ? true:
                         Product.Price.ToString().Equals(dispProductDTO.Price) &&//価格

                         Product.PrSafetyStock.ToString().Equals(dispProductDTO.PrSafetyStock) &&//安全在庫数
                         Product.PrModelNumber.Contains(dispProductDTO.PrModelNumber) &&//型番
                         Product.PrColor.Contains(dispProductDTO.PrColor) &&
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
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //商品全表示：オーバーロード
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
                             PrFlag = Product.PrFlag.ToString(),
                             PrHidden = Product.PrHidden,
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
