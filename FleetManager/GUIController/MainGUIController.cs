using Common.Domain;
using FleetManager.Comms;
using FleetManager.GuiController;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class MainGUIController
    {
        private static Korisnik current_user;

        private static FrmMain frmMain;

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

        private MainGUIController()
        {
            //personGuiController = new PersonGuiController();
        }
       public MainGUIController(Korisnik user)
        {
            current_user = user;
        }
 
       // private PersonGuiController personGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain();
            if(current_user.Rola==(int)Rola.Korisnik)
            {
                frmMain.serviceToolStripMenuItem.Visible = true;
                frmMain.checkInToolStripMenuItem.Visible = true;
                frmMain.checkoutToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = true;

            }
            if(current_user.Rola==(int)Rola.Moderator)
            {
                frmMain.alterVehToolStripMenuItem.Visible = true;
                frmMain.newVehToolStripMenuItem.Visible = true;
                frmMain.deleteVehToolStripMenuItem.Visible = true;
                frmMain.viewAllVehiclesToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
            }
            if(current_user.Rola==(int)Rola.Admin)
            {
                frmMain.deleteVehToolStripMenuItem.Visible = true;
                frmMain.alterUserToolStripMenuItem.Visible = true;
                frmMain.newUserToolStripMenuItem.Visible = true;
                frmMain.recordVehicleToolStripMenuItem.Visible = true;
                frmMain.recordUserToolStripMenuItem.Visible = true;

            }
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
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

        internal void ShowAddPersonPanel()
        {
            //frmMain.ChangePanel(personGuiController.CreateAddPerson());
        }
    }
}
