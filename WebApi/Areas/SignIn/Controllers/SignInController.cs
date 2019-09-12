using Newtonsoft.Json;
using Service.Business;
using Service.Business.Authorization;
using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApi.Areas.SignIn.Controllers
{
    public class SignInController : ApiController
    {
        SignInManager SignIn = new SignInManager();
        public string GetLogin(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                string Appsecret = System.Configuration.ConfigurationManager.AppSettings["SinginAppsecret"] ?? "";
                string AppKey = System.Configuration.ConfigurationManager.AppSettings["CrmMobileAppkey"] ?? "";
                string token = AuthenticationRequest.GetDingToken(code, AppKey, Appsecret);
                string user = AuthenticationRequest.GetDingUser(code, token);
                return user;
            }
            else
            {
                return "0";
            }
        }

        public string GetCustomer(string id)
        {
            var list = SignIn.GetCustomerBusiness(id);
            return JsonConvert.SerializeObject(list);
        }
        [HttpPost]
        public string PostAddSigin(CRM_SignIn sign)
        {
            try
            {
                string userid = HttpContext.Current.Request.Form["userid"].ToString();
                int count = SignIn.AddSigin(sign, userid);
                if (count == 0)
                {
                    return "签到数据插入失败！";
                }
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
            return "1";
        }

        public string GetSignInInfo(string userid)
        {
            var list = SignIn.SignInInfo(userid);
            return JsonConvert.SerializeObject(list);
        }

        public string GetItem(int code)
        {
            return JsonConvert.SerializeObject(SignIn.SignInItemByCode(code));
        }

        public string GetEdit(string record, string image_path, int id)
        {
            try
            {
                SignIn.SignInItemEdit(record, image_path, id);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "1";
        }
    }
}
