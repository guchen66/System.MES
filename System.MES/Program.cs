namespace System.MES
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
          
            // Serve.RunGeneric();
            Serve.RunNative(GetComponent());
            var app = new Application();       
            app.Startup += (sender, e) =>
            {
                //程序启动加载上一次关闭时SetData的数据状态
             

                // 加载类库中的主题资源
                var themeResourceDictionary = ResourceExtension.LoadTheme();
                Application.Current.Resources.MergedDictionaries.Add(themeResourceDictionary);

                //WPF全局异常捕获
                ThreadExceptionHandler handler = new ThreadExceptionHandler();
                //UI线程抛出异常
                //  Application.Current.DispatcherUnhandledException += handler.Current_DispatcherUnhandledException;

                //非UI线程抛出异常
                //   AppDomain.CurrentDomain.UnhandledException += handler.CurrentDomain_UnhandledException;

                //Task线程抛出异常
                //   TaskScheduler.UnobservedTaskException += handler.TaskScheduler_UnobservedTaskException;

                //扫描全局的json文件
                //  JsonExtension.GetDefaultJsonLevel();

               
            };
            if (Native.CreateInstance<LoginView>().ShowDialog() == true)
            {
                //关闭登录窗体
                Native.CreateInstance<LoginView>().Close();
            }
        }

       

        private static void App_Exit(object sender, ExitEventArgs e)
        {
            
        }



        /// <summary>
        /// 注册组件
        /// </summary>
        /// <returns></returns>
        public static IRunOptions GetComponent()
        {
            return RunOptions.Default.AddComponent<PrismComponent>()
                                     .ConfigureConfiguration((env, configuration) =>
                                     { configuration.AddJsonFile("appsettings.json", true, true); });
        }

    }

    public class UnitTest
    {
        public static void Get()
        {
            //获取全局配置
            var settings = App.Settings;

            //获取配置对象
            var configuration = App.Configuration;
            var value = configuration["AppInfo:Name"];

            //获取环境对象
            var webHostEnvironment = App.HostEnvironment;

            var assemblies = App.Assemblies;

            var httpContext = App.HttpContext;

            var contextUser = App.User;

            // 获取系统架构
            var osArchitecture = RuntimeInformation.OSArchitecture; // => X64

            // 获取系统名称
            var osDescription = RuntimeInformation.OSDescription;   // => Windows 10 企业版

            // 获取进程架构
            var processArchitecture = RuntimeInformation.ProcessArchitecture;   // => X64

            // 是否是64位操作系统
            var is64BitOperatingSystem = Environment.Is64BitOperatingSystem;    // => True

            bool isSingleFileEnviroment = App.SingleFileEnvironment;

            var repository = Db.GetRepository();

            var expression = LinqExpression.Create<User>(u => u.Id == 1);
            var expression2 = LinqExpression.Create<User>((u, i) => u.Id == 1 && i > 0);

            var result = DataValidator.TryValidateObject(1);

          
        }
    }

}
