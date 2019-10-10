using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class JsonManage
    {

        public static void succes(JsonMsgRet JsonDto)
        {
            JsonDto.status = true;
            JsonDto.msg = "succes";
        }

        public static void erro(JsonMsgRet JsonDto, string msg)
        {
            JsonDto.status = false;
            JsonDto.msg = msg;
        }

    }
}
