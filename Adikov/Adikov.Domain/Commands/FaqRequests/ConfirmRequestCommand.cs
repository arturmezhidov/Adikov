using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqRequests
{
    public class ConfirmRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class ConfirmRequestCommandHandler : CommandHandler<ConfirmRequestCommand>
    {
        protected override void OnHandling(ConfirmRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                request.Status = FaqRequestStatus.Confirmed;
                DataContext.Entry(request).State = EntityState.Modified;
            }
        }
    }
}