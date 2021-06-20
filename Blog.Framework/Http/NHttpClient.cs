using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Application;
using Infrastructure.Common.Config;
using Infrastructure.Common.Extension;
using Infrastructure.Common.Redis;
using Infrastructure.Common.Security;

namespace Infrastructure.Common.Http
{
    public class NHttpClient : INHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;
        public NHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        private static readonly string Host = ConfigHelper.WebApiHost;
        private static readonly string AuthUrl = Host + "/auth/Login/Authenticate";
        private static readonly string LoginApi = Host + "/user/SysAccount/Login";
        private static readonly string HHost = ConfigHelper.ThirdParty;
        private static readonly string HAuthUrl = HHost + "/HAuthorize/Token/Login";

        private static readonly object Lock = new object();
        private static readonly object LockLogin = new object();
        private static readonly RedisHelper redisHelper = new RedisHelper();

        /// <summary>
        /// 调用平台网关认证
        /// </summary>
        private string AuthToken
        {
            get
            {
                var token = redisHelper.StringGet("HAuthToken");
                if (!string.IsNullOrEmpty(token)) return token;
                lock (Lock)
                {
                    var result = SendAsync<Result<M_LoginResult>>(HttpMethod.Post, AuthUrl, new M_Login
                    {
                        LoginName = "SZXYS",
                        Password = "GsjcS0csXHRuuETyGgNd7kOFcJJAAhTH"
                    }.ToJsonStr());
                    if (!result.Success) throw new Exception("接口认证失败");
                    token = result.Data.Token;
                    redisHelper.StringSet("HAuthToken", token, new TimeSpan(0, 30, 0));
                }
                return token;
            }
        }

        /// <summary>
        /// 调用平台接口登录注册
        /// </summary>
        private string LoginToken
        {
            get
            {
                var token = redisHelper.StringGet("HLoginToken");
                if (!string.IsNullOrEmpty(token)) return token;
                lock (LockLogin)
                {
                    var vcode = RSAHelper.RSAEncrypt("custom|rmyy");
                    var loginInfo = SendAsync<Result<M_AccountLoginInfo>>(HttpMethod.Post, LoginApi, new
                    {
                        AccountName = "szxys",
                        Pwd = "szxys.123",
                        VerificationCode = vcode
                    }.ToJsonStr());
                    if (!loginInfo.Success) throw new Exception(loginInfo.Message);
                    token = loginInfo.Data.LGuid;
                    redisHelper.StringSet("HLoginToken", token, new TimeSpan(0, 30, 0));
                }
                return token;
            }
        }

        /// <summary>
        /// 调用医院网关认证
        /// </summary>
        private string HAuthToken
        {
            get
            {
                var token = redisHelper.StringGet("HHAuthToken");
                if (!string.IsNullOrEmpty(token)) return token;
                lock (Lock)
                {
                    var result = SendAsync<Result<string>>(HttpMethod.Post, HAuthUrl, new M_Login
                    {
                        LoginName = "xys",
                        Password = "3f2a28b7fd3c34ebd66e5bbe71939e7c59987734221aadbe4bd379562842f12c"
                    }.ToJsonStr());
                    if (!result.Success) throw new Exception("接口认证失败");
                    token = result.Data;
                    redisHelper.StringSet("HHAuthToken", token, new TimeSpan(0, 30, 0));
                }
                return token;
            }
        }

        public TDto SendAsync<TDto>(HttpMethod method, string url, string data = "", Dictionary<string, string> headers = null, int timeout = 0, string contentType = "text/json")
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post,
                new Uri(url));
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
                if (url.Contains(ConfigHelper.WebApiHost))
                {
                    if (AuthUrl != url)
                    {
                        request.Headers.Add("Authorization", "Bearer " + AuthToken);
                        if (LoginApi != url) request.Headers.Add("Token", LoginToken);
                    }
                }
                if (url.Contains(ConfigHelper.ThirdParty)&& !string.IsNullOrEmpty(ConfigHelper.ThirdParty))
                {
                    if (HAuthUrl != url)
                        request.Headers.Add("Authorization", "Bearer " + HAuthToken);
                }
                request.Method = method;
                if (!string.IsNullOrEmpty(data))
                {
                    request.Content = new StringContent(data);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                var client = _clientFactory.CreateClient();
                if (timeout > 0) client.Timeout = new TimeSpan(0, 0, timeout);
                using (var d = client.SendAsync(request))
                {
                    if (d.Result.IsSuccessStatusCode)
                    {
                        var result = d.Result.Content.ReadAsStringAsync().Result;
                        return result.ToObj<TDto>();
                    }
                    //if (d.Result.StatusCode == HttpStatusCode.Unauthorized)
                    //    return SendAsync<TDto>(method,url,data,headers,contentType,timeout);
                    throw new Exception(d.Result.StatusCode + "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("请求【{0}】出错", url) + "," + ex.Message, ex);
            }

        }
    }
    /// <summary>
    /// 用户登录信息
    /// </summary>
    public class M_Login
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class M_LoginResult
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
    }
}
