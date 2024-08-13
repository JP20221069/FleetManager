using Common.Domain;
using Common.Localization;
using FleetManager.Comms;
using FleetManager.GuiController;
using FleetManager.Properties;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class MainGUIController
    {
        Langset l = Program.curr_lang;
        public static Korisnik current_user;
        public static bool isexitclose = false;

        private static FrmMain frmMain;
        private static UserDetailsGUIController udc;
        private static VehicleGUIController awgc;

        private static MainGUIController instance;
        public static MainGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainGUIController();
                }
                return instance;
            }
        }
/*        private void InstantiateControllers()
        {
            udc = new AddUserGUIController();
            awgc = new VehicleGUIController();
        }*/
        private MainGUIController()
        {
            //InstantiateControllers();
        }
 

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain();
            Localize();
            if(current_user.Rola==Rola.Korisnik)
            {
                frmMain.serviceToolStripMenuItem.Visible = true;
                frmMain.checkInToolStripMenuItem.Visible = true;
                frmMain.checkoutToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = true;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;

            }
            if(current_user.Rola==Rola.Moderator)
            {
                frmMain.newVehToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;
                frmMain.alterVehToolStripMenuItem.Visible = true;
                frmMain.deleteToolStripMenuItem.Visible = true;
            }
            if(current_user.Rola==Rola.Admin)
            {
                frmMain.newUserToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
                frmMain.deleteToolStripMenuItem.Visible = true;
                frmMain.recordUserToolStripMenuItem.Visible = true;
                frmMain.viewAllToolStripMenuItem.Visible = true;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;
                frmMain.userSearchToolStripMenuItem.Visible = true;

            }
            frmMain.AutoSize = true;
            frmMain.Show();
            SetIcon(true);
        }

        internal void Localize()
        {
            frmMain.Text = l.GetString("TTL_MAIN");
            frmMain.programToolStripMenuItem.Text = l.GetString("Program");
            frmMain.aboutToolStripMenuItem.Text = l.GetString("About");
            frmMain.helpToolStripMenuItem.Text = l.GetString("Help");
            frmMain.exitToolStripMenuItem.Text = l.GetString("Exit");

            frmMain.vehicleToolStripMenuItem.Text = l.GetString("Vehicle");
            frmMain.serviceToolStripMenuItem.Text = l.GetString("Service");
            frmMain.recordVehicleToolStripMenuItem.Text = l.GetString("Record");
            frmMain.newVehToolStripMenuItem.Text = l.GetString("New");
            frmMain.checkInToolStripMenuItem.Text = l.GetString("Checkin");
            frmMain.checkoutToolStripMenuItem.Text = l.GetString("Checkout");
            frmMain.viewAllToolStripMenuItem.Text = l.GetString("ViewAll");
            frmMain.viewAllVehiclesToolStripMenuItem.Text = l.GetString("ViewAll");

            frmMain.userToolStripMenuItem2.Text = l.GetString("User");
            frmMain.newUserToolStripMenuItem.Text = l.GetString("New");
            frmMain.logOffToolStripMenuItem.Text = l.GetString("Log_off");
            frmMain.vehicleSearchToolStripMenuItem.Text = l.GetString("Vehicle");
            frmMain.userSearchToolStripMenuItem.Text = l.GetString("User");
            frmMain.userToolStripMenuItem2.Text = l.GetString("User");
            frmMain.searchToolStripMenuItem.Text = l.GetString("Search");
            frmMain.recordUserToolStripMenuItem.Text = l.GetString("Record");

            frmMain.alterUserToolStripMenuItem.Text = l.GetString("Alter");
            frmMain.alterVehToolStripMenuItem.Text = l.GetString("Alter");
            frmMain.deleteToolStripMenuItem.Text = l.GetString("Delete");
        }

        internal void Logout()
        {
            Response res = CommunicationManager.Instance.Logout(current_user);
            if(res.Exception==null)
            {
                current_user.Ulogovan = false;
                isexitclose = true;
                frmMain.Close();
                LoginGUIController.Instance.ShowFrmLogin(false);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void LogoutAndExit(bool closeform=true)
        {
            Response res = CommunicationManager.Instance.Logout(current_user);
            if (res.Exception == null)
            {
                if (closeform)
                {
                    frmMain.Close();
                }
                Application.Exit();
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        internal void ShowAddUserControl()
        {
            frmMain.ChangePanel(UserDetailsGUIController.Instance.CreateAddUser());
        }

        internal void ShowAddVehicleControl()
        {
            frmMain.ChangePanel(VehicleGUIController.Instance.CreateAddVehicle());
        }

        internal void ShowSearchUserControl()
        {
            frmMain.ChangePanel(UserDetailsGUIController.Instance.CreateSearchUser(true));
        }

        internal void ShowSearchVehicleControl()
        {
            frmMain.ChangePanel(VehicleGUIController.Instance.CreateSearchVehicle(false,true));
        }

        internal void SetIcon(bool yn)
        {
            if (yn == true)
            {
                frmMain.toolStripStatusLabel1.Image = Resources.tick;
                frmMain.toolStripStatusLabel1.ToolTipText = "Connected to the server.";
                frmMain.toolStripStatusLabel1.AutoToolTip = false;
            }
            else
            {
                frmMain.toolStripStatusLabel1.Image = Resources.x;
                frmMain.toolStripStatusLabel1.ToolTipText = "There has been an error.";
                frmMain.toolStripStatusLabel1.AutoToolTip = false;
            }
        }

    }
}
