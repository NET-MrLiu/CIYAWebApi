using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Business;
using Sugar.Enties;
using System.Web;

namespace WebApi.Controllers
{
    public class SignInController : ApiController
    {
        SignInManager SignIn = new SignInManager();
        public string GetLogin(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
                OapiGettokenRequest request = new OapiGettokenRequest();
                request.Appkey = "dingjl4zohfnzjnpqudc";
                request.Appsecret = "38H3T-CatuPEwnZOXq5ZhDIwqDFGye4vrxc36yLVZx7pfAumOmZBN0WSgbZB-A0-";
                request.SetHttpMethod("GET");
                OapiGettokenResponse response = client.Execute(request);
                string token = response.AccessToken;
                client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
                OapiUserGetuserinfoRequest request1 = new OapiUserGetuserinfoRequest();
                request1.Code = code;
                request1.SetHttpMethod("GET");
                OapiUserGetuserinfoResponse response1 = client.Execute(request1, token);
                String userId = response1?.Userid ?? null;

                client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get");
                OapiUserGetRequest request2 = new OapiUserGetRequest();
                request2.Userid = userId;
                request2.SetHttpMethod("GET");
                OapiUserGetResponse response2 = client.Execute(request2, token);
                string str = JsonConvert.SerializeObject(new { response2.Jobnumber, response2.ManagerUserId, response2.Name, response2.Roles, response2.Userid });
                return response2.Body;
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
