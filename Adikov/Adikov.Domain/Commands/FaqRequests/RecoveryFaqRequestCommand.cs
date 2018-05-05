using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqRequests
{
    public class RecoveryFaqRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class RecoveryFaqRequestCommandHandler : CommandHandler<RecoveryFaqRequestCommand>
    {
        protected override void OnHandling(RecoveryFaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                request.IsDeleted = false;
                DataContext.Entry(request).State = EntityState.Modified;
            }
        }
    }
}