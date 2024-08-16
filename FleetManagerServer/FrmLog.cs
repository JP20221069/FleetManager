using FleetManagerCommon.Communication;
using FleetManagerServer.GuiController;
using FleetManagerServer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer
{
    public partial class FrmLog : Form
    {
        string logpath="";
        public FrmLog()
        {
            InitializeComponent();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            //if(Logger.started)
            //{
            timer1.Start();
            //}
            saveFileDialog1.InitialDirectory = "Logs";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = DateTime.Now.ToShortDateString()+".txt";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LogGUIController.Instance.DisplayLog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()!=DialogResult.Cancel)
            {
                string path = saveFileDialog1.FileName;
                string log = Logger.GetLog();
                StreamWriter mywriter; 
                try
                {
                    mywriter = new StreamWriter(path);
                    mywriter.Write(log);
                    mywriter.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(logpath!="")
            {
                string log = Logger.GetLog();
                StreamWriter mywriter;
                try
                {
                    mywriter = new StreamWriter(logpath);
                    mywriter.Write(log);
                    mywriter.Close();
                    MessageBox.Show("File saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    string path = saveFileDialog1.FileName;
                    string log = Logger.GetLog();
                    StreamWriter mywriter;
                    try
                    {
                        mywriter = new StreamWriter(path);
                        mywriter.Write(log);
                        mywriter.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()!=DialogResult.Cancel)
            {
                FIELD_CONSOLE.BackColor = colorDialog1.Color;
            }
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                FIELD_CONSOLE.ForeColor = colorDialog1.Color;
            }
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                FIELD_CONSOLE.Font = fontDialog1.Font;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindGUIController.Instance.frmLog = this;
            FindGUIController.Instance.ShowFindDialog();
        }
    }
}
