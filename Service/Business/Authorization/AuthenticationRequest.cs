using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Service.Business.Authorization
{
    public class AuthenticationRequest
    {
        /// <summary>
        /// 根据钉钉用户授权码,应用key,应用授权码获取Token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Appkey"></param>
        /// <param name="Appsecret"></param>
        /// <returns></returns>
        public static string GetDingToken(string code, string Appkey, string Appsecret)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest request = new OapiGettokenRequest();
            request.Appkey = Appkey;
            request.Appsecret = Appsecret;
            request.SetHttpMethod("GET");
            OapiGettokenResponse response = client.Execute(request);
            string token = response.AccessToken;
            return token;
        }

        /// <summary>
        /// 根据钉钉用户授权码以及Token获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetDingUser(string code, string token)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
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
            return response2.Body;
        }

        /// <summary>
        /// 通过Token获取Ticket
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static OapiGetJsapiTicketResponse GetDingJsapiTicket(string token)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/get_jsapi_ticket");
            OapiGetJsapiTicketRequest request = new OapiGetJsapiTicketRequest();
            request.SetHttpMethod("GET");
            OapiGetJsapiTicketResponse execute = client.Execute(request, token);
            return execute;
        }

        /// <summary>
        /// 返回JSAPI鉴定信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="Url"></param>
        /// <param name="nonceStr"></param>
        /// <param name="agentld"></param>
        /// <param name="timeStamp"></param>
        /// <param name="corpld"></param>
        /// <returns></returns>
        public static object JsDingApiAuthorization(string token, string Url, string nonceStr, string agentld, string timeStamp, string corpld)
        {
            OapiGetJsapiTicketResponse Ticket = GetDingJsapiTicket(token);
            string signature = DingSign(Ticket.Ticket, nonceStr, timeStamp, Url);
            var obj = new
            {
                Url,
                nonceStr,
                agentld,
                timeStamp,
                corpld,
                signature
            };
            return obj;
        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="nonceStr"></param>
        /// <param name="timeStamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DingSign(string ticket, string nonceStr, string timeStamp, string url)
        {
            string plain = "jsapi_ticket=" + ticket + "&noncestr=" + nonceStr + "&timestamp=" + timeStamp
            + "&url=" + url;
            string signature = SHA1(plain, Encoding.UTF8);
            return signature;
        }
        /// <summary>  
        /// SHA1 加密，返回大写字符串  
        /// </summary>  
        /// <param name="content">需要加密字符串</param>  
        /// <param name="encode">指定加密编码</param>  
        /// <returns>返回40位大写字符串</returns>  
        public static string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();

                var sb = new StringBuilder();
                foreach (byte b in bytes_out)
                {
                    sb.Append(b.ToString("x2"));
                }
                //所有字符转为小写
                return sb.ToString().ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }


        public static string GetDingfDep(string token)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/list");
            OapiDepartmentListRequest request = new OapiDepartmentListRequest();
            request.Id="123";
            request.SetHttpMethod("GET");
            OapiDepartmentListResponse response = client.Execute(request, token);



            return "";
        }
    }
}
