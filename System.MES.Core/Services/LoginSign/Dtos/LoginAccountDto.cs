using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.LoginSign.Dtos
{
    public class LoginAccountDto: IConfigurableOptions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        public string UserName { get; set; }

        [Required,MaxLength(20)]
        public string Password { get; set; }

        public bool IsSelected { get; set; }
    }
}
