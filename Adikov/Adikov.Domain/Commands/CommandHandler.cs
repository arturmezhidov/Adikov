using Adikov.Domain.Data;
using Adikov.Infrastructura.Security;

namespace Adikov.Domain.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected ApplicationDbContext DataContext { get; }

        protected UserContext UserContext { get; }

        protected CommandHandler()
        {
            DataContext = ApplicationDbContext.Create();
            UserContext = new UserContext();
        }

        public void Handle(TCommand command)
        {
            OnHandling(command);

            DataContext.SaveChanges();
        }

        protected abstract void OnHandling(TCommand command);
    }
}