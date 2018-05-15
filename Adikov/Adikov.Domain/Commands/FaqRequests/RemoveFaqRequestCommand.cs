using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqRequests
{
    public class RemoveFaqRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class RemoveFaqRequestCommandHandler : CommandHandler<RemoveFaqRequestCommand>
    {
        protected override void OnHandling(RemoveFaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                DataContext.FaqRequests.Remove(request);
            }
        }
    }
}