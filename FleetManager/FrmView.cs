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
    public partial class FrmView : Form
    {
        public FrmView()
        {
            InitializeComponent();
            dgwView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwView.MultiSelect = false;
            dgwView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgwView_RowPrePaint);
        }
        private void dgwView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {

        }

        private void FrmVehicles_Load(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowAll();
        }


        private void btDelete_Click(object sender, EventArgs e)
        {

        }

        private void btAlter_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowAlterView();
        }

        private void btCheckin_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowSearchView();
        }

        private void tsbShowAll_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowAll();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ViewGUIController.Instance.DeleteVehicle();
            }
        }

        private void tsbCheckin_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowCheckInView();
        }

        private void tsbCheckout_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.CheckOutVehicle();
        }

        private void tsbService_Click(object sender, EventArgs e)
        {
            ViewGUIController.Instance.ShowFrmService();
        }
    }
}
