using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.MainSign
{
    public interface IMonitorService
    {
        Task<string> GetOsVersion();
        Task RunStatus();
        //Task<bool> IsRunning();

        //Task Stop();

     //   Task<bool> IsPaused();

     //   Task<bool> IsStopped();

        Task<bool> GetCPU();

        Task<bool> GetGPU();

        Task<bool> GetNetStatus();

        Task<List<UnicastIPAddressInformation>> GetLocalIps();
    }
}
