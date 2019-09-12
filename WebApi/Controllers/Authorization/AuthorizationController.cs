using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Business.Authorization;
using Newtonsoft.Json;
namespace WebApi.Controllers.Authorization
{
    public class AuthorizationController : ApiController
    {

        [HttpPost]
        public string GetAuthorizationJspApi(string code, string Url)
        {

            string Appsecret = System.Configuration.ConfigurationManager.AppSettings["SinginAppsecret"] ?? "";
            string AppKey = System.Configuration.ConfigurationManager.AppSettings["CrmMobileAppkey"] ?? "";
            string CoroId = System.Configuration.ConfigurationManager.AppSettings["CoroId"] ?? "";
            string agentld = System.Configuration.ConfigurationManager.AppSettings["agentld"] ?? "";
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            string nonceStr = guid.ToString();
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string timeStamp = ts.ToString();
            string token = AuthenticationRequest.GetDingToken(code, AppKey, Appsecret);
            var obj = AuthenticationRequest.JsDingApiAuthorization(token, Url, nonceStr, agentld, timeStamp, CoroId);
            return JsonConvert.SerializeObject(obj);
        }
    }
}
