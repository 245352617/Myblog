using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Common.Application
{
    public enum ResultCode
    {
        /// <summary>
        /// 操作成功
        ///</summary>
        [Display(Name = "操作成功", GroupName = Result.SuccessCode)]
        Ok = 1,

        /// <summary>
        /// 操作失败
        ///</summary>
        [Display(Name = "操作失败")]
        Fail = 10,

        /// <summary>
        /// 登陆失败
        ///</summary>
        [Display(Name = "登陆失败")]
        LoginFail = 11,

        /// <summary>
        /// 没有该数据
        ///</summary>
        [Display(Name = "没有数据")]
        NoRecord = 12,

        /// <summary>
        /// 参数不正确
        ///</summary>
        [Display(Name = "参数不正确")]
        InvalidParams = 13,

        /// <summary>
        /// 用户不存在
        ///</summary>
        [Display(Name = "用户不存在")]
        NoSuchUser = 20,

        /// <summary>
        /// 文档不存在
        ///</summary>
        [Display(Name = "数据库文档不存在")]
        NoSuchCollection = 30,


        /// <summary>
        /// 没有操作权限
        ///</summary>
        [Display(Name = "没有操作权限")]
        HasNoPermission = 400

    }
}
