using Common.Domain;
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
    internal class UserDetailsGUIController
    {
        UserDetailsControl udc;
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
        public Control CreateAddUser()
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Click += AddUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Korisnik"));
            cbo.Add(new CBObject(1, "Admin"));
            cbo.Add(new CBObject(2, "Moderator"));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            udc = c;
            c.chkLoggedin.Visible = false;
            return udc;
        }

        public Control CreateAlterUser(Korisnik usr)
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Click += AlterUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Korisnik"));
            cbo.Add(new CBObject(1, "Admin"));
            cbo.Add(new CBObject(2, "Moderator"));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.SelectedItem = c.CB_Role.Items[cbo.FindIndex(x => (int)x.Value == (int)usr.Rola)];
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            c.FIELD_USERNAME.Text = usr.Username;
            c.FIELD_PASSWORD.Text = usr.Password;
            udc = c;
            c.chkActive.Checked = (bool)usr.Aktivan;
            c.chkLoggedin.Visible = false;
            return udc;
        }

        public Control CreateUserDetails(Korisnik usr)
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Text = "CLOSE";
            c.btAccept.Click += (o,e)=> { c.ParentForm.Close(); };
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Korisnik"));
            cbo.Add(new CBObject(1, "Admin"));
            cbo.Add(new CBObject(2, "Moderator"));
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
            return udc;
        }

        public Control CreateSearchUser()
        {
            UserDetailsControl c = new UserDetailsControl();
            c.btAccept.Text = "ACCEPT";
            c.btAccept.Click += SearchUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Korisnik"));
            cbo.Add(new CBObject(1, "Admin"));
            cbo.Add(new CBObject(2, "Moderator"));
            cbo.Add(new CBObject(3, "N/A"));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.SelectedItem = c.CB_Role.Items[3];
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            c.FIELD_PASSWORD.Visible = false;
            c.LB_PASSWORD.Visible = true;
            c.chkLoggedin.Enabled = true;
            c.chkActive.ThreeState = true;
            c.chkLoggedin.ThreeState = true;
            c.chkActive.CheckState = CheckState.Indeterminate;
            c.chkLoggedin.CheckState = CheckState.Indeterminate;
            udc = c;
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
                MessageBox.Show("Successfully added user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Successfully altered user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            k.Rola = (int)udc.CB_Role.SelectedValue;
            Response res = CommunicationManager.Instance.SearchUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show("User found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewGUIController.Instance.SetDataSource((List<Korisnik>)res.Result);
            }
            else if (res.Exception.GetType() == typeof(RecordNotFoundException))
            {
                MessageBox.Show(res.Exception.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
