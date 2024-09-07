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
    public class VehicleGUIController
    {
        Langset l = Program.curr_lang;
        private VehicleControl awc;
        private Vozilo veh;
        private ViewGUIController caller;
        private static VehicleGUIController instance;
        public static VehicleGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleGUIController();
                }
                return instance;
            }
        }

        void Localize()
        {
            awc.LABEL_BRAND.Text = l.GetString("Brand");
            awc.LABEL_CARRYWEIGHT.Text = l.GetString("Carryweight");
            awc.LABEL_LICENSE.Text = l.GetString("License");
            awc.LABEL_NAME.Text = l.GetString("Name");
            awc.LABEL_STATUS.Text = l.GetString("Status");
            awc.LABEL_TYPE.Text = l.GetString("Type");
            awc.btAccept.Text = l.GetString("ACCEPT");
        }

        internal Control CreateAddVehicle()
        {
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += AddVehicle;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_ACTIVE")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_INACTIVE")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_CHECKEDIN")));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            awc = c;
            Localize();
            return awc;
        }

        internal Control CreateVehicleDetails(Vozilo v)
        {
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += (o,e)=> { c.ParentForm.Close(); };
            c.btAccept.Text = l.GetString("CLOSE");
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_ACTIVE")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_INACTIVE")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_CHECKEDIN")));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            c.CB_STATUS.SelectedItem = c.CB_STATUS.Items[cbo.FindIndex(x => (int)x.Value == (int)v.Status)];
            c.FIELD_Brand.Text = v.Marka;
            c.FIELD_NAME.Text = v.Naziv;
            c.FIELD_TYPE.Text = v.Tip;
            c.FIELD_LICENSE.Text = v.RegBroj;
            c.FIELD_CARRYWEIGHT.Text = v.Nosivost.ToString();

            c.FIELD_Brand.ReadOnly = true;
            c.FIELD_NAME.ReadOnly = true;
            c.FIELD_TYPE.ReadOnly = true;
            c.FIELD_LICENSE.ReadOnly = true;
            c.FIELD_CARRYWEIGHT.ReadOnly = true;

            c.CB_STATUS.Enabled = false;

            c.btViewCheckins.Visible = true;
            c.btViewServicings.Visible = true;
            c.btViewServicings.Click += (o, e) => { ViewGUIController.Instance.ShowFrmServicings(v.Servisiranja); };
            c.btViewCheckins.Click += (o, e) => { ViewGUIController.Instance.ShowFrmVehicleCheckins(v.Zaduzenja); };
            c.ttCheckins.SetToolTip(c.btViewCheckins, l.GetString("Checkins"));
            c.ttService.SetToolTip(c.btViewServicings,l.GetString("Servicings"));

            awc = c;
            Localize();
            c.btAccept.Text = l.GetString("CLOSE");
            return awc;
        }

        internal Control CreateSearchVehicle(bool activeonly=false,bool mainform=false, ViewGUIController caller = null)
        {
            VehicleControl c = new VehicleControl();
            if(caller!=null)
            {
                this.caller = caller;
            }
            else
            {
                caller = ViewGUIController.Instance;
            }
            if (mainform == true)
            {
                c.btAccept.Click += SearchVehicleForMainForm;
            }
            else
            {
                c.btAccept.Click += SearchVehicle;
            }
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(-1, "N/A"));
            cbo.Add(new CBObject(0, l.GetString("ENUM_ACTIVE")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_INACTIVE")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_CHECKEDIN")));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            c.CB_STATUS.Enabled = true;
            if(activeonly)
            {
                c.CB_STATUS.SelectedIndex = 0;
                c.CB_STATUS.Enabled = false;
            }
            awc = c;
            Localize();
            return awc;
        }

        internal Control CreateSearchVehicleCheckins(ViewGUIController caller=null)
        {
            if (caller != null)
            {
                this.caller = caller;
            }
            else
            {
                caller = ViewGUIController.Instance;
            }
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += SearchVehicleCheckins;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(-1, "N/A"));
            cbo.Add(new CBObject(0, l.GetString("ENUM_ACTIVE")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_INACTIVE")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_CHECKEDIN")));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            c.CB_STATUS.SelectedIndex = 3;
            c.CB_STATUS.Enabled = false;
            awc = c;
            Localize();
            return awc;
        }


        internal Control CreateAlterVehicle(Vozilo v)
        {
            veh = v;
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += UpdateVehicle;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, l.GetString("ENUM_ACTIVE")));
            cbo.Add(new CBObject(1, l.GetString("ENUM_INACTIVE")));
            cbo.Add(new CBObject(2, l.GetString("ENUM_CHECKEDIN")));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            c.CB_STATUS.SelectedItem = c.CB_STATUS.Items[cbo.FindIndex(x => (int)x.Value == (int)v.Status)];
            c.FIELD_Brand.Text = v.Marka;
            c.FIELD_NAME.Text = v.Naziv;
            c.FIELD_TYPE.Text = v.Tip;
            c.FIELD_LICENSE.Text = v.RegBroj;
            c.FIELD_CARRYWEIGHT.Text = v.Nosivost.ToString();

            awc = c;
            Localize();
            return awc;
        }

        private void AddVehicle(object sender, EventArgs e)
        {
            Vozilo v = new Vozilo();
            v.ID = -1;
            v.Naziv = awc.FIELD_NAME.Text;
            v.Marka = awc.FIELD_Brand.Text;
            v.RegBroj = awc.FIELD_LICENSE.Text;
            v.Nosivost = (float)Convert.ToDouble(awc.FIELD_CARRYWEIGHT.Text);
            v.Status = (StatusVozila)Convert.ToInt32(awc.CB_STATUS.SelectedValue);
            v.Tip = awc.FIELD_TYPE.Text;
            Response res = CommunicationManager.Instance.AddVehicle(v);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_ADD_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchVehicle(object sender,EventArgs e)
        {
            Vozilo v = new Vozilo();
            v.ID = -1;
            v.Naziv = awc.FIELD_NAME.Text;
            v.Marka = awc.FIELD_Brand.Text;
            v.RegBroj = awc.FIELD_LICENSE.Text;
            if (!string.IsNullOrEmpty(awc.FIELD_CARRYWEIGHT.Text))
            {
                v.Nosivost = (float)Convert.ToDouble(awc.FIELD_CARRYWEIGHT.Text);
            }
            else
            {
                v.Nosivost = 0;
            }
            v.Status = (StatusVozila)Convert.ToInt32(awc.CB_STATUS.SelectedValue);
            v.Tip = awc.FIELD_TYPE.Text;
            Response res = CommunicationManager.Instance.SearchVehicle(v);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_FND_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                caller.SetDataSource((List<Vozilo>)res.Result);
            }
            else if(res.Exception.GetType()==typeof(RecordNotFoundException))
            {
                MessageBox.Show(l.GetString("MSG_VEH_FND_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchVehicleForMainForm(object sender, EventArgs e)
        {
            Vozilo v = new Vozilo();
            v.ID = -1;
            v.Naziv = awc.FIELD_NAME.Text;
            v.Marka = awc.FIELD_Brand.Text;
            v.RegBroj = awc.FIELD_LICENSE.Text;
            if (!string.IsNullOrEmpty(awc.FIELD_CARRYWEIGHT.Text))
            {
                v.Nosivost = (float)Convert.ToDouble(awc.FIELD_CARRYWEIGHT.Text);
            }
            else
            {
                v.Nosivost = 0;
            }
            v.Status = (StatusVozila)Convert.ToInt32(awc.CB_STATUS.SelectedValue);
            v.Tip = awc.FIELD_TYPE.Text;
            Response res = CommunicationManager.Instance.SearchVehicle(v);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_FND_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewGUIController.Instance.ShowFrmVehiclesWithList((List<Vozilo>)res.Result);
               
            }
            else if (res.Exception.GetType() == typeof(RecordNotFoundException))
            {
                MessageBox.Show(l.GetString("MSG_VEH_FND_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchVehicleCheckins(object sender, EventArgs e)
        {
            Vozilo v = new Vozilo();
            v.ID = -1;
            v.Naziv = awc.FIELD_NAME.Text;
            v.Marka = awc.FIELD_Brand.Text;
            v.RegBroj = awc.FIELD_LICENSE.Text;
            if (!string.IsNullOrEmpty(awc.FIELD_CARRYWEIGHT.Text))
            {
                v.Nosivost = (float)Convert.ToDouble(awc.FIELD_CARRYWEIGHT.Text);
            }
            else
            {
                v.Nosivost = 0;
            }
            v.Status = (StatusVozila)Convert.ToInt32(awc.CB_STATUS.SelectedValue);
            v.Tip = awc.FIELD_TYPE.Text;
            Response res = CommunicationManager.Instance.SearchVehicle(v);
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_FND_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ViewGUIController.Instance.SetDataSource((List<Vozilo>)res.Result);
                List<Zaduzenje> datasource = new List<Zaduzenje>();
                foreach(Vozilo name in (List<Vozilo>)res.Result)
                {
                    datasource.AddRange(name.Zaduzenja.FindAll(x => x.Aktivno == true));
                }
                caller.SetDataSource(datasource);
            }
            else if (res.Exception.GetType() == typeof(RecordNotFoundException))
            {
                MessageBox.Show("MSG_VEH_FND_FAIL", l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateVehicle(object sender, EventArgs e)
        {
            Vozilo v = new Vozilo();
            v.ID = veh.ID;
            v.Naziv = awc.FIELD_NAME.Text;
            v.Marka = awc.FIELD_Brand.Text;
            v.RegBroj = awc.FIELD_LICENSE.Text;
            v.Nosivost = (float)Convert.ToDouble(awc.FIELD_CARRYWEIGHT.Text);
            v.Status = (StatusVozila)Convert.ToInt32(awc.CB_STATUS.SelectedValue);
            v.Tip = awc.FIELD_TYPE.Text;
            Response res = CommunicationManager.Instance.AlterVehicle(v);
            ViewGUIController.Instance.ShowAllVehicles();
            if (res.Exception == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_UPD_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}