using Common.Localization;
using FleetManager.GuiController;
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
    public partial class FrmLogin : Form
    {
        Langset l = Program.curr_lang;
        public FrmLogin()
        {
            InitializeComponent();
        }

        public bool ValidateInput()
        {
            if(string.IsNullOrEmpty(FIELD_USERNAME.Text) || string.IsNullOrWhiteSpace(FIELD_USERNAME.Text))
            {
                MessageBox.Show(l.GetString("MSG_USERNAMEREQUIRED"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(FIELD_PASSWORD.Text) || string.IsNullOrWhiteSpace(FIELD_PASSWORD.Text))
            {
                MessageBox.Show(l.GetString("MSG_PWDREQUIRED"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                LoginGUIController.Instance.Login(sender,e);
            }

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if (this.DialogResult == DialogResult.Cancel)
            {
                LoginGUIController.Instance.DisconnectCl();
            }*/
        }
    }
}
