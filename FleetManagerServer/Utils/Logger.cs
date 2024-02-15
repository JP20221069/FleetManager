using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.Utils
{
    [Serializable]
    public static class Logger
    {
        static List<LogEvent> events;
        public static bool started;
        public static void Start()
        {
            started = true;
            events = new List<LogEvent>();
        }

        public static void Stop()
        {
            started = true;
        }

        public static void Restart()
        {
            Stop();
            Start();
        }

        public static string GetLog()
        {
            string ret = "";
            foreach(LogEvent name in events)
            {
                ret += "[" + name.Time + "]";
                switch(name.Type)
                {
                    case EventType.Info:
                        ret += " +I ";
                        break;
                    case EventType.Error:
                        ret += " +E ";
                        break;
                    case EventType.Warning:
                        ret += " +W ";
                        break;
                }
                if (!name.IsServerEvent)
                {
                    ret += "<Source: TID: " + name.Source.TID + " Address: " + name.Source.IP + "> ";
                }
                else
                {
                    ret += " <SERVER> ";
                }
                ret += name.EventText + Environment.NewLine;
            }
            return ret;
        }

        public static void LogEvent(LogEvent l)
        {
            events.Add(l);
        }

    }
}
