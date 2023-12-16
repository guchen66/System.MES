using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.MES.Core.Services.LoginSign;
using System.MES.Extensions;
using System.MES.ViewModels.Dialogs;
using System.MES.Views.Dialogs;
using System.MES.Wpf.IServices;
using System.MES.Wpf.Services;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Services
{
    public class PrismComponent : IServiceComponent
    {
        public void Load(IServiceCollection services, ComponentContext componentContext)
        {
            services.AddSingleton<ILoginService, LoginService>();
            services.AddTransient<IDialogService, DialogService>(); // 注册 IDialogService
            services.AddTransient<IDialogWindow, DialogWindow>();
            services.AddTransient<IPopupService, PopupService>();
            
            //  services.AddTransient<IEventAggregator, EventAggregator>();
            // services.AddSingleton<IRegionManager, RegionManager>();
            // services.AddSingleton<IRegion, Region>();
            // services.AddTransient<IRegionNavigationJournal, RegionNavigationJournal>();
            //  var s1= services.AddNavicateDialog<AddDialog, AddDialogViewModel>();
            //  Debug.WriteLine(s1 + DateTime.Now.ToString());
            services.AddTransient<IContainerExtension, PrismContainerExtension>(); // 注册 IDialogService

            Dictionary<string,object> keyValues= componentContext.GetProperties();

        }

      /*  public void Load(IContainerExtension containerRegistry, ComponentContext componentContext)
        {
            containerRegistry.RegisterDialog<AddDialog, AddDialogViewModel>();
        }*/
    }

    public class PrismContainerExtension : IContainerExtension
    {

        public IServiceProvider Services { get; set; }

        public IScopedProvider CurrentScope { get;set;}  

        public IScopedProvider CreateScope()
        {
            return CurrentScope;
        }

        public void FinalizeExtension()
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type, string name)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterInstance(Type type, object instance)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterInstance(Type type, object instance, string name)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterMany(Type type, params Type[] serviceTypes)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterManySingleton(Type type, params Type[] serviceTypes)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type from, Type to)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            return App.GetService(type);
        }

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
        {
            return App.GetService(type);
        }

        public object Resolve(Type type, string name)
        {

          return  App.GetService(type);
           
        }

        public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
