using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Services
{
    public interface IPrismCollection : IServiceCollection
    {
        IPrismCollection RegisterInstance(Type type, object instance);

        IPrismCollection RegisterInstance(Type type, object instance, string name);

        IPrismCollection RegisterSingleton(Type from, Type to);

        IPrismCollection RegisterSingleton(Type from, Type to, string name);

        IPrismCollection RegisterSingleton(Type type, Func<object> factoryMethod);

       // IPrismCollection RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod);

        IPrismCollection RegisterManySingleton(Type type, params Type[] serviceTypes);

        IPrismCollection Register(Type from, Type to);

        IPrismCollection Register(Type from, Type to, string name);

        IPrismCollection Register(Type type, Func<object> factoryMethod);

    //    IPrismCollection Register(Type type, Func<IContainerProvider, object> factoryMethod);

        IPrismCollection RegisterMany(Type type, params Type[] serviceTypes);

        IPrismCollection RegisterScoped(Type from, Type to);

        IPrismCollection RegisterScoped(Type type, Func<object> factoryMethod);

       // IPrismCollection RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod);

        bool IsRegistered(Type type);

        bool IsRegistered(Type type, string name);
    }

    public interface IProvider
    {
        object Resolve(Type type);

        object Resolve(Type type, params (Type Type, object Instance)[] parameters);

        object Resolve(Type type, string name);

        object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters);

    }
}
