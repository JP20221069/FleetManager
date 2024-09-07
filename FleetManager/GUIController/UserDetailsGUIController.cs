using Common.Domain;
using Common.Localization;
using FleetManager.Comms;
using FleetManager.Controls;
using FleetManager.Utils;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using FleetManagerCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class UserDetailsGUIController
    {
        Langset l = Program.curr_lang;
        UserDetailsControl udc;
        ViewGUIController caller;
        private static UserDetailsGUIController instance;
        public static UserDetailsGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDetailsGUIController();
                }
                return instance;
            }
        }

        void Localize()
        {
            udc.btAccept.Text = l.GetString("ACCEPT");
            udc.LABEL_PASSWORD.Text = l.GetString("Password");
            udc.LABEL_USERNAME.Text = l.GetString("Username");
            udc.LABEL_ROLE.Text = l.GetString("Role");
            udc.chkActive.Text = l.GetString("ENUM_ACTIVE");
            udc.chkLoggedin.Text = l.GetString("Logged_in");
        }
        public Control CreateAddUser()
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Click += AddUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_USER")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_ADMIN")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_MOD")));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            udc = c;
            Localize();
            c.chkLoggedin.Visible = false;
            return udc;
        }

        public Control CreateAlterUser(Korisnik usr)
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Click += AlterUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_USER")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_ADMIN")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_MOD")));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.SelectedItem = c.CB_Role.Items[cbo.FindIndex(x => (int)x.Value == (int)usr.Rola)];
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            c.FIELD_USERNAME.Text = usr.Username;
            c.FIELD_PASSWORD.Text = usr.Password;
            udc = c;
            c.chkActive.Checked = (bool)usr.Aktivan;
            c.chkLoggedin.Visible = false;
            Localize();
            return udc;
        }

        public Control CreateUserDetails(Korisnik usr)
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Click += (o,e)=> { c.ParentForm.Close(); };
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_USER")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_ADMIN")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_MOD")));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.SelectedItem = c.CB_Role.Items[cbo.FindIndex(x => (int)x.Value == (int)usr.Rola)];
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            c.FIELD_USERNAME.Text = usr.Username;
            c.FIELD_PASSWORD.Text = usr.Password;
            c.FIELD_PASSWORD.PasswordChar = '*';
            c.FIELD_PASSWORD.ReadOnly = true;
            c.FIELD_USERNAME.ReadOnly = true;
            c.CB_Role.Enabled = false;
            c.chkActive.Enabled = false;
            c.chkActive.Checked = (bool)usr.Aktivan;
            c.chkLoggedin.Checked = (bool)usr.Ulogovan;
            udc = c;
            Localize();
            c.btAccept.Text = l.GetString("CLOSE");
            return udc;
        }

        public Control CreateSearchUser(bool mainform=false,ViewGUIController caller=null)
        {
            if (caller != null)
            {
                this.caller = caller;
            }
            else
            {
                caller = ViewGUIController.Instance;
            }
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Text = l.GetString("ACCEPT");
            if (mainform == true)
            {
                c.btAccept.Click += SearchUserForMainForm;
            }
            else
            {
                c.btAccept.Click += SearchUser;
            }
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_USER")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_ADMIN")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_MOD")));
            cbo.Add(new CBObject(3, "N/A"));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.SelectedItem = c.CB_Role.Items[3];
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            c.FIELD_PASSWORD.Visible = false;
            c.LABEL_PASSWORD.Visible = false;
            c.chkLoggedin.Enabled = true;
            c.chkActive.ThreeState = true;
            c.chkLoggedin.ThreeState = true;
            c.chkActive.CheckState = CheckState.Indeterminate;
            c.chkLoggedin.CheckState = CheckState.Indeterminate;
            udc = c;
            Localize();
            return udc;
        }

        private void AddUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Username = udc.FIELD_USERNAME.Text;
            k.Password = udc.FIELD_PASSWORD.Text;
            k.Aktivan = udc.chkActive.Checked;
            k.Ulogovan = false;
            Response res = CommunicationManager.Instance.AddUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_ADD_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Username = udc.FIELD_USERNAME.Text;
            k.Password = udc.FIELD_PASSWORD.Text;
            k.Aktivan = udc.chkLoggedin.Checked;
            k.Ulogovan = false;
            Response res = CommunicationManager.Instance.AlterUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_ALTER_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            if(udc.chkActive.CheckState==CheckState.Indeterminate)
            {
                k.Aktivan = null;
            }
            else
            {
                k.Aktivan = udc.chkActive.Checked;
            }
            if(udc.chkLoggedin.CheckState==CheckState.Indeterminate)
            {
                k.Ulogovan = null;
            }
            else
            {
                k.Ulogovan = udc.chkLoggedin.Checked;
            }
            if (!string.IsNullOrEmpty(udc.FIELD_USERNAME.Text))
            {
                k.Username = udc.FIELD_USERNAME.Text;
            }
            else
            {
                k.Username = null;
            }
            k.Rola = (Rola)Convert.ToInt32(udc.CB_Role.SelectedValue);
            Response res = CommunicationManager.Instance.SearchUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_FND_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                caller.SetDataSource((List<Korisnik>)res.Result);
            }
            else if (res.Exception.GetType() == typeof(RecordNotFoundException))
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchUserForMainForm(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            if (udc.chkActive.CheckState == CheckState.Indeterminate)
            {
                k.Aktivan = null;
            }
            else
            {
                k.Aktivan = udc.chkActive.Checked;
            }
            if (udc.chkLoggedin.CheckState == CheckState.Indeterminate)
            {
                k.Ulogovan = null;
            }
            else
            {
                k.Ulogovan = udc.chkLoggedin.Checked;
            }
            if (!string.IsNullOrEmpty(udc.FIELD_USERNAME.Text))
            {
                k.Username = udc.FIELD_USERNAME.Text;
            }
            else
            {
                k.Username = null;
            }
            k.Rola = (Rola)Convert.ToInt32(udc.CB_Role.SelectedValue);
            Response res = CommunicationManager.Instance.SearchUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_FND_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewGUIController.Instance.ShowFrmUsersWithList((List<Korisnik>)res.Result);
            }
            else if (res.Exception.GetType() == typeof(RecordNotFoundException))
            {
                MessageBox.Show(l.GetString("MSG_USR_FND_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
