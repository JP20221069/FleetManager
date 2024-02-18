using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class FrmTool : Form
    {
        public FrmTool()
        {
            InitializeComponent();
        }
        public void ChangePanel(Control control)
        {
            pnlTool.Controls.Clear();
            pnlTool.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlTool.AutoSize = true;
            pnlTool.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void FrmTool_Load(object sender, EventArgs e)
        {

        }
    }
}
