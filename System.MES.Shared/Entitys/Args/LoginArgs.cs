using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Shared.Entitys.Args
{
    public class LoginArgs
    {
        public static readonly LoginArgs Instance = new Lazy<LoginArgs>(() => new LoginArgs()).Value;
        public static bool IsSelected { get; set; }
    }
}
