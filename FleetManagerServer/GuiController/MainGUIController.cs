using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer.GuiController
{
    public class MainGUIController
    {
        private FrmMain frmMain;
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

        internal void ShowFrmMain()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new FrmMain();
            frmMain.FIELD_IP.Text = ConfigurationManager.AppSettings["server_ip"];
            frmMain.FIELD_PORT.Text = ConfigurationManager.AppSettings["server_port"];
            frmMain.lblClients.Text = "0/" + ConfigurationManager.AppSettings["iNumMaxClients"];
            frmMain.lblmaxClients.Text= ConfigurationManager.AppSettings["iNumMaxClients"];
            frmMain.AutoSize = true;
     
            Application.Run(frmMain);
        }


        internal void ShowLog()
        {
            LogGUIController.Instance.ShowFrmLog();
        }

    }
}
