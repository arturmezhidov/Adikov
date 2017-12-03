namespace Adikov.Infrastructura.Commands
{
    public interface ICommandHandler<in TCommand, out TResult> 
        where TCommand : ICommand
        where TResult : ICommandResult
    {
        TResult Handle(TCommand command);
    }
}