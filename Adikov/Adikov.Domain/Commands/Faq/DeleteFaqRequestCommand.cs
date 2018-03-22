using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Faq
{
    public class DeleteFaqRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteFaqRequestCommandHandler : CommandHandler<DeleteFaqRequestCommand>
    {
        protected override void OnHandling(DeleteFaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                DataContext.FaqRequests.Remove(request);
            }
        }
    }
}