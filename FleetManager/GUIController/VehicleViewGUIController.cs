using Common.Domain;
using FleetManager.Comms;
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
    public class VehicleViewGUIController
    {

        FrmVehicles frmVehicles;
        private static VehicleViewGUIController instance;
        public static VehicleViewGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleViewGUIController();
                }
                return instance;
            }
        }
        private void InstantiateControllers()
        {

        }
        private VehicleViewGUIController()
        {
            InstantiateControllers();
        }

        public void ShowFrmVehicles()
        {
            frmVehicles = new FrmVehicles();
            frmVehicles.AutoSize = true;
            frmVehicles.ShowDialog();
        }

        public void ShowSearchView()
        {
            FrmTool t = new FrmTool();
            t.Text = "Search";
            t.AutoSize=true;
            t.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            VehicleGUIController vgc = new VehicleGUIController();
            t.ChangePanel(vgc.CreateSearchVehicle());
            t.ShowDialog();
        }

        public void ShowAlterView()
        {
            Vozilo v = VehicleViewGUIController.Instance.GetSelectedRow();
            if (v == null)
            {
                MessageBox.Show("No vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                VehicleGUIController.Instance.CreateAlterVehicle(v);
                FrmTool t = new FrmTool();
                t.Text = "Alter";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                VehicleGUIController vgc = new VehicleGUIController();
                t.ChangePanel(vgc.CreateAlterVehicle(v));
                t.ShowDialog();
            }
        }

        public void SetDataSource(List<Vozilo> l)
        {
            var source = new BindingSource();
            source.DataSource = l;
            frmVehicles.dgwVehicles.DataSource = source;
            frmVehicles.dgwVehicles.Columns["TableName"].Visible = false;
            frmVehicles.dgwVehicles.Columns["Values"].Visible = false;
        }

        public Vozilo GetSelectedRow()
        {
            foreach(DataGridViewRow row in frmVehicles.dgwVehicles.SelectedRows)
            {
                Vozilo v = new Vozilo(Convert.ToInt32(row.Cells[0].Value), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), (StatusVozila)Convert.ToInt32(row.Cells[3].Value),row.Cells[4].Value.ToString(),row.Cells[5].Value.ToString(),(float)Convert.ToDouble(row.Cells[6].Value),null,null);
                return v;
            }
            return null;
        }

        public void ShowAll()
        {
            Response res = CommunicationManager.Instance.GetAllVehicles();
            if (res.Exception == null)
            {
                SetDataSource((List<Vozilo>)res.Result);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteVehicle()
        {
            Vozilo v = GetSelectedRow();
            if (v == null)
            {
                MessageBox.Show("No vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Response res = CommunicationManager.Instance.DeleteVehicle(v);
                if (res.Exception == null)
                {
                    MessageBox.Show("Successfully deleted vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VehicleViewGUIController.Instance.ShowAll();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
