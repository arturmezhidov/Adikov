using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Faq
{
    public class DeclineFaqRequestCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeclineFaqRequestCommandHandler : CommandHandler<DeclineFaqRequestCommand>
    {
        protected override void OnHandling(DeclineFaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = DataContext.FaqRequests.Find(command.Id);

            if (request != null)
            {
                request.Status = FaqRequestStatus.Declined;
                DataContext.Entry(request).State = EntityState.Modified;
            }
        }
    }
}