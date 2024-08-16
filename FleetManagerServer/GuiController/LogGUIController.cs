using FleetManagerServer.Properties;
using FleetManagerServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer.GuiController
{
    public class LogGUIController
    {
        private static LogGUIController instance;
        public static LogGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogGUIController();
                }
                return instance;
            }
        }

        private FrmLog frmLog;

        internal void ShowFrmLog()
        {
            while (true)
            {
                try
                {
                    frmLog = new FrmLog();
                    frmLog.AutoSize = true;
                    frmLog.Show();
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        internal void DisplayLog()
        {
            if(Logger.started)
            {
                try
                {
                    frmLog.FIELD_CONSOLE.Text = Logger.GetLog();
                    frmLog.toolStripStatusLabel1.Image = Resources.tick;
                    frmLog.toolStripStatusLabel1.ToolTipText = "Logger connected.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLog.timer1.Stop();
                }
            }
            else
            {
                frmLog.toolStripStatusLabel1.Image = Resources.x;
                frmLog.toolStripStatusLabel1.ToolTipText = "Logger not started. Server might not have started yet.";
            }
        }

        
    }
}
