using FleetManager.Comms;
using FleetManager.Controls;
using FleetManager.Utils;
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
            c.FIELD_PASSWORD.Enabled = false;
            c.FIELD_USERNAME.Enabled = false;
            c.CB_Role.Enabled = false;
            udc = c;
            return udc;
        }

        private void AddUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Username = udc.FIELD_USERNAME.Text;
            k.Password = udc.FIELD_PASSWORD.Text;
            k.Aktivan = false;
            k.LoggedIn = false;
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
            k.Aktivan = false;
            k.LoggedIn = false;
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
    }
}
