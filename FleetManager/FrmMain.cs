using FleetManager.GuiController;
using FleetManager.GUIController;
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
    public partial class FrmMain : Form
    {
        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void kryptonPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmFreeVehs();
        }

        private void viewAllVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmVehicles();
        }

        private void alterRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.Logout();
        }

        private void newVehToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowAddVehicleControl();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowAddUserControl();
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmCheckins();
        }
    }
}
