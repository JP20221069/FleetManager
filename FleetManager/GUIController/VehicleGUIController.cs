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
    public class VehicleGUIController
    {
        private VehicleControl awc;
        private Vozilo veh;
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
        internal Control CreateAddVehicle()
        {
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += AddVehicle;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Active"));
            cbo.Add(new CBObject(1, "Inactive"));
            cbo.Add(new CBObject(2, "Checked in"));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            awc = c;
            return awc;
        }

        internal Control CreateVehicleDetails(Vozilo v)
        {
            VehicleControl c = new VehicleControl();
            //c.btAccept.Click += AddVehicle;
            c.CB_STATUS.Items.Add(v.Status.ToString());
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

            c.btAccept.Visible = false;
            c.CB_STATUS.Enabled = false;

            awc = c;
            return awc;
        }

        internal Control CreateSearchVehicle()
        {
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += SearchVehicle;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(-1, "N/A"));
            cbo.Add(new CBObject(0, "Active"));
            cbo.Add(new CBObject(1, "Inactive"));
            cbo.Add(new CBObject(2, "Checked in"));
            c.CB_STATUS.DataSource = cbo;
            c.CB_STATUS.DisplayMember = "Name";
            c.CB_STATUS.ValueMember = "Value";
            awc = c;
            return awc;
        }

        internal Control CreateAlterVehicle(Vozilo v)
        {
            veh = v;
            VehicleControl c = new VehicleControl();
            c.btAccept.Click += UpdateVehicle;
            List<CBObject> cbo = new List<CBObject>();
            cbo.Add(new CBObject(0, "Active"));
            cbo.Add(new CBObject(1, "Inactive"));
            cbo.Add(new CBObject(2, "Checked in"));
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
                MessageBox.Show("Successfully added vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Vehicle found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VehicleViewGUIController.Instance.SetDataSource((List<Vozilo>)res.Result);
            }
            else if(res.Exception.GetType()==typeof(RecordNotFoundException))
            {
                MessageBox.Show(res.Exception.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            VehicleViewGUIController.Instance.ShowAll();
            if (res.Exception == null)
            {
                MessageBox.Show("Successfully updated vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}