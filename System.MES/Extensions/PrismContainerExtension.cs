using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Services;
using System.MES.Shared.Mvvm;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Extensions
{
    public static class PrismContainerExtension
    {
        public static void AddRegisterDialog<TView, TViewModel>(this IServiceCollection containerRegistry, string name = null) where TViewModel : IDialogAware
        {
            containerRegistry.RegisterForNavigation<TView, TViewModel>(name);
        }
       /* public static IContainerRegistry RegisterSingletonOnce<TFrom, TTo>(this IServiceCollection containerRegistry)
            where TTo : TFrom
        {
            if (!containerRegistry.IsReadOnly.IsRegistered<TFrom>())
            {
                containerRegistry.RegisterSingleton<TFrom, TTo>();
            }

            return containerRegistry;
        }

        public static IContainerRegistry RegisterManySingletonOnce<TImpl>(this IServiceCollection containerRegistry, params Type[] services)
        {
            if (!containerRegistry.IsRegistered<TImpl>() && !services.Any(s => containerRegistry.IsRegistered(s)))
            {
                containerRegistry.RegisterManySingleton<TImpl>(services);
            }

            return containerRegistry;
        }*/
    }

    public static class NavigationExtensions
    {
        public static IServiceCollection AddNavicateDialog<TView, TViewModel>(this IServiceCollection services,Type type,string name) where TViewModel : IDialogAware
        {
            // 进行相关的导航注册操作

          //  RegisterForNavigation(services, type, name);
            return services;
        }
        public static void RegisterForNavigation<TView, TViewModel>(this IServiceCollection services, string name = null)
        {
         
            services.RegisterForNavigationWithViewModel<TViewModel>(typeof(TView), name);
        }

        private static void RegisterForNavigationWithViewModel<TViewModel>(this IServiceCollection services, Type viewType, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = viewType.Name;

            ViewModelLocationProvider.Register(viewType.ToString(), typeof(TViewModel));
           // RegisterForNavigation(viewType, name);
        }

        public static void RegisterForNavigation(IPrismCollection services, Type type, string name)
        {
            services.Register(typeof(object), type, name);
        }

        public static void AddRegisterDialog<TViewModel>(this IServiceCollection containerRegistry, string name = null) where TViewModel : IDialogAware
        {
          //  containerRegistry.RegisterForNavigation<TViewModel>(name);
        }
    }

   
}
