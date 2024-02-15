using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.Utils
{
    [Serializable]
    public enum EventType
    {
        Error,
        Info,
        Warning
    }
    [Serializable]
    public class LogEvent
    {
        Client source;
        EventType type;
        string event_text;
        DateTime time;
        bool is_server_event;

        public Client Source { get { return this.source; } set { this.source = value; } }
        public EventType Type { get { return this.type; } set { this.type = value; } }
        public string EventText { get { return this.event_text; } set { this.event_text = value; } }
        public DateTime Time { get { return this.time; } set { this.time = value; } }
        public bool IsServerEvent { get { return this.is_server_event; } set { this.is_server_event = value; } }
        public LogEvent()
        {
            
        }

        public LogEvent(EventType t,string text, Client s=null, bool is_server_event=false)
        {
            this.source = s;
            this.type = t;
            this.event_text = text;
            this.is_server_event = is_server_event;
            this.time = DateTime.Now;
        }

    }
}
