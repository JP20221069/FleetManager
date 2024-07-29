using FleetManager.Comms;
using FleetManager.GuiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += (o, e) => { CommunicationManager.Instance.Disconnect(); };
            LoginGUIController.Instance.ShowFrmLogin();
        }

        
    }
}
