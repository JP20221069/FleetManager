using Common.Domain;
using FleetManager.Comms;
using FleetManager.Controls;
using FleetManager.Utils;
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
    public class AddUserGUIController
    {
        private AddUserControl auc;

        internal Control CreateAddUser()
        {
            AddUserControl c = new AddUserControl();
            c.btAccept.Click += AddUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Korisnik"));
            cbo.Add(new CBObject(1, "Admin"));
            cbo.Add(new CBObject(2, "Moderator"));
            c.CB_Role.DataSource = cbo;
            c.CB_Role.DisplayMember = "Name";
            c.CB_Role.ValueMember = "Value";
            auc = c;
            return auc;
        }

        private void AddUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Username = auc.FIELD_USERNAME.Text;
            k.Password = auc.FIELD_PASSWORD.Text;
            k.Aktivan = false;
            k.Ulogovan = false;
            Response res = CommunicationManager.Instance.AddUser(k);
            if (res.Exception == null)
            {
                MessageBox.Show("Successfully added user.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
