using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Extension
{
    public static class StringHelper
    {

        /// <summary>
        /// Removes first occurrence of the given postfixes from end of the given string.
        /// Ordering is important. If one of the postFixes is matched, others will not be tested.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="postFixes">one or more postfix.</param>
        /// <returns>Modified string or the same string if it has not any of given postfixes</returns>
        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            if (str == null)
            {
                return null;
            }

            if (str == string.Empty)
            {
                return string.Empty;
            }

            if (postFixes == null || postFixes.Length <= 0)
            {
                return str;
            }

            foreach (var postFix in postFixes)
            {
                if (str.EndsWith(postFix))
                {
                    return str.Substring(str.Length - postFix.Length);
                }
            }

            return str;
        }
        /// <summary>
        /// 安全转换为string
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">为空时的默认值</param>
        /// <returns></returns>
        public static string SafeString(object obj, string defaultValue = "")
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString())) return defaultValue;
            return obj.ToString();
        }

        /// <summary>
        /// 安全转换为日期的字符串格式（默认格式yyyy-MM-dd HH:mm:ss）
        /// </summary>
        /// <param name="datetime">日期</param>
        /// <param name="defaultValue">为空时默认值</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string SafeDataTimeNullString(DateTime? datetime, string defaultValue = "", string format = "yyyy-MM-dd HH:mm:ss")
        {
            DateTime defaultTime;
            if (!datetime.HasValue)
            {
                if (DateTime.TryParse(defaultValue, out defaultTime))
                {
                    return defaultTime.ToString(format);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return datetime.Value.ToString(format);
            }
        }
        /// <summary>
        /// 安全转换为短日期的字符串格式（默认格式yyyy-MM-dd）
        /// </summary>
        /// <param name="datetime">日期</param>
        /// <param name="defaultValue">为空时默认值</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string SafeShortDataTimeNullString(DateTime? datetime, string defaultValue = "", string format = "yyyy-MM-dd")
        {
            return SafeDataTimeNullString(datetime, defaultValue, format);
        }

        /// <summary>
        ///  安全转换为可空DataTime
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static DateTime? SafeDataTimeNull(string value, string defautvalue = "")
        {
            DateTime result;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!DateTime.TryParse(defautvalue, out result))
                {
                    return null;
                }
            }
            else
            {
                if (!DateTime.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!DateTime.TryParse(defautvalue, out result))
                    {
                        return null;
                    }
                }
            }
            return result;
        }
        /// <summary>
        ///  安全转换为DataTime
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static DateTime SafeDataTime(string value, string defautvalue = "")
        {
            DateTime min = Convert.ToDateTime("1900-01-01");
            DateTime result;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回min
            {
                if (!DateTime.TryParse(defautvalue, out result))
                {
                    return min;
                }
            }
            else
            {
                if (!DateTime.TryParse(value, out result))  //不能转换或者默认值无效时返回min
                {
                    if (!DateTime.TryParse(defautvalue, out result))
                    {
                        return min;
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///  安全转换为可空Int32
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static int? SafeInt32Null(string value, string defautvalue = "")
        {
            int result;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!int.TryParse(defautvalue, out result))
                {
                    return null;
                }
            }
            else
            {
                if (!int.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!int.TryParse(defautvalue, out result))
                    {
                        return null;
                    }
                }
            }
            return result;
        }
        /// <summary>
        ///  安全转换为可空Int32
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static int SafeInt32(string value, string defautvalue = "")
        {
            int result = 0;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!int.TryParse(defautvalue, out result))
                {
                    return 0;
                }
            }
            else
            {
                if (!int.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!int.TryParse(defautvalue, out result))
                    {
                        return 0;
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///  安全转换为可空sbyte
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static sbyte? SafeSByteNull(string value, string defautvalue = "")
        {
            sbyte result;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!sbyte.TryParse(defautvalue, out result))
                {
                    return null;
                }
            }
            else
            {
                if (!sbyte.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!sbyte.TryParse(defautvalue, out result))
                    {
                        return null;
                    }
                }
            }
            return result;
        }
        /// <summary>
        ///  安全转换为sbyte
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static sbyte SafeSByte(string value, string defautvalue = "")
        {
            sbyte result = 0;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!sbyte.TryParse(defautvalue, out result))
                {
                    return 0;
                }
            }
            else
            {
                if (!sbyte.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!sbyte.TryParse(defautvalue, out result))
                    {
                        return 0;
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///  安全转换为可空float
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static float? SafeFloatNull(string value, string defautvalue = "")
        {
            float result;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!float.TryParse(defautvalue, out result))
                {
                    return null;
                }
            }
            else
            {
                if (!float.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!float.TryParse(defautvalue, out result))
                    {
                        return null;
                    }
                }
            }
            return result;
        }
        /// <summary>
        ///  安全转换为float
        /// </summary>
        /// <param name="value">字符日期</param>
        /// <param name="defautvalue">为空时默认日期</param>
        /// <returns></returns>
        public static float SafeFloat(string value, string defautvalue = "")
        {
            float result = 0;
            if (string.IsNullOrEmpty(value))    //为空或者默认值无效时烦返回null
            {
                if (!float.TryParse(defautvalue, out result))
                {
                    return 0;
                }
            }
            else
            {
                if (!float.TryParse(value, out result))  //不能转换或者默认值无效时返回null
                {
                    if (!float.TryParse(defautvalue, out result))
                    {
                        return 0;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取出生日期
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public static DateTime? GetBirthday(string idCardNo) {
            if (!string.IsNullOrEmpty(idCardNo))
            {
                if (idCardNo.Length == 18) return Convert.ToDateTime(idCardNo.Substring(6, 4) + "-" + idCardNo.Substring(10, 2) + "-" + idCardNo.Substring(12, 2));
                if (idCardNo.Length == 15) return Convert.ToDateTime("19" + idCardNo.Substring(6, 2) + "-" + idCardNo.Substring(8, 2) + "-" + idCardNo.Substring(10, 2));
            }
            return null;
        }

        /// <summary>
        /// 获取年龄
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public static int? GetAge(string idCardNo)
        {
            var time = GetBirthday(idCardNo);
            var timenew = DateTime.Now;
            if (time.HasValue)
            {
                var age = timenew.Date.Year - time.Value.Date.Year;
                if (time.Value.Date >= timenew.Date) age++;
                return age;
            }
            return null;
        }
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public static int GetSex(string idCardNo)
        {
            var sex = 9;
            if (!string.IsNullOrEmpty(idCardNo))
            {
                var num = -1;
                if (idCardNo.Length == 18) num = Convert.ToInt32(idCardNo.Substring(14, 3));
                if (idCardNo.Length == 15) num = Convert.ToInt32(idCardNo.Substring(12, 3));
                if (num >= 0) if (num % 2 == 0) sex = 2; else sex = 1;
            }
            return sex;
        }
    }
}
