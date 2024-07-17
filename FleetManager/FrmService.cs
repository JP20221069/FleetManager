using FleetManager.GUIController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class FrmService : Form
    {
        public FrmService()
        {
            InitializeComponent();
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            //Iz nekog razloga, datasource ne zeli da se refreshuje iz guicontrollera.
            ServiceGUIController.Instance.RemoveServiceItem(LBX_ServiceItems.SelectedIndex);
            LBX_ServiceItems.DataSource = null;
            LBX_ServiceItems.DataSource = ServiceGUIController.Instance.GetDataSource();
            LBX_ServiceItems.DisplayMember = "Naziv";
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            DialogResult dr = ServiceGUIController.Instance.ShowAddServiceItem();
            LBX_ServiceItems.DataSource = null;
            LBX_ServiceItems.DataSource=ServiceGUIController.Instance.GetDataSource();
            LBX_ServiceItems.DisplayMember = "Naziv";
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            ServiceGUIController.Instance.AddServicing();
        }
    }
}
