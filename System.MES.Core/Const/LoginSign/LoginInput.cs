using Furion.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.MES.Core.Const.LoginSign
{
    [ValidationType]
    public enum MyValidationTypes
    {
        /// <summary>
        /// 强密码类型
        /// </summary>
        [ValidationItemMetadata(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$", "必须须包含大小写字母和数字的组合，不能使用特殊字符，长度在8-10之间")]
        StrongPassword,

        /// <summary>
        /// 以 Furion 字符串开头，忽略大小写
        /// </summary>
        [ValidationItemMetadata(@"^(furion).*", "默认提示：必须以Fur字符串开头，忽略大小写", RegexOptions.IgnoreCase)]
        StartWithFurString
    }
}
