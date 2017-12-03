using Adikov.Domain.Data;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands
{
    public abstract class CommandHandler<TCommand> : CommandHandler<TCommand, CommandResult> 
        where TCommand : ICommand
    {
    }

    public abstract class CommandHandler<TCommand, TResult> : CommandHandlerBase<TCommand, TResult>
        where TCommand : ICommand
        where TResult : ICommandResult, new()
    {
        protected ApplicationDbContext DataContext { get; }

        protected CommandHandler()
        {
            DataContext = ApplicationDbContext.Create();
        }

        protected override  void OnHandled(TCommand command, TResult result)
        {
            if (result.ResultCode == CommandResultCode.Success)
            {
                DataContext.SaveChanges();
            }
        }
    }
}