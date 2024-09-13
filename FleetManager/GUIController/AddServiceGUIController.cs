using Common.Domain;
using Common.Localization;
using FleetManager.Comms;
using FleetManager.Controls;
using FleetManager.Utils;
using FleetManagerCommon.Communication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class AddServiceGUIController
    {

        private AddServiceItemControl asi;
        private List<Servis> servisi;
        public Vozilo veh;
        Langset l = Program.curr_lang;
        private static AddServiceGUIController instance;
        public static AddServiceGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddServiceGUIController();
                }
                return instance;
            }
        }

        public AddServiceGUIController()
        {
            
        }

        internal Control CreateAddService()
        {

            Response res = CommunicationManager.Instance.GetAllServices();
            if(res.Exception==null)
            {
                AddServiceItemControl c = new AddServiceItemControl();
                c.btAdd.Click += AddService;
                servisi= (List<Servis>)res.Result;
                c.CB_SERVICE.DataSource = servisi;
                c.CB_SERVICE.DisplayMember = "Naziv";
                c.CB_SERVICE.ValueMember = "ID";
                asi = c;
                Localize();
                return c;
            }
            else
            {
                MessageBox.Show(new ExceptionLocalization(Program.curr_lang).LocalizeException(res.Exception), l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
           
        }

        void Localize()
        {
            asi.FIELD_DESCRIPTION.Text = l.GetString("DESCRIPTION");
            asi.FIELD_NAME.Text = l.GetString("NAME");
            asi.btAdd.Text = l.GetString("ADD");
        }

        internal Control CreateServiceItemDetails(StavkaServisiranja s)
        {
            AddServiceItemControl c = new AddServiceItemControl();
            c.btAdd.Click += (o,e)=> { c.ParentForm.Close(); };
            c.btAdd.Text = l.GetString("CLOSE");
            servisi = new List<Servis>();
            servisi.Add(s.Servis);
            c.CB_SERVICE.DataSource = servisi;
            c.CB_SERVICE.DisplayMember = "Naziv";
            c.CB_SERVICE.ValueMember = "ID";
            c.CB_SERVICE.SelectedIndex = 0;
            c.CB_SERVICE.Enabled = false;
            c.FIELD_DESCRIPTION.Text = s.Opis;
            c.FIELD_DESCRIPTION.ReadOnly = true;
            c.FIELD_NAME.Text = s.Naziv;
            c.FIELD_NAME.ReadOnly = true;
            asi = c;
            return c;
        }

        private void AddService(object sender,EventArgs e)
        {
            if (Validate())
            {
                string naziv = asi.FIELD_NAME.Text;
                string opis = asi.FIELD_DESCRIPTION.Text;
                StavkaServisiranja ss = new StavkaServisiranja(-1, servisi[asi.CB_SERVICE.SelectedIndex], veh, naziv, opis);
                ss.Servisiranje = ServiceGUIController.Instance.Servisiranje;
                ServiceGUIController.Instance.Servisiranje.Stavke.Add(ss);
                asi.ParentForm.Close();
            }
        }

        private bool Validate()
        {
            bool ret = true;
            if (string.IsNullOrWhiteSpace(asi.FIELD_NAME.Text))
            {
                MessageBox.Show(l.GetString("MSG_ITM_NAME_REQUIRED"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return ret;
        }
    }
}
