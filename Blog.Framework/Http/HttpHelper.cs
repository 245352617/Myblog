using Infrastructure.Common.Application;
using Infrastructure.Common.Config;
using Newtonsoft.Json;
using Ocelot.JwtAuthorize;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Security;
using Infrastructure.Common.Extension;
using Infrastructure.Common.Redis;

namespace Infrastructure.Common.Http
{
    /// <summary>
    /// HttpHelper
    /// </summary>
    public class HttpHelper
    {
        public static NHttpClientFactory clientFactory = new NHttpClientFactory();

        /// <summary>
        /// 同步GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <returns></returns>
        public static TDto HttpGet<TDto>(string url, Dictionary<string, string> headers = null, int timeout = 0, string contentType = "text/json")
        {
            var client = clientFactory.CreateHttpClient();
            return client.SendAsync<TDto>(HttpMethod.Get, url, "", headers, timeout, contentType);
        }

        /// <summary>
        /// 同步POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <param name="encoding">默认UTF8</param>
        /// <returns></returns>
        public static TDto HttpPost<TDto>(string url, string postData, Dictionary<string, string> headers = null, string contentType = "text/json", int timeout = 0)
        {
            var client = clientFactory.CreateHttpClient();
            return client.SendAsync<TDto>(HttpMethod.Post, url, postData, headers, timeout, contentType);
        }
    }
}
