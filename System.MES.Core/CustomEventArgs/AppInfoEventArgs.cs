using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Core.Const;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.CustomEventArgs
{
    public class AppInfoEventArgs:EventArgs
    {
        public AppInfoOptions AppInfoOptions { get; set; }
        public AppInfoEventArgs(AppInfoOptions appInfoOptions) 
        {
            AppInfoOptions = appInfoOptions;
        }
    }
}
