using Common.Domain;
using Common.Localization;
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
        Langset l = Program.curr_lang;
        internal Control CreateAddUser()
        {
            AddUserControl c = new AddUserControl();
            c.btAccept.Click += AddUser;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_USER")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_ADMIN")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_MOD")));
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
                MessageBox.Show(l.GetString("MSG_USR_ADD_SUCCESS"), l.GetString("TTL_INFO"),MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(new ExceptionLocalization(Program.curr_lang).LocalizeException(res.Exception),l.GetString("TTL_ERROR"),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
