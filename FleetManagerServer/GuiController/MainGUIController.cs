using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.GuiController
{
    public class MainGUIController
    {
        private static MainGUIController instance;
        public static MainGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainGUIController();
                }
                return instance;
            }
        }

        internal void ShowLog()
        {
            LogGUIController.Instance.ShowFrmLog();
        }
    }
}
