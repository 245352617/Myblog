using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Common.Config
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration;
        /// <summary>
        /// 获取某个配置节点的值
        /// </summary>
        /// <param name="key">配置节点</param>
        /// <returns>配置节点的值</returns>
        public static string GetSetting(string key)
        {
            try
            {
                return Configuration.GetSection(key).Value;
            }
            catch
            { 
            
            }
            return string.Empty;
        }
        /// <summary>
        /// 平台接口API
        /// </summary>
        public static string WebApiHost => GetSetting("WebApiHost") + "";
        /// <summary>
        /// 第三方接口API
        /// </summary>
        public static string ThirdParty => GetSetting("ThirdParty")+"";
        /// <summary>
        /// 机构编码
        /// </summary>
        public static string HospitalCode => GetSetting("HospitalCode") + "";
        /// <summary>
        /// 平台接口API
        /// </summary>
        public static string PlamWebApiHost => GetSetting("PlamWebApiHost") + "";

    }
}
