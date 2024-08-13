using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using FleetManager.Comms;
using FleetManager.GUIController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Common.Localization;

namespace FleetManager.GuiController
{
    public class LoginGUIController
    {
        Langset l = Program.curr_lang;
        private static LoginGUIController instance;
        public static LoginGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGUIController();
                }
                return instance;
            }
        }
        private LoginGUIController()
        {
        }

        private FrmLogin frmLogin;

        internal void ShowFrmLogin(bool first=true)
        {
            while (true)
            {
                try
                {
                    if (first)
                    {
                        CommunicationManager.Instance.Connect();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                    }
                    frmLogin = new FrmLogin();
                    Localize();
                    frmLogin.AutoSize = true;
                    if (first)
                    {
                        Application.Run(frmLogin);
                    }
                    else
                    {
                        frmLogin.ShowDialog();
                    }
                    break;
                }
                catch(IOException ex)
                {
                    MainGUIController.Instance.SetIcon(false);
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show(ex.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if(dr==DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
        }

        private void Localize()
        {
            
            frmLogin.LB_PASSWORD.Text = l.GetString("Password");
            frmLogin.LB_USERNAME.Text = l.GetString("Username");
            frmLogin.BT_LOGIN.Text = l.GetString("Login");
        }

        internal void DisconnectCl()
        {
            CommunicationManager.Instance.Disconnect();
        }

        internal void Login(object sender, EventArgs e)
        {
            Korisnik user = new Korisnik
            {
                Username = frmLogin.FIELD_USERNAME.Text,
                Password = frmLogin.FIELD_PASSWORD.Text,
            };
            Response response = CommunicationManager.Instance.Login(user);
            if (response.Exception == null)
            {
                frmLogin.Visible = false;
                MainGUIController.current_user = (Korisnik)response.Result;
                MainGUIController.Instance.ShowFrmMain();
               // LoginGUIController.instance.CloseFrmLogin();
            }
            else
            {
                MessageBox.Show(response.Exception.Message,l.GetString("TTL_ERROR"),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        internal void CloseFrmLogin()
        {
            frmLogin.Close();
        }
    }
}
