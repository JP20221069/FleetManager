﻿using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using FleetManager.Comms;
using FleetManager.GUIController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GuiController
{
    public class LoginGUIController
    {
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
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if(dr==DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
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
                MainGUIController mgc = new MainGUIController((Korisnik)response.Result);
                mgc.ShowFrmMain();
            }
            else
            {
                MessageBox.Show(response.Exception.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
