using Common.Domain;
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
        public static Korisnik current_user;

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
            if(current_user.Rola==(int)Rola.Korisnik)
            {
                frmMain.serviceToolStripMenuItem.Visible = true;
                frmMain.checkInToolStripMenuItem.Visible = true;
                frmMain.checkoutToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = false;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;

            }
            if(current_user.Rola==(int)Rola.Moderator)
            {
                frmMain.newVehToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;
            }
            if(current_user.Rola==(int)Rola.Admin)
            {
                frmMain.newUserToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
                frmMain.recordUserToolStripMenuItem.Visible = true;
                frmMain.viewAllToolStripMenuItem.Visible = true;
                frmMain.vehicleSearchToolStripMenuItem.Visible = true;
                frmMain.userSearchToolStripMenuItem.Visible = true;

            }
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
            SetIcon(true);
        }

        internal void Logout()
        {
            Response res = CommunicationManager.Instance.Logout(current_user);
            if(res.Exception==null)
            {
                frmMain.Close();
                LoginGUIController.Instance.ShowFrmLogin(false);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void LogoutAndExit()
        {
            Response res = CommunicationManager.Instance.Logout(current_user);
            if (res.Exception == null)
            {
                frmMain.Close();
                LoginGUIController.Instance.CloseFrmLogin();
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
