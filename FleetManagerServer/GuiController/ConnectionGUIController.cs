using FleetManagerServer.Properties;
using FleetManagerServer.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer.GuiController
{
    public class ConnectionGUIController
    {
        private static ConnectionGUIController instance;
        public static ConnectionGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionGUIController();
                }
                return instance;
            }
        }

        private FrmConnection frmConnection;

        internal void ShowFrmConnection()
        {
            while (true)
            {
                try
                {
                    frmConnection = new FrmConnection();
                    frmConnection.AutoSize = true;
                    frmConnection.btTestConnection.Click += BtTestConnection_Click;
                    frmConnection.FIELD_CONNECTION_STRING.Text = ConfigurationManager.ConnectionStrings["cs_main"].ToString();
                    frmConnection.FIELD_CONNECTION_STRING.ReadOnly = true;
                    frmConnection.FIELD_CONNECTION_STRING.BackColor = SystemColors.Window;
                    frmConnection.Show();
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void BtTestConnection_Click(object sender, EventArgs e)
        {
            frmConnection.lblstatus.Text = "Testing connection, please wait. . .";
            frmConnection.pbStatus.Visible = false;
            Cursor.Current = Cursors.WaitCursor;
            FleetManagerCommon.Comms.Message m = Controller.Instance.TestConnection();
            
            if (m.MessageType == FleetManagerCommon.Comms.MessageType.Success)
            {
                MessageBox.Show("Successfully connected to database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmConnection.lblstatus.Text = "Successfully tested.";
                frmConnection.pbStatus.Visible = true;
                frmConnection.pbStatus.Image = FleetManagerServer.Properties.Resources.tick;
            }
            else
            {
                MessageBox.Show("Could not connect to database.\n" + m.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmConnection.lblstatus.Text = "Test failed.";
                frmConnection.pbStatus.Visible = true;
                frmConnection.pbStatus.Image = FleetManagerServer.Properties.Resources.x;
            }
            Cursor.Current = Cursors.Default;

        }
    }
}
