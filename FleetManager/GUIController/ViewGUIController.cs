using Common.Domain;
using Common.Localization;
using FleetManager.Comms;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class ViewGUIController
    {
        Langset l = Program.curr_lang;
        public FrmView frmView { get; set; }
        public string type { get; set; }
        public string action { get; set; }
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

        public void Localize()
        {
            frmView.tsbSearch.Text = l.GetString("Search");
            frmView.tsbNew.Text = l.GetString("New");
            frmView.tsbShowAll.Text = l.GetString("ShowAll");
            frmView.tsbAlter.Text = l.GetString("Alter");
            frmView.tsbInspect.Text = l.GetString("Inspect_");
            frmView.tsbDelete.Text = l.GetString("Delete");
            frmView.tsbCheckin.Text = l.GetString("Check_in");
            frmView.tsbCheckout.Text = l.GetString("Check_out");
            frmView.tsbService.Text = l.GetString("Service");
            frmView.groupBox2.Text = l.GetString("View");

        }
        public void SetupButtonActions()
        {
            if (type == "CHECKINS")
            {
                frmView.tsbSearch.Click += (o, e) => { ShowCheckinSearchView(frmView); };
                frmView.tsbShowAll.Click += (o, e) => { ShowUserCheckins(); };
                frmView.tsbCheckout.Click += (o, e) =>
                {
                    CheckOutVehicle();
                };
            }
            else if (type == "FREEVEHICLES")
            {
                frmView.tsbSearch.Click += (o, e) => { ShowVehSearchView(true); };
                frmView.tsbShowAll.Click += (o, e) => { ShowFreeVehicles(); };
                frmView.tsbInspect.Click += (o, e) => { ShowVehDetailsView(); };
                frmView.tsbCheckin.Click += (o, e) =>
                {
                    ShowCheckInView();
                };
            }
            else if (type == "SERVICE")
            {
                frmView.tsbSearch.Click += (o, e) => { ShowVehSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ShowAllVehicles(); };
                frmView.tsbInspect.Click += (o, e) => { ShowVehDetailsView(); };
                frmView.tsbService.Click += (o, e) =>
                {
                    ShowFrmService();
                };
            }
            else if (type == "VEHICLES")
            {
                frmView.tsbSearch.Click += (o, e) => { ShowVehSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ShowAllVehicles(); };
                frmView.tsbDelete.Click += (o, e) =>
                {
                    DialogResult dr = MessageBox.Show(l.GetString("QST_AREYOUSURE"), l.GetString("TTL_QST"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        DeleteVehicle();
                    }
                };
                frmView.tsbAlter.Click += (o, e) => { ShowVehAlterView(); };
                frmView.tsbNew.Click += (o, e) => { ShowNewVehView(); };
                frmView.tsbInspect.Click += (o, e) => { ShowVehDetailsView(); };
            }
            else if (type == "USERS")
            {
                frmView.tsbSearch.Click += (o, e) => { ShowUserSearchView(); };
                frmView.tsbShowAll.Click += (o, e) => { ShowAllUsers(); };
                frmView.tsbAlter.Click += (o, e) => { ShowUserAlterView(); };
                frmView.tsbNew.Click += (o, e) => { ShowNewUserView(); };
                frmView.tsbInspect.Click += (o, e) => { ShowUserDetailsView(); };
            }
            else if(type=="VEHCHECKINS")
            {
                /*frmView.tsbSearch.Click += (o, e) => { ShowCheckinSearchView(frmView); };
                frmView.tsbShowAll.Click += (o, e) => { ShowVehCheckins(zaduzenja); };*/
                frmView.tsbInspect.Click += (o, e) => { ShowCheckinDetailsView(); };
            }
            else if(type=="VEHSERVICE")
            { 
                frmView.tsbInspect.Click += (o, e) => { ShowServiceDetailsView(); };
            }
            else if (type=="VEHSERVICEITEMS")
            {
                frmView.tsbInspect.Click += (o, e) => { ShowServiceItemDetailsView(); };
            }
        }

        internal void ShowCheckinDetailsView()
        {
            Zaduzenje z = GetSelectedRowCheckin();
            if (z == null)
            {
                MessageBox.Show(l.GetString("MSG_CHKIN_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_CHKIN_VIEW");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(CheckInGUIController.Instance.CreateCheckInDetails(z));
                t.ShowDialog();
            }
        }

        public void ShowHideButtons()
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
            else if (MainGUIController.current_user.Rola == Rola.Moderator)
            {
                frmView.tsbInspect.Visible = true;
                if(action=="ALTER" || action=="ALL")
                {
                    frmView.tsbAlter.Visible = true;
                }
                if(action=="NEW" || action == "ALL")
                {
                    frmView.tsbNew.Visible = true;
                }
                if(action=="DELETE" || action == "ALL")
                {
                    frmView.tsbDelete.Visible = true;
                }
            }
            else if (MainGUIController.current_user.Rola == Rola.Admin)
            {
                if (type == "VEHICLES")
                {
                    frmView.tsbDelete.Visible = true;
                }
                else if (type == "USERS")
                {
                    frmView.tsbInspect.Visible = true;
                    if (action == "ALTER" || action == "ALL")
                    {
                        frmView.tsbAlter.Visible = true;
                    }
                    if (action == "NEW" || action == "ALL")
                    {
                        frmView.tsbNew.Visible = true;
                    }
                }
            }
        }

        public void ShowFrmVehicles(string act="ALL")
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_VEH_VIEW");
            vgc.type = "VEHICLES";
            vgc.action = act;
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.ShowAll();
            vgc.frmView.ShowDialog();
        }

        public void ShowFrmVehiclesService()
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_VEH_VIEW");
            vgc.type = "SERVICE";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.ShowAll();
            vgc.frmView.ShowDialog();
        }

        public void ShowFrmCheckins()
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_CHKIN_VIEW");
            vgc.type = "CHECKINS";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.ShowAll();
            vgc.frmView.ShowDialog();
        }

        public void ShowFrmFreeVehs()
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_AVVEHS");
            vgc.type = "FREEVEHICLES";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.ShowAll();
            vgc.frmView.ShowDialog();
        }

        public void ShowFrmUsers(string act="ALL")
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_USRS");
            vgc.type = "USERS";
            vgc.action = act;
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.ShowAll();
            vgc.frmView.ShowDialog();
        }

        internal void ShowFrmUsersWithList(List<Korisnik> result,string act="ALL")
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_USR_VIEW");
            vgc.type = "USERS";
            vgc.action = act;
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.SetDataSource(result);
            vgc.frmView.ShowDialog();
        }

        internal void ShowFrmVehiclesWithList(List<Vozilo> result,string act="ALL")
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_VEH_VIEW");
            vgc.type = "VEHICLES";
            vgc.action = act;
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.SetDataSource(result);
            vgc.frmView.ShowDialog();
        }

        internal void ShowFrmServicings(List<Servisiranje> result)
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_VEH_SER_VIEW");
            vgc.type = "VEHSERVICE";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.SetDataSource(result);
            vgc.frmView.ShowDialog();
        }

        internal void ShowFrmServiceItems(List<StavkaServisiranja> result)
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_ITM_VIEW");
            vgc.type = "VEHSERVICEITEMS";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.SetDataSource(result);
            vgc.frmView.ShowDialog();
        }

        internal void ShowFrmVehicleCheckins(List<Zaduzenje> result)
        {
            ViewGUIController vgc = new ViewGUIController();
            vgc.frmView = new FrmView();
            vgc.frmView.AutoSize = true;
            vgc.frmView.Text = l.GetString("TTL_VEH_CHKINS_VIEW");
            vgc.type = "VEHCHECKINS";
            vgc.Localize();
            vgc.ShowHideButtons();
            vgc.SetupButtonActions();
            vgc.SetDataSource(result);
            vgc.frmView.ShowDialog();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {

        }

        public void ShowVehSearchView(bool activeonly = false)
        {
            FrmTool t = new FrmTool();
            t.Text = l.GetString("Search");
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateSearchVehicle(activeonly,caller:this));
            t.ShowDialog();
        }

        public void ShowUserSearchView()
        {
            FrmTool t = new FrmTool();
            t.Text = l.GetString("Search");
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(UserDetailsGUIController.Instance.CreateSearchUser(caller:this));
            t.ShowDialog();
        }

        public void ShowCheckinSearchView(FrmView frmView)
        {
            FrmTool t = new FrmTool();
            t.Text = l.GetString("Search");
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateSearchVehicleCheckins());
            t.ShowDialog();
        }

        public void ShowCheckInView()
        {
            Vozilo v = GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(v.Zaduzenja.Find(x=>x.Aktivno==true)!=null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_CHKIN_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_VEH_CHKIN");
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
            Vozilo v = GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ServiceGUIController.Instance.veh = new Vozilo(v.ID, v.Tip, v.Marka, v.Status, v.RegBroj, v.Naziv, v.Nosivost, v.Zaduzenja, v.Servisiranja);
                ServiceGUIController.Instance.ShowFrmService();
            }
        }

        public void ShowVehAlterView()
        {
            Vozilo v = GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                VehicleGUIController.Instance.CreateAlterVehicle(v);
                FrmTool t = new FrmTool();
                t.Text = l.GetString("Alter");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                VehicleGUIController vgc = new VehicleGUIController();
                t.ChangePanel(vgc.CreateAlterVehicle(v));
                t.ShowDialog();
            }
        }

        public void ShowUserAlterView()
        {
            Korisnik u = GetSelectedRowUser();
            if (u == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_VEH_ALTER");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(UserDetailsGUIController.Instance.CreateAlterUser(u));
                t.ShowDialog();
            }
        }

        public void ShowNewVehView()
        {
            FrmTool t = new FrmTool();
            t.Text = l.GetString("TTL_VEH_NEW");
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(VehicleGUIController.Instance.CreateAddVehicle());
            t.ShowDialog();
        }

        public void ShowNewUserView()
        {
            FrmTool t = new FrmTool();
            t.Text = l.GetString("TTL_USR_NEW");
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowOnly;
            t.ChangePanel(UserDetailsGUIController.Instance.CreateAddUser());
            t.ShowDialog();
        }

        public void ShowVehDetailsView()
        {
            Vozilo v = GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                VehicleGUIController.Instance.CreateAlterVehicle(v);
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_VEH_DETAILS");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                VehicleGUIController vgc = new VehicleGUIController();
                t.ChangePanel(vgc.CreateVehicleDetails(v));
                t.ShowDialog();
            }
        }

        public void ShowUserDetailsView()
        {
            Korisnik u = GetSelectedRowUser();
            if (u == null)
            {
                MessageBox.Show(l.GetString("MSG_USR_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_USR_DETAILS");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(UserDetailsGUIController.Instance.CreateUserDetails(u));
                t.ShowDialog();
            }
        }

        public void ShowServiceDetailsView()
        {
            Servisiranje s = GetSelectedRowService();
            if (s == null)
            {
                MessageBox.Show(l.GetString("MSG_SER_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_SER_DETAILS");
                t.AutoSize = true;
                t.AutoSizeMode = AutoSizeMode.GrowOnly;
                t.ChangePanel(ServiceDetailsGUIController.Instance.CreateServiceDetailsControl(s));
                t.ShowDialog();
            }
        }

        private void ShowServiceItemDetailsView()
        {
            StavkaServisiranja s = GetSelectedRowServiceItem();
            if (s == null)
            {
                MessageBox.Show(l.GetString("MSG_ITM_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmTool t = new FrmTool();
                t.Text = l.GetString("TTL_ITM_DETAILS");
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
                frmView.dgwView.Columns["Password"].Visible=false;
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
            Langset lang = Program.curr_lang;
            lang.LocalizeColumns(frmView.dgwView);
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
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowVehCheckins(List<Zaduzenje> zaduzenja)
        {
            SetDataSource(zaduzenja);
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
                MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteVehicle()
        {
            Vozilo v = GetSelectedRowVehicle();
            if (v == null)
            {
                MessageBox.Show(l.GetString("MSG_VEH_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Response res = CommunicationManager.Instance.DeleteVehicle(v);
                if (res.Exception == null)
                {
                    MessageBox.Show(l.GetString("MSG_VEH_DEL_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllVehicles();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void CheckOutVehicle()
        {

            Zaduzenje z = GetSelectedRowCheckin();
            z.VremeRazduzenja = DateTime.Now;
            if (z == null)
            {
                MessageBox.Show(l.GetString("MSG_CHKIN_SEL_FAIL"), l.GetString("TTL_WARNING"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Response res = CommunicationManager.Instance.CheckoutVehicle(z);
                if (res.Exception == null)
                {
                    MessageBox.Show(l.GetString("MSG_VEH_CHKOUT_SUCCESS"), l.GetString("TTL_INFO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAll();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, l.GetString("TTL_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


}
