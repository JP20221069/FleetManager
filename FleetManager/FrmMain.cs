using FleetManager.Comms;
using FleetManager.GuiController;
using FleetManager.GUIController;
using FleetManager.Properties;
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

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmVehiclesService();
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmUsers();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.isexitclose = true;
            MainGUIController.Instance.LogoutAndExit();
            Application.Exit();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowSearchUserControl();
        }

        private void vehicleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowSearchVehicleControl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (MainGUIController.isexitclose==false)
            { 
                MainGUIController.Instance.LogoutAndExit(false);
            }
            MainGUIController.isexitclose = false;
        }
    }
}
