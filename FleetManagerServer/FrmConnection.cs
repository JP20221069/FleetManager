using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer
{
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void btCopyCS_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FIELD_CONNECTION_STRING.Text);
        }

        private void btTestConnection_Click(object sender, EventArgs e)
        {

        }
    }
}
