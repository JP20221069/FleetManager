﻿using Common.Domain;
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
        //private void InstantiateControllers()
        //{

        //}
        private ViewGUIController()
        {

        }

        private void SetupButtonActions()
        {
            if (type == "CHECKINS")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowCheckinSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowUserCheckins(); };
                frmView.tsbCheckout.Click += (o, e) =>
                {
                    ViewGUIController.Instance.CheckOutVehicle();
                };
            }
            else if (type == "FREEVEHICLES")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowVehSearchView(true); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowFreeVehicles(); };
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowVehDetailsView(); };
                frmView.tsbCheckin.Click += (o, e) =>
                {
                    ViewGUIController.Instance.ShowCheckInView();
                };
            }
            else if (type == "SERVICE")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowVehSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowAllVehicles(); };
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowVehDetailsView(); };
                frmView.tsbService.Click += (o, e) =>
                {
                    ViewGUIController.Instance.ShowFrmService();
                };
            }
            else if (type == "VEHICLES")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowVehSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowAllVehicles(); };
                frmView.tsbDelete.Click += (o, e) =>
                {
                    DialogResult dr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ViewGUIController.Instance.DeleteVehicle();
                    }
                };
                frmView.tsbAlter.Click += (o, e) => { ViewGUIController.Instance.ShowVehAlterView(); };
                frmView.tsbNew.Click += (o, e) => { ViewGUIController.Instance.ShowNewVehView(); };
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowVehDetailsView(); };
            }
            else if (type == "USERS")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowUserSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowAllUsers(); };
                frmView.tsbAlter.Click += (o, e) => { ViewGUIController.Instance.ShowUserAlterView(); };
                frmView.tsbNew.Click += (o, e) => { ViewGUIController.Instance.ShowNewUserView(); };
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowUserDetailsView(); };
            }
            else if(type=="VEHCHECKINS")
            {
                frmView.tsbSearch.Click += (o, e) => { ViewGUIController.Instance.ShowUserSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ViewGUIController.Instance.ShowAllUsers(); };
            }
            else if(type=="VEHSERVICE")
            { 
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowServiceDetailsView(); };
            }
            else if (type=="VEHSERVICEITEMS")
            {
                frmView.tsbInspect.Click += (o, e) => { ViewGUIController.Instance.ShowServiceItemDetailsView(); };
            }
            else if (type=="VEHCHECKINS")
            {
                frmView.tsbInspect.Click += (o, e) => { };
            }
        }


        private void ShowHideButtons()
        {
            if (type != "VEHCHECKINS" && type != "VEHSERVICE" && type != "VEHSERVICEITEMS")
            {
                frmView.tsbSearch.Visible = true;
                frmView.tsbShowAll.Visible = true;
            }
            frmView.tsbInspect.Visible = true;
            if (MainGUIController.current_user.Rola == (int)Rola.Korisnik)
            {
                if (type == "CHECKINS")
                {
                    frmView.tsbCheckout.Visible = true;
                }
                else if (type == "FREEVEHICLES")
                {
                    frmView.tsbCheckin.Visible = true;
                }
                else if (type == "SERVICE")
                {
                    frmView.tsbService.Visible = true;
                }
            }
            else if (MainGUIController.current_user.Rola == (int)Rola.Moderator)
            {
                frmView.tsbAlter.Visible = true;
                frmView.tsbNew.Visible = true;
                frmView.tsbInspect.Visible = true;
                frmView.tsbDelete.Visible = true;
            }
            else if (MainGUIController.current_user.Rola == (int)Rola.Admin)
            {
                if (type == "VEHICLES")
                {
                    frmView.tsbDelete.Visible = true;
                }
                else if (type == "USERS")
                {
                    frmView.tsbAlter.Visible = true;
                    frmView.tsbNew.Visible = true;
                    frmView.tsbInspect.Visible = true;
                }
            }
        }

        public void ShowFrmVehicles()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicles View";
            type = "VEHICLES";
            ShowHideButtons();
            SetupButtonActions();
            ShowAll();
            frmView.ShowDialog();
        }

        public void ShowFrmVehiclesService()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicles View";
            type = "SERVICE";
            ShowHideButtons();
            SetupButtonActions();
            ShowAll();
            frmView.ShowDialog();
        }

        public void ShowFrmCheckins()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Check in View";
            type = "CHECKINS";
            ShowHideButtons();
            SetupButtonActions();
            ShowAll();
            frmView.ShowDialog();
        }

        public void ShowFrmFreeVehs()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Available vehicles";
            type = "FREEVEHICLES";
            ShowHideButtons();
            SetupButtonActions();
            ShowAll();
            frmView.ShowDialog();
        }

        public void ShowFrmUsers()
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Users";
            type = "USERS";
            ShowHideButtons();
            SetupButtonActions();
            ShowAll();
            frmView.ShowDialog();
        }

        internal void ShowFrmUsersWithList(List<Korisnik> result)
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Users View";
            type = "USERS";
            ShowHideButtons();
            SetupButtonActions();
            SetDataSource(result);
            frmView.ShowDialog();
        }

        internal void ShowFrmVehiclesWithList(List<Vozilo> result)
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicles View";
            type = "VEHICLES";
            ShowHideButtons();
            SetupButtonActions();
            SetDataSource(result);
            frmView.ShowDialog();
        }

        internal void ShowFrmServicings(List<Servisiranje> result)
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicle servicings View";
            type = "VEHSERVICE";
            ShowHideButtons();
            SetupButtonActions();
            SetDataSource(result);
            frmView.ShowDialog();
        }

        internal void ShowFrmServiceItems(List<StavkaServisiranja> result)
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Service items View";
            type = "VEHSERVICEITEMS";
            ShowHideButtons();
            SetupButtonActions();
            SetDataSource(result);
            frmView.ShowDialog();
        }

        internal void ShowFrmVehicleCheckins(List<Zaduzenje> result)
        {
            frmView = new FrmView();
            frmView.AutoSize = true;
            frmView.Text = "Vehicle check-ins View";
            type = "VEHCHECKINS";
            ShowHideButtons();
            SetupButtonActions();
            SetDataSource(result);
            frmView.ShowDialog();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {

        }

        public void ShowVehSearchView(bool activeonly = false)
        {
            FrmTool t = new FrmTool();
            t.Text = "Search";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateSearchVehicle(true));
            t.ShowDialog();
        }

        public void ShowUserSearchView()
        {
            FrmTool t = new FrmTool();
            t.Text = "Search";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(UserDetailsGUIController.Instance.CreateSearchUser());
            t.ShowDialog();
        }

        public void ShowCheckinSearchView()
        {
            FrmTool t = new FrmTool();
            t.Text = "Search";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateSearchVehicleCheckins());
            t.ShowDialog();
        }

        public void ShowCheckInView()
        {
            Vozilo v = ViewGUIController.Instance.GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show("No vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(v.Zaduzenja.Find(x=>x.Aktivno==true)!=null)
            {
                MessageBox.Show("Vehicle already checked in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                ServiceGUIController.Instance.veh = new Vozilo(v.ID, v.Tip, v.Marka, v.Status, v.RegBroj, v.Naziv, v.Nosivost, v.Zaduzenja, v.Servisiranja);
                ServiceGUIController.Instance.ShowFrmService();
            }
        }

        public void ShowVehAlterView()
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

        public void ShowUserAlterView()
        {
            Korisnik u = ViewGUIController.Instance.GetSelectedRowUser();
            if (u == null)
            {
                MessageBox.Show("No user selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = "Alter Vehicle record";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(UserDetailsGUIController.Instance.CreateAlterUser(u));
                t.ShowDialog();
            }
        }

        public void ShowNewVehView()
        {
            FrmTool t = new FrmTool();
            t.Text = "New Vehicle";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateAddVehicle());
            t.ShowDialog();
        }

        public void ShowNewUserView()
        {
            FrmTool t = new FrmTool();
            t.Text = "New User";
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(UserDetailsGUIController.Instance.CreateAddUser());
            t.ShowDialog();
        }

        public void ShowVehDetailsView()
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
                t.Text = "Vehicle details";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                VehicleGUIController vgc = new VehicleGUIController();
                t.ChangePanel(vgc.CreateVehicleDetails(v));
                t.ShowDialog();
            }
        }

        public void ShowUserDetailsView()
        {
            Korisnik u = ViewGUIController.Instance.GetSelectedRowUser();
            if (u == null)
            {
                MessageBox.Show("No user selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = "User details";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(UserDetailsGUIController.Instance.CreateUserDetails(u));
                t.ShowDialog();
            }
        }

        public void ShowServiceDetailsView()
        {
            Servisiranje s = ViewGUIController.instance.GetSelectedRowService();
            if (s == null)
            {
                MessageBox.Show("No servicing selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = "Service details";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(ServiceDetailsGUIController.Instance.CreateServiceDetailsControl(s));
                t.ShowDialog();
            }
        }

        private void ShowServiceItemDetailsView()
        {
            StavkaServisiranja s = ViewGUIController.instance.GetSelectedRowServiceItem();
            if (s == null)
            {
                MessageBox.Show("No item selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = "Item details";
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(AddServiceGUIController.Instance.CreateServiceItemDetails(s));
                t.ShowDialog();
            }
        }


        public void SetDataSource(object l)
        {
            var source = new BindingSource();
            if (type == "VEHICLES" || type == "SERVICE")
            {
                this.source = (List<Vozilo>)l;
                source.DataSource = (List<Vozilo>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
            }
            else if (type == "FREEVEHICLES")
            {
                this.source = (List<Vozilo>)l;
                source.DataSource = (List<Vozilo>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
            }
            else if (type == "USERS")
            {
                this.source = (List<Korisnik>)l;
                source.DataSource = (List<Korisnik>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
            }
            else if (type == "CHECKINS")
            {
                this.source = (List<Zaduzenje>)l;
                source.DataSource = (List<Zaduzenje>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
                frmView.dgwView.Columns["VremeRazduzenja"].Visible = false;
                frmView.dgwView.Columns["Aktivno"].Visible = false;
                //frmView.dgwView.Columns.Add(new DataGridViewColumn(new Data))
            }
            else if(type=="VEHCHECKINS")
            {
                this.source = (List<Zaduzenje>)l;
                source.DataSource = (List<Zaduzenje>)l;
                frmView.dgwView.DataSource = source;
                frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
            }
            else if(type=="VEHSERVICE")
            {
                this.source = (List<Servisiranje>)l;
                source.DataSource = (List<Servisiranje>)l;
                frmView.dgwView.DataSource = source;
               /* frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;*/
            }
            else if(type=="VEHSERVICEITEMS")
            {
                this.source = (List<StavkaServisiranja>)l;
                source.DataSource = (List<StavkaServisiranja>)l;
                frmView.dgwView.DataSource = source;
               /* frmView.dgwView.Columns["TableName"].Visible = false;
                frmView.dgwView.Columns["ColumnNames"].Visible = false;
                frmView.dgwView.Columns["Values"].Visible = false;*/
            }

        }

        public void ShowAll()
        {
            if (type == "VEHICLES" || type == "SERVICE")
            {
                ShowAllVehicles();
            }
            else if (type == "FREEVEHICLES")
            {
                ShowFreeVehicles();
            }
            else if (type == "CHECKINS")
            {
                ShowUserCheckins();
            }
            else if (type == "USERS")
            {
                ShowAllUsers();
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

        private Servisiranje GetSelectedRowService()
        {
            Servisiranje s = ((List<Servisiranje>)source)[frmView.dgwView.SelectedCells[0].RowIndex];
            return s;
        }

        private StavkaServisiranja GetSelectedRowServiceItem()
        {
            StavkaServisiranja s = ((List<StavkaServisiranja>)source)[frmView.dgwView.SelectedCells[0].RowIndex];
            return s;
        }

        public Korisnik GetSelectedRowUser()
        {
            Korisnik k = ((List<Korisnik>)source)[frmView.dgwView.SelectedCells[0].RowIndex];
            return k;
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

        public void ShowVehCheckins(Vozilo v)
        {
            SetDataSource(v.Zaduzenja);
        }
        public void ShowVehServicings(Vozilo v)
        {
            SetDataSource(v.Servisiranja);
        }

        public void ShowAllUsers()
        {
            Response res = CommunicationManager.Instance.GetAllUsers();
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

            Zaduzenje z = ViewGUIController.Instance.GetSelectedRowCheckin();
            z.VremeRazduzenja = DateTime.Now;
            if (z == null)
            {
                MessageBox.Show("No check-in or vehicle selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
