using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer.GuiController
{
    public class FindGUIController
    {
        public FrmLog frmLog;
        private FindDialog findDialog;
        int match_index = -1;
        MatchCollection matchs;
        private static FindGUIController instance;
        public static FindGUIController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FindGUIController();
                }
                return instance;
            }
        }

        internal void ShowFindDialog()
        {
            findDialog = new FindDialog();
            findDialog.AutoSize = true;
            findDialog.btFindNext.Click += FindNext;
            findDialog.Show();
        }

        void FindNext(object sender, EventArgs e)
        {
            string direction = findDialog.rbUp.Checked ? "UP" : "DOWN";
            bool wraparound = findDialog.chkWrapAround.Checked;
            int cursor = frmLog.FIELD_CONSOLE.SelectionStart;
            RegexOptions ro = findDialog.chkMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
            Regex r = new Regex(findDialog.FIELD_FIND.Text,ro);
            MatchCollection matchs = r.Matches(frmLog.FIELD_CONSOLE.Text);
            if(matchs.Count==0)
            {
                MessageBox.Show("Cannot find '" + findDialog.FIELD_FIND.Text + "'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(direction=="UP")
                {
                    if(match_index==-1)
                    {
                        for(int i=matchs.Count-1;i>=0;i--)
                        {
                            if (matchs[i].Index<=cursor)
                            {
                                match_index = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if(match_index>0 && (wraparound==false || wraparound==true))
                        {
                            match_index--;
                        }
                        else if (match_index == 0 && wraparound == true)
                        {
                            match_index = matchs.Count - 1;
                        }
                        else
                        {
                            MessageBox.Show("Cannot find '" + findDialog.FIELD_FIND.Text + "'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                else
                {
                    if (match_index == -1)
                    {
                        for (int i = 0; i < matchs.Count; i++)
                        {
                            if (matchs[i].Index >= cursor)
                            {
                                match_index = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (match_index < matchs.Count - 1 && (wraparound == false || wraparound==true))
                        {
                            match_index++;
                        }
                        else if(match_index >= matchs.Count - 1 && wraparound == true)
                        {
                            match_index = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cannot find '" + findDialog.FIELD_FIND.Text + "'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                frmLog.FIELD_CONSOLE.Focus();
                frmLog.FIELD_CONSOLE.Select(matchs[match_index].Index, matchs[match_index].Length);
            }
        }

        internal void ClearSearch()
        {
            match_index = -1;
        }
    }
}
