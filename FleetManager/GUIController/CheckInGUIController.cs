using Common.Domain;
using Common.Localization;
using FleetManager.Comms;
using FleetManager.Controls;
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
    public class CheckInGUIController
    {
        Langset l = Program.curr_lang;
        public ViewGUIController caller;

        private CheckInControl chc;
        public Vozilo veh { get; set; }
        public Korisnik usr { get; set; }
        private static CheckInGUIController instance;
        public static CheckInGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CheckInGUIController();
                }
                return instance;
            }
        }

        public CheckInGUIController()
        {

        }

        internal Control CreateCheckIn()
        {
            CheckInControl c = new CheckInControl();
            chc = c;
            c.btAccept.Click += CheckinVehicle;
            Localize();
            return chc;
        }

        void Localize()
        {
            Langset l = Program.curr_lang;
            chc.btAccept.Text = l.GetString("ACCEPT");
            chc.LABEL_FINISH.Text = l.GetString("Finish");
            chc.LABEL_START.Text = l.GetString("Start");
            chc.LABEL_NOTES.Text = l.GetString("Notes");
            chc.chkActive.Text = l.GetString("ENUM_ACTIVE");
        }

        internal Control CreateCheckInDetails(Zaduzenje z)
        {
            CheckInControl c = new CheckInControl();
            chc = c;
            c.btAccept.Click += (o,e)=> { c.ParentForm.Close(); };
            c.btAccept.Text = l.GetString("CLOSE");
            c.FIELD_START.Text = z.RelacijaOd;
            c.FIELD_FINISH.Text = z.RelacijaDo;
            c.FIELD_NOTES.Text = z.Napomena;
            c.chkActive.Visible = true;
            c.chkActive.Checked = z.Aktivno;
            c.FIELD_START.ReadOnly = true;
            c.FIELD_FINISH.ReadOnly = true;
            c.FIELD_NOTES.ReadOnly = true;
            Localize();
            c.btAccept.Text = l.GetString("CLOSE");
            return chc;
        }

        private void CheckinVehicle(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (caller != null)
                {
                    this.caller = caller;
                }
                else
                {
                    caller = ViewGUIController.Instance;
                }
                string relacijaod = chc.FIELD_START.Text;
                string relacijado = chc.FIELD_FINISH.Text;
                string notes = chc.FIELD_NOTES.Text;
                Zaduzenje z = new Zaduzenje(-1, veh, usr, true, relacijaod, relacijado, DateTime.Now, DateTime.Now, notes);
                Response res = CommunicationManager.Instance.CheckinVehicle(z);
                if (res.Exception == null)
                {
                    MessageBox.Show(l.GetString("MSG_VEH_CHKIN_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    caller.ShowFreeVehicles();
                    chc.ParentForm.Close();
                }
                else
                {
                    MessageBox.Show(new ExceptionLocalization(Program.curr_lang).LocalizeException(res.Exception), l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validate()
        {
            bool ret = true;
            if (string.IsNullOrWhiteSpace(chc.FIELD_START.Text))
            {
                MessageBox.Show(l.GetString("MSG_CHKIN_START_REQUIRED"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(chc.FIELD_FINISH.Text))
            {
                MessageBox.Show(l.GetString("MSG_CHKIN_FINISH_REQUIRED"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return ret;
        }
    }
}
