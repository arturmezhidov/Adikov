using System;
using Adikov.Domain.Commands;
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
            // Query

            Type queryInterface = typeof(IQuery<,>);

            var queries = Classes.FromAssembly(queryInterface.Assembly)
                .BasedOn(queryInterface)
                .WithService.FirstInterface()
                .LifestyleTransient();

            container.Register(queries);

            // Command

            Type commandInterface = typeof(ICommandHandler<>);

            var commands = Classes.FromAssembly(commandInterface.Assembly)
                .BasedOn(commandInterface)
                .WithService.FirstInterface()
                .LifestyleTransient();

            container.Register(commands);
        }
    }
}