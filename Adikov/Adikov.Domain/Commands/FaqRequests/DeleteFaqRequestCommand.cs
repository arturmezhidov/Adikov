using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqRequests
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
                request.IsDeleted = true;
                DataContext.Entry(request).State = EntityState.Modified;
            }
        }
    }
}