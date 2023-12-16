using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Core.Threads.Enums;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Shared.Handlers
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class ThreadExceptionHandler
    {
        public  void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            throw Oops.Oh($"Task线程出错", typeof(InvalidOperationException),e.Exception);
           
        }

        public  void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw Oops.Oh($"非UI线程出错", typeof(InvalidOperationException));
        }

        public  void Current_DispatcherUnhandledException(object sender, Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            
            throw Oops.Oh(ThreadErrorCodes.SERVER_ERROR);
        }
    }
}
