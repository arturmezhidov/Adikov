namespace Adikov.Infrastructura.Commands
{
    public interface ICommandBuilder
    {
        ICommandFor<TResult> For<TResult>() where TResult : ICommandResult;

        CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}