using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class MakerDateAccess
    {
        public List<M_Maker> GetMakerData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                List<M_Maker> tb = new List<M_Maker>();
                tb = context.M_Makers.ToList();

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
