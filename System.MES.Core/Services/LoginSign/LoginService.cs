using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.MES.Core.Services.LoginSign.Dtos;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.LoginSign
{
    public class LoginService : ILoginService
    {
        public bool SavePassWord(LoginAccountDto loginAccounts)
        {
            //json数组必须是一个对象
           // var data = new { LoginAccountDto = loginAccounts };
            
            // 序列化保存
            string rememberPwd = JsonConvert.SerializeObject(loginAccounts);
            File.WriteAllText("rememberPwd.json", rememberPwd);
            return true;
        }

       
    }
}
