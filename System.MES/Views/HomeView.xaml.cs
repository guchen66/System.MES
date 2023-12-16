using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace System.MES.Views
{
    /// <summary>
    /// HomeView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeView : UserControl
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private PerformanceCounter networkCounter;

        public HomeView()
        {
            InitializeComponent();

            // 创建性能计数器实例
         /*   cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            networkCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec");

            // 定时更新数据
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();*/
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 获取电脑运行状态数据
            float cpuUsage = cpuCounter.NextValue();
            float availableRAM = ramCounter.NextValue();
            float networkUsage = networkCounter.NextValue();

            // 更新UI展示
           /* cpuUsageLabel.Content = $"CPU使用率: {cpuUsage}%";
            ramUsageLabel.Content = $"可用内存: {availableRAM} MB";
            networkUsageLabel.Content = $"网络使用率: {networkUsage} bytes/sec";*/
        }
    }
}
