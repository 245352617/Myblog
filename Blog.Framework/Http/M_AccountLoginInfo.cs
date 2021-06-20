using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Http
{
    /// <summary>
    /// 登录后的基本信息
    /// </summary>
    public class M_AccountLoginInfo
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色ID，以,分割
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 所属组织根节点ID
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// 所属组织ID
        /// </summary>
        public int SubOrganizationId { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>
        public string HospitalCode { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 分配的GUID
        /// </summary>
        public string LGuid { get; set; }
    }
}
