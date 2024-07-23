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
    public class ViewGUIController
    {

        FrmView frmView;
        string type;
        object source;
        private static ViewGUIController instance;
        public static ViewGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViewGUIController();
                }
                return instance;
            }
        }
        private void InstantiateControllers()
        {

        }
        private ViewGUIController()
        {
            InstantiateControllers();
        }

        private void ShowHideButtons()
        {
            frmView.tsbSearch.Visible = true;
            if(MainGUIController.current_user.Rola==(int)Rola.Korisnik)
            {
                if (type == "CHECKINS")
                {
                    frmView.tsbCheckout.Visible = true;
                }
                else if(type=="FREEVEHICLES")
                {
                    frmView.tsbCheckin.Visible = true;
                }
                else if(type=="SERVICE")
                {
                    frmView.tsbService.Visible = true;
                }
            }
            else if(MainGUIController.current_user.Rola==(int)Rola.Moderator)
            {
                frmView.tsbAlter.Visible = true;
                //Dodati New i inspect.
                frmView.tsbDelete.Visible = true;
            }
            else if(MainGUIController.current_user.Rola==(int)Rola.Admin)
            {
                frmView.tsbDelete.Visible = true;
            }
        }

        public void ShowFrmVehicles()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicles View";
            type = "VEHICLES";
            ShowHideButtons();
            frmView.ShowDialog();
        }

        public void ShowFrmCheckins()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Check in View";
            type = "CHECKINS";
            ShowHideButtons();
            frmView.ShowDialog();
        }

        public void ShowFrmFreeVehs()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Available vehicles";
            type = "FREEVEHICLES";
            ShowHideButtons();
            frmView.ShowDialog();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ShowSearchView()
        {
            FrmTool t = new FrmTool();
            t.Text = "Search";
            t.AutoSize=true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            VehicleGUIController vgc = new VehicleGUIController();
            t.ChangePanel(vgc.CreateSearchVehicle());
            t.ShowDialog();
        }

        public void ShowCheckInView()
        {
            Vozilo v = ViewGUIController.Instance.GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show("No vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = "Check in Vehicle";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                CheckInGUIController.Instance.veh = v;
                CheckInGUIController.Instance.veh = v;
                CheckInGUIController.Instance.usr = MainGUIController.current_user;
                t.ChangePanel(CheckInGUIController.Instance.CreateCheckIn());
                t.ShowDialog();
            }
        }

        public void ShowFrmService()
        {
            Vozilo v = ViewGUIController.Instance.GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show("No vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ServiceGUIController.Instance.veh = new Vozilo(v.ID,v.Tip,v.Marka,v.Status,v.RegBroj,v.Naziv,v.Nosivost,v.Zaduzenja,v.Servisiranja);
                ServiceGUIController.Instance.ShowFrmService();
            }
        }

        public void ShowAlterView()
        {
            Vozilo v = ViewGUIController.Instance.GetSelectedRowVehicle();
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

        public void SetDataSource(object l)
        {
            var source = new BindingSource();
            if (type == "VEHICLES")
            {
                this.source= (List<Vozilo>)l;
                source.DataSource = (List<Vozilo>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
            }
            else if(type=="FREEVEHICLES")
            {
                this.source = (List<Vozilo>)l;
                source.DataSource = (List<Vozilo>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
            }
            else if(type=="CHECKINS")
            {
                this.source= (List<Zaduzenje>)l;
                source.DataSource = (List<Zaduzenje>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
               frmView.dgwView.Columns["Values"].Visible = false;
            }

        }

        public void ShowAll()
        {
            if(type=="VEHICLES")
            {
                ShowAllVehicles();
            }
            else if(type=="FREEVEHICLES")
            {
                ShowFreeVehicles();
            }
            else if(type=="CHECKINS")
            {
                ShowUserCheckins();
            }
        }

        public Vozilo GetSelectedRowVehicle()
        {
            Vozilo v = ((List<Vozilo>)source)[frmView.dgwView.SelectedCells[0].RowIndex];
            return v;
        }

        public Zaduzenje GetSelectedRowCheckin()
        {
            Zaduzenje z = ((List<Zaduzenje>)source)[frmView.dgwView.SelectedCells[0].RowIndex];
            return z;
        }

        public void ShowAllVehicles()
        {
            Response res = CommunicationManager.Instance.GetAllVehicles();
            if (res.Exception == null)
            {
                SetDataSource(res.Result);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowFreeVehicles()
        {
            Response res = CommunicationManager.Instance.GetFreeVehicles();
            if (res.Exception == null)
            {
                SetDataSource(res.Result);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowUserCheckins()
        {
            Response res = CommunicationManager.Instance.GetUserCheckins(MainGUIController.current_user);
            if (res.Exception == null)
            {
                SetDataSource(res.Result);
            }
            else
            {
                MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void DeleteVehicle()
        {
            Vozilo v = GetSelectedRowVehicle();
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
                    ViewGUIController.Instance.ShowAllVehicles();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void CheckOutVehicle()
        {
            Zaduzenje z = GetSelectedRowCheckin();
            z.VremeRazduzenja = DateTime.Now;
            if (z == null)
            {
                MessageBox.Show("No check-in selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Response res = CommunicationManager.Instance.CheckoutVehicle(z);
                if (res.Exception == null)
                {
                    MessageBox.Show("Successfully checked out vehicle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewGUIController.Instance.ShowAll();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
