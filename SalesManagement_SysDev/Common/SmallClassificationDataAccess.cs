using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class SmallClassificationDataAccess
    {
        public List<M_SmallClassification> GetSCData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                List<M_SmallClassification> tb = new List<M_SmallClassification>();
                tb = context.M_SmallClassifications.ToList();

                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
    }
}
