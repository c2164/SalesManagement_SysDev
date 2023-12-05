using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class PositionDataAccess
    {
        public List<M_Position> GetPositionData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                List<M_Position> tb = new List<M_Position>();
                tb = context.M_Positions.ToList();

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
