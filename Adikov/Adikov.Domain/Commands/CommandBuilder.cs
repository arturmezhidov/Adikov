using System;
using System.Web.Mvc;

namespace Adikov.Domain.Commands
{
    public class CommandBuilder : ICommandBuilder
    {
        private readonly IDependencyResolver dependencyResolver;

        public CommandBuilder(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = null;

            try
            {
                handler = dependencyResolver.GetService<ICommandHandler<TCommand>>();
            }
            finally
            {
                if (command == null)
                {
                    throw new NotImplementedException($"Interface ICommandHandler<{typeof(TCommand).Name}> does not implement.");
                }
            }

            handler.Handle(command);
        }
    }
}