using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Adikov.Domain.Queries;

namespace Adikov.App_Start
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Type searchingInterface = typeof(IQuery<,>);

            var queries = Classes.FromAssembly(searchingInterface.Assembly)
                .BasedOn(searchingInterface)
                .WithService.FirstInterface()
                .LifestyleTransient();

            container.Register(queries);
        }
    }
}