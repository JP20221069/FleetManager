using Common.Domain;
using FleetManager.Comms;
using FleetManager.Controls;
using FleetManagerCommon.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class ServiceGUIController
    {
        FrmService frmService;
        private FrmTool t;
        private AddServiceItemControl asc;
        public Vozilo veh;
        public Servisiranje Servisiranje;
        private static ServiceGUIController instance;
        public static ServiceGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceGUIController();
                }
                return instance;
            }
        }

        public ServiceGUIController()
        {
            this.Servisiranje = new Servisiranje();
            this.Servisiranje.Stavke = new List<StavkaServisiranja>();
        }

   /*     public ServiceGUIController(Vozilo v)
        {
            this.Servisiranje = new Servisiranje();
            this.Servisiranje.Stavke = new List<StavkaServisiranja>();
            this.veh = v;
        }*/

        public List<StavkaServisiranja> GetDataSource()
        {
            return Servisiranje.Stavke;
        }
        public DialogResult ShowAddServiceItem()
        {
            t = new FrmTool();
            t.Text = "Add Service Item";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            AddServiceGUIController.Instance.veh = veh;
            t.ChangePanel(AddServiceGUIController.Instance.CreateAddService());
            return t.ShowDialog();
        }

        public void RemoveServiceItem(int index)
        {
            if (Servisiranje.Stavke.Count > 0)
            {
                Servisiranje.Stavke.RemoveAt(index);
            }
        }

        public void ShowFrmService()
        {
            frmService = new FrmService();
            frmService.ShowDialog();
        }

        public void AddServicing()
        {
            Servisiranje.Napomena = frmService.FIELD_NOTES.Text;
            Servisiranje.Datum = frmService.DP_Date.Value;
            Servisiranje.Vozilo = veh;
            Response res = CommunicationManager.Instance.ServiceVehicle(Servisiranje);
            if (res.Exception == null)
            {
                MessageBox.Show("Successfully serviced vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
