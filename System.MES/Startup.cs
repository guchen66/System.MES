using Autofac;
namespace System.MES;
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {     
        services.AddScoped<AddDialogViewModel>();
        services.AddScoped<LoginViewModel>();
        services.AddScoped<MainViewModel>();
        services.AddScoped<TestView>();
        services.AddScoped<MainView>();
        services.AddSqlsugarSetup(App.Configuration);
        services.AddSingleton<ISnackbarMessageQueue, SnackbarMessageQueue>();    
        services.AddComponent<PrismComponent>(new PrismOptions { });
        services.AddControllers().AddFriendlyException();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ApplySavedState();
    }
    public static void ApplySavedState()
    {
        if (File.Exists("rememberPwd.json"))
        {
            string serializedSettings = File.ReadAllText("rememberPwd.json");
            var dataList = JsonConvert.DeserializeObject<LoginAccountDto>(serializedSettings);

            if (dataList != null)
            {
                LoginArgs.IsSelected = dataList.IsSelected;
            }
        }
    }
    /*  public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ContainerBuilder container)
      {
          var builder = new ContainerBuilder();  //创建注册器
          builder.RegisterType<IDialogService>().As<DialogService>();         //注册组件
          var container = builder.Build();                                      //构建容器
          var myService = container.Resolve<IDialogService>();                  //从容器中解析组件
      }*/
}
