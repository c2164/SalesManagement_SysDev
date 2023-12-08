using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class MessageDsp
    {
        public void MessageBoxDsp_OK(string msg, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
        }

        public DialogResult MessageBoxDsp_OKCancel(string msg, string title, MessageBoxIcon icon)
        {
            DialogResult result;

            result = MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, icon);
            return result;
        }
    }
}
