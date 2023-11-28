using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class MessageDsp
    {
        public void MessageBoxDsp(string msg, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
        }
    }
}
