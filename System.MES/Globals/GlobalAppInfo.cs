using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Core.Const;
using System.MES.Core.CustomEventArgs;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Globals
{
    public class GlobalAppInfo
    {
        private readonly AppInfoOptions options1;
        private readonly AppInfoOptions options2;
        private readonly AppInfoOptions options3;

        public event EventHandler<AppInfoEventArgs> InfoCompleted;
        public GlobalAppInfo(
            IOptions<AppInfoOptions> options
            , IOptionsSnapshot<AppInfoOptions> optionsSnapshot
            , IOptionsMonitor<AppInfoOptions> optionsMonitor)
        {
            options1 = options.Value;
            options2 = optionsSnapshot.Value;
            options3 = optionsMonitor.CurrentValue;
        }


        public string GetAppInfo()
        {
            var info1 = $@"名称：{options1.Name}，
                      版本：{options1.Version}，
                      公司：{options1.Company}";

            var info2 = $@"名称：{options2.Name}，
                      版本：{options2.Version}，
                      公司：{options2.Company}";

            var info3 = $@"名称：{options3.Name}，
                      版本：{options3.Version}，
                      公司：{options3.Company}";

            OnInfoCompleted(new AppInfoOptions());

            return $"{info1}-{info2}-{info3}";
        }

        private void OnInfoCompleted(AppInfoOptions info)
        {
            InfoCompleted?.Invoke(this,new AppInfoEventArgs(info));
        }
    }
}
