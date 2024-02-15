using Common.Domain;
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
        private AddUserControl addPerson;

        internal Control CreateAddPerson()
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
            return addPerson;
        }

        private void AddUser(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            Response response = Communication.Instance.CreatePerson(person);
            if (response.Exception == null)
            {
                MessageBox.Show("Uspesno ste dodali osobu!");
            }
            else
            {
                Debug.WriteLine(response.Exception);
            }
        }
    }
}
