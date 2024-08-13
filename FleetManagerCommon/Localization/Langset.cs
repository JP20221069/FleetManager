using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Localization
{
    public class Langset
    {
        Dictionary<string,string> dict;
        string name;
        Dictionary<string,string> Dictionary { get { return this.dict; } set { this.dict = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public Langset(string name, Dictionary<string,string> dct)
        {
            this.dict = dct;
            this.name = name;
        }

        public Langset()
        {

        }

        public static Langset FromFile(string path)
        {
            StreamReader myreader = null;
            try
            {
                myreader = new StreamReader(path);
                Dictionary<string, string> temp = new Dictionary<string, string>();

                string temp_name = "";
                while (!myreader.EndOfStream)
                {
                    string line = myreader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line) == true)
                    {
                        continue;
                    }
                    else if (line[0] == '#')
                    {
                        continue;
                    }
                    string[] lines = line.Split('=');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].Trim();
                    }

                    if (line[0] == '$' && lines[0] == "$NAME")
                    {
                        temp_name = lines[1];
                    }
                    else
                    {
                        temp.Add(lines[0], lines[1]);
                    }
                }
                return new Langset(temp_name, temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myreader.Close();
            }
        }

        public string GetString(string key)
        {
            try
            {
                return this.Dictionary[key];
            }
            catch (KeyNotFoundException exx)
            {
                throw new Exception("No such entry for '" + key +"'.");
            }
        }

        public void LocalizeColumns(DataGridView dgw)
        {
            foreach (DataGridViewColumn name in dgw.Columns)
            {
                try
                {
                    name.HeaderText = GetString(name.HeaderText);
                }
                catch (Exception ex)
                {
                    name.HeaderText = "NULL";
                }
            }
        }
    }
}
