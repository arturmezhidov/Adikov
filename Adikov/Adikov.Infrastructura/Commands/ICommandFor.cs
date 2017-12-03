namespace Adikov.Infrastructura.Commands
{
    public interface ICommandFor<out TResult> where TResult : ICommandResult
    {
        TResult Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}