using Common.Domain;
using FleetManager.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager.GUIController
{
    public class ServiceDetailsGUIController
    {
        ServiceDetailsControl sdc;
        private static ServiceDetailsGUIController instance;
        public static ServiceDetailsGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceDetailsGUIController();
                }
                return instance;
            }
        }

        public Control CreateServiceDetailsControl(Servisiranje s)
        {
            ServiceDetailsControl c = new ServiceDetailsControl();
            c.FIELD_NOTES.Text = s.Napomena;
            c.FIELD_NOTES.ReadOnly = true;
            c.DP_Date.Value = s.Datum;
            c.DP_Date.Enabled = false;
            c.btServiceItems.Click += (o, e) => { ViewGUIController.Instance.ShowFrmServiceItems(s.Stavke); };
            c.btAccept.Click += (o, e) => { c.ParentForm.Close(); };
            sdc = c;
            return sdc;
        }
    }
}
