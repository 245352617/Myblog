using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Common.Extension
{
    public static class JsonExt
    {
        /// <summary>
        /// Json转string
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ToJsonStr(this object target)
        {
            if (target == null) return "";
            return JsonConvert.SerializeObject(target);
        }
        /// <summary>
        /// json转T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T ToObj<T>(this string target)
        {
            if (string.IsNullOrEmpty(target)) return default(T);
            return JsonConvert.DeserializeObject<T>(target);
        }
        /// <summary>
        /// 实体转换
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="souce"></param>
        /// <returns></returns>
        public static T2 ConverToMode<T1,T2>(T1 source)
        {
            T2 model = default(T2);
            PropertyInfo[] pi = typeof(T2).GetProperties();
            PropertyInfo[] pi1 = typeof(T1).GetProperties();
            model = Activator.CreateInstance<T2>();
            foreach (var p in pi)
            {
                foreach (var p1 in pi1)
                {
                    if (p.Name == p1.Name)
                    {
                        p.SetValue(model, p1.GetValue(source, null), null);
                        break;
                    }
                }
            }
            return model;
        }
    }
}
