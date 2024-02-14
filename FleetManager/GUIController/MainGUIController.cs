using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.GUIController
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

        private MainGUIController()
        {
            //personGuiController = new PersonGuiController();
        }

        private FrmMain frmMain;
       // private PersonGuiController personGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain();
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
        }

        internal void ShowAddPersonPanel()
        {
            //frmMain.ChangePanel(personGuiController.CreateAddPerson());
        }
    }
}
