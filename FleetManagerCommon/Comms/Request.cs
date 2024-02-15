using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Communication
{
    [Serializable]
    public class Request
    {
        public Operation Operation { get; set; }
        public object Argument { get; set; }

    }
}
