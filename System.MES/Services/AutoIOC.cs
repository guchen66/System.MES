using Autofac;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Services
{
    public class AutoIOC
    {
        public ContainerBuilder servers {  get; set; }
        public IContainer container { get; set; }

        public AutoIOC()
        {
            servers = new ContainerBuilder();
        }

        public virtual void InitServersAction(Action action)
        {
            if (servers == null) servers=new ContainerBuilder();
            {
                action();
            }
            container=servers.Build();
        }

        public IServer GetServer<IServer>()
        {
            return container.Resolve<IServer>();
        }
    }
}
