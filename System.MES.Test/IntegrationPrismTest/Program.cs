
using IntegrationPrismTest.StaticClass;
using IntegrationPrismTest.Views;
using System.Net.Mail;
using System.Windows;
using System.Xaml;

namespace System.MES.Test
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Serve.RunNative();
            var app = new Application();
            
            app.Startup += (sender, e) =>
            {

                StaticApp.Get();

            };          
            app.Run(Native.CreateInstance<MainView>());
        }

       

        private static void App_Exit(object sender, ExitEventArgs e)
        {
            
        }



        /// <summary>
        /// 注册组件
        /// </summary>
        /// <returns></returns>
       /* public static IRunOptions GetComponent()
        {
            return RunOptions.Default.AddComponent<PrismComponent>()
                                     .ConfigureConfiguration((env, configuration) =>
                                     { configuration.AddJsonFile("appsettings.json", true, true); });
        }
      */

    }

    public class UnitTest
    {
       
      
    }
}
