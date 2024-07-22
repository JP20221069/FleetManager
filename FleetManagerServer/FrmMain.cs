using FleetManagerServer.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer
{
    public partial class FrmMain : Form
    {
        Server s;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = new Server();
            s.Start();
            timer1.Start();
            btStart.Enabled = false;
            btStop.Enabled = true;
            lblStatus.Text = "ON";
            lblStatus.ForeColor = Color.ForestGreen;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void liveConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainGUIController.Instance.ShowLog();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "OFF";
            lblStatus.ForeColor = Color.Firebrick;
            timer1.Stop();
            s.Stop();
            btStart.Enabled = true;
            btStop.Enabled = false;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btStart.Enabled = true;
            btStop.Enabled = false;
        }

        private void btCopyIP_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FIELD_IP.Text+":"+FIELD_PORT.Text);
        }

        private void btCopyPort_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FIELD_PORT.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(s!=null)
            {
                if(s.Started)
                {
                    if(s.ClientCount==s.MaxClients-1)
                    {
                        lblClients.ForeColor = Color.Orange;
                    }
                    else if(s.ClientCount==s.MaxClients)
                    {
                        lblClients.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblClients.ForeColor = Color.Navy;
                    }
                    lblClients.Text = s.ClientCount + "/" + s.MaxClients;
                }
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionGUIController.Instance.ShowFrmConnection();
        }
    }
}
