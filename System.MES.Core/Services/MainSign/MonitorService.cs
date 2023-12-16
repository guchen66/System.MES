using Masuit.Tools.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.MainSign
{
    public class MonitorService: IMonitorService
    {
        public static void CheckOut()
        {
            var version = Environment.OSVersion;
            Console.WriteLine(version);                        //获取操作系统版本

            float load = SystemInfo.CpuLoad;                   // 获取CPU占用率
            Console.WriteLine(load);


          //  var startTime = GetBootTime();
         //   Console.WriteLine(startTime);      //开机时间是2023/11/6 21:02:40
            long physicalMemory = SystemInfo.PhysicalMemory;     // 获取物理内存总数
            long memoryAvailable = SystemInfo.MemoryAvailable;   // 获取物理内存可用率
            double freePhysicalMemory = SystemInfo.GetFreePhysicalMemory();// 获取可用物理内存

            /*Dictionary<string, string> diskFree = SystemInfo.DiskFree();// 获取磁盘每个分区可用空间
            Dictionary<string, string> diskTotalSpace = SystemInfo.DiskTotalSpace();// 获取磁盘每个分区总大小
            Dictionary<string, double> diskUsage = SystemInfo.DiskUsage();// 获取磁盘每个分区使用率
            double temperature = SystemInfo.GetCPUTemperature();// 获取CPU温度
            int cpuCount = SystemInfo.GetCpuCount();// 获取CPU核心数
            IList<string> ipAddress = SystemInfo.GetIPAddress();// 获取本机所有IP地址
            var localUsedIp = SystemInfo.GetLocalUsedIP();// 获取本机当前正在使用的IP地址
            IList<string> macAddress = SystemInfo.GetMacAddress();// 获取本机所有网卡mac地址
            var osVersion = GetOsVersion();// 获取操作系统版本
            RamInfo ramInfo = SystemInfo.GetRamInfo();// 获取内存信息*/
        }

        public Task<bool> GetCPU()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetGPU()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UnicastIPAddressInformation>> GetLocalIps()
        {
            List<UnicastIPAddressInformation> ipAddress = SystemInfo.GetLocalIPs();           // 获取本机所有IP地址

            return ipAddress;
        }

        public Task<bool> GetNetStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetOsVersion()
        {
            var version = Environment.OSVersion;
            return version.ToString();
        }

        public Task RunStatus()
        {
            throw new NotImplementedException();
        }
    }
}
