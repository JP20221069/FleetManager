using Common.Localization;
using FleetManager.Comms;
using FleetManager.Controls;
using FleetManager.GuiController;
using FleetManager.GUIController;
using FleetManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            if(Program.curr_lang.Name=="EN")
            {
                englishENToolStripMenuItem.Checked = true;
            }
            else
            {
                srpskiSRToolStripMenuItem.Checked = true;
            }
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

        private void alterVehToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmVehicles("ALTER");
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmVehicles("DELETE");
        }

        private void alterUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmUsers("ALTER");
        }

        private void englishENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishENToolStripMenuItem.Checked = true;
            srpskiSRToolStripMenuItem.Checked = false;
            Program.curr_lang = Langset.FromFile("Languages/EN.lang");
            var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configfile.AppSettings.Settings["Language"].Value = "EN";
            configfile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configfile.AppSettings.SectionInformation.Name);
            MainGUIController.Instance.Localize();
            MainGUIController.Instance.Localize();
        }

        private void srpskiSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishENToolStripMenuItem.Checked = false;
            srpskiSRToolStripMenuItem.Checked = true;
            Program.curr_lang = Langset.FromFile("Languages/SR.lang");
            var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configfile.AppSettings.Settings["Language"].Value = "SR";
            configfile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configfile.AppSettings.SectionInformation.Name);
            MainGUIController.Instance.Localize();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowAboutWindow();
        }
    }
}
