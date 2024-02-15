﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Utils
{
    public class CBObject
    {
        object value;
        string name;

        public object Value { get => value; set => value = value; }
        public string Name { get => name; set => name = value; }

        public CBObject()
        {
            
        }
        public CBObject(object value, string name)
        {
            this.value=value;
            this.name = name;
        }
    }
}
