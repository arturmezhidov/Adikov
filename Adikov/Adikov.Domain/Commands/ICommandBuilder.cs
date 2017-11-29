namespace Adikov.Domain.Commands
{
    public interface ICommandBuilder
    {
        void Execute<TCommand>(TCommand command) where TCommand: ICommand;
    }
}