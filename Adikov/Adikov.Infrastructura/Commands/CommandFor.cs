using System;
using System.Web.Mvc;

namespace Adikov.Infrastructura.Commands
{
    public class CommandFor<TResult> : ICommandFor<TResult> where TResult : ICommandResult
    {
        private readonly IDependencyResolver dependencyResolver;

        public CommandFor(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public TResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand, TResult> handler = null;

            try
            {
                handler = dependencyResolver.GetService<ICommandHandler<TCommand, TResult>>();
            }
            finally
            {
                if (handler == null)
                {
                    throw new NotImplementedException($"Interface ICommandHandler<{typeof(TCommand).Name}, {typeof(TResult).Name}> does not implement.");
                }
            }

            return handler.Handle(command);
        }
    }
}