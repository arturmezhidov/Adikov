using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqRequests
{
    public class OpenFaqRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class OpenFaqRequestCommandHandler : CommandHandler<OpenFaqRequestCommand>
    {
        protected override void OnHandling(OpenFaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                request.Status = FaqRequestStatus.Open;
                DataContext.Entry(request).State = EntityState.Modified;
            }
        }
    }
}