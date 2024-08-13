using Common.Localization;
using FleetManager.Comms;
using FleetManager.GuiController;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager
{
    internal static class Program
    {
        public static Langset curr_lang;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += (o, e) => { CommunicationManager.Instance.Disconnect(); };
            curr_lang = Langset.FromFile("Languages/" + ConfigurationManager.AppSettings["Language"] + ".lang");
            LoginGUIController.Instance.ShowFrmLogin();
        }

        
    }
}
