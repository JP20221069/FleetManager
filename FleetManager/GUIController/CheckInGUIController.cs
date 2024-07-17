using Common.Domain;
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
            return chc;
        }

        private void CheckinVehicle(object sender,EventArgs e)
        {
            string relacijaod = chc.FIELD_FINISH.Text;
            string relacijado = chc.FIELD_START.Text;
            string notes = chc.FIELD_NOTES.Text;
            Zaduzenje z = new Zaduzenje(-1, veh, usr, true,relacijaod,relacijado,DateTime.Now,DateTime.Now,notes);
            Response res = CommunicationManager.Instance.CheckinVehicle(z);
            if (res.Exception == null)
            {
                MessageBox.Show("Successfully checked in vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewGUIController.Instance.ShowAllVehicles();
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
