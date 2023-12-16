using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Core.Services.LoginSign.Dtos;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.LoginSign
{
    public interface ILoginService
    {
        bool SavePassWord(LoginAccountDto loginAccounts);
    }
}
