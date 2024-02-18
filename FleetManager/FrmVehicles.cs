using Common.Domain;
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
    public partial class FrmVehicles : Form
    {
        public FrmVehicles()
        {
            InitializeComponent();
            dgwVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwVehicles.MultiSelect = false;
            dgwVehicles.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgwVehicles_RowPrePaint);
        }
        private void dgwVehicles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            VehicleViewGUIController.Instance.ShowSearchView();
        }

        private void FrmVehicles_Load(object sender, EventArgs e)
        {
            VehicleViewGUIController.Instance.ShowAll();
        }

        private void btShowAll_Click(object sender, EventArgs e)
        {
            VehicleViewGUIController.Instance.ShowAll();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                VehicleViewGUIController.Instance.DeleteVehicle();
            }
        }

        private void btAlter_Click(object sender, EventArgs e)
        {
            VehicleViewGUIController.Instance.ShowAlterView();
        }
    }
}
