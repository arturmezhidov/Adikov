using System.Web.Mvc;

namespace Adikov.Infrastructura.Commands
{
    public class CommandBuilder : ICommandBuilder
    {
        private readonly IDependencyResolver dependencyResolver;

        public CommandBuilder(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public ICommandFor<TResult> For<TResult>() where TResult : ICommandResult
        {
            return new CommandFor<TResult>(dependencyResolver);
        }

        public CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            return new CommandFor<CommandResult>(dependencyResolver).Execute(command);
        }
    }
}