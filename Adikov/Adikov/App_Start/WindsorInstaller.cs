using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Adikov.Infrastructura.Commands;
using Adikov.Infrastructura.Queries;

namespace Adikov.App_Start
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Query

            var queries = Classes.FromAssemblyInThisApplication()
                .BasedOn(typeof(IQuery<,>))
                .WithService.FirstInterface()
                .LifestyleTransient();

            container.Register(queries);
 

            // Command

            var commands = Classes.FromAssemblyInThisApplication()
                .BasedOn(typeof(ICommandHandler<,>))
                .WithService.FirstInterface()
                .LifestyleTransient();

            container.Register(commands);
        }
    }
}