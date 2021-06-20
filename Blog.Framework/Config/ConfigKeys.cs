using Infrastructure.Common.Redis;
using Infrastructure.Common.Tree;
using Infrastructure.Common.XML;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Infrastructure.Common.Data;
using MySqlHelper = Infrastructure.Common.Data.MySqlHelper;

namespace Infrastructure.Common.Config
{
    /// <summary>
    /// 获取redis配置
    /// </summary>
    public static class ConfigKeys
    {
        #region 变量

        //获取配置文件
        private static string dirName = string.Empty;
        private static string fileName = "BaseConfig.xml";
        private static FileInfo _fileInfo;
        public static FileInfo FileInfo
        {
            get
            {
                if (_fileInfo == null)
                {
                    if (string.IsNullOrEmpty(dirName))
                    {
                        dirName = Directory.GetCurrentDirectory().Substring(0, 1) + @":\website\";
                    }
                    GetFileName(dirName, fileName);
                }
                return _fileInfo;

            }
        }
        #endregion

        #region 获取配置参数:私有配置
        /// <summary>
        /// 获取配置参数:私有配置
        /// </summary>
        /// <param name="hospitalCode">医院编码</param>
        /// <param name="projectCode">项目编码</param>
        /// <param name="parameterKey">参数Key(对应配置文件中的键)</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public static string GetConfigParameter(string hospitalCode, string projectCode, string parameterKey, TimeSpan? expiry = default(TimeSpan?))
        {
            string cacheKey = "Config_" + hospitalCode + "_" + projectCode + "_" + parameterKey;
            string value = new RedisHelper().StringGet<string>(cacheKey);
            if (value == null)
            {
                var sql = @"SELECT  b.`Value` FROM `config_project` AS a 
                            INNER JOIN `config_keys` AS b ON a.`Id`=b.`ProjectId`
                            WHERE b.`HospitalCode`=@HospitalCode AND a.`Code`=@Code AND b.`Key`=@Key  LIMIT 1";
                var param = new List<MySqlParameter>()
                {
                    new MySqlParameter("@HospitalCode",hospitalCode),
                    new MySqlParameter("@Code",projectCode),
                    new MySqlParameter("@Key",parameterKey)
                };
                var obj = MySqlHelperNew.ExecuteScalar(XmlHelper.GetNodeInfoByNodeName(FileInfo.FullName, "ConnectionString"), CommandType.Text, sql, param.ToArray());
                if (obj != null)
                {
                    value = obj.ToString();
                    new RedisHelper().SetDefault<string>(cacheKey, value, expiry);
                }
            }
            return value;
        }
        #endregion

        #region 获取通用配置:通用配置
        /// <summary>
        /// 获取通用配置:通用配置
        /// </summary>
        /// <param name="projectCode">项目编码</param>
        /// <param name="parameterKey">参数Key(对应配置文件中的键)</param>
        /// <returns></returns>
        public static string GetGeneralConfiguration(string projectCode, string parameterKey, TimeSpan? expiry = default(TimeSpan?))
        {
            string cacheKey = "Config_" + projectCode + "_" + parameterKey;
            string value = new RedisHelper().StringGet<string>(cacheKey);

#if DEBUG
            if (parameterKey.ToLower() == "domain_gateway")
            {
                value = "http://127.0.0.1:8888";
            }
#endif
            if (value == null)
            {
                var sql = @"SELECT  b.`Value` FROM `config_project` AS a 
                            INNER JOIN `config_keys` AS b ON a.`Id`=b.`ProjectId`
                            WHERE  a.`Code`=@Code AND b.`Key`=@Key  LIMIT 1";
                var param = new List<MySqlParameter>()
                {
                    new MySqlParameter("@Code",projectCode),
                    new MySqlParameter("@Key",parameterKey)
                };
                var obj = MySqlHelperNew.ExecuteScalar(XmlHelper.GetNodeInfoByNodeName(FileInfo.FullName, "ConnectionString"), CommandType.Text, sql, param.ToArray());
                if (obj != null)
                {
                    value = obj.ToString();
                    new RedisHelper().SetDefault<string>(cacheKey, value, expiry);
                }
            }
            return value;
        }
        #endregion

        #region 扫描配置文件
        private static void GetFileName(string DirName, string FileName)
        {
            //文件夹信息
            DirectoryInfo dir = new DirectoryInfo(DirName);
            //如果非根路径且是系统文件夹则跳过
            if (null != dir.Parent && dir.Attributes.ToString().IndexOf("System") > -1)
            {
                return;
            }
            //取得所有文件
            FileInfo[] finfo = dir.GetFiles();
            string fname = string.Empty;
            for (int i = 0; i < finfo.Length; i++)
            {
                fname = finfo[i].Name;
                //判断文件是否包含查询名
                if (fname.IndexOf(FileName) > -1)
                {
                    _fileInfo = finfo[i];
                    return;
                }
            }
            //取得所有子文件夹
            DirectoryInfo[] dinfo = dir.GetDirectories();
            for (int i = 0; i < dinfo.Length; i++)
            {
                //查找子文件夹中是否有符合要求的文件
                GetFileName(dinfo[i].FullName, FileName);
            }
        }
        #endregion
    }
}
