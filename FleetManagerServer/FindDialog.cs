using FleetManagerServer.GuiController;
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
    public partial class FindDialog : Form
    {
        public FindDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (FIELD_FIND.Text != "")
            {
                btFindNext.Enabled = true;
            }
            else
            {
                btFindNext.Enabled = false;
            }
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void FindDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FindGUIController.Instance.ClearSearch();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
