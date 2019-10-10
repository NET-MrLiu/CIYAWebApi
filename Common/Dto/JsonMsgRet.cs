using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class JsonMsgRet
    {

        public bool status { get; set; }

        public string msg { get; set; }

        public object list { get; set; }

    }
}
