using Common.Domain;
using Common.Localization;
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

        void Localize()
        {
            Langset l = Program.curr_lang;
            sdc.LABEL_NOTES.Text = l.GetString("Notes");
            sdc.LABEL_DATE.Text = l.GetString("Date");
            sdc.btAccept.Text = l.GetString("CLOSE");
        }

        public Control CreateServiceDetailsControl(Servisiranje s)
        {
            Langset l = Program.curr_lang;

            ServiceDetailsControl c = new ServiceDetailsControl();
            c.FIELD_NOTES.Text = s.Napomena;
            c.FIELD_NOTES.ReadOnly = true;
            c.DP_Date.Value = s.Datum;
            c.DP_Date.Enabled = false;
            c.btServiceItems.Click += (o, e) => { ViewGUIController.Instance.ShowFrmServiceItems(s.Stavke); };
            c.btAccept.Click += (o, e) => { c.ParentForm.Close(); };
            c.ttServiceItems.SetToolTip(c.btServiceItems, l.GetString("ServiceItems"));
            sdc = c;
            Localize();
            return sdc;
        }
    }
}
