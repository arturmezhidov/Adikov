using System;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Faq
{
    public class FaqRequestCommand : CommandBase
    {
        public string Question { get; set; }
    }

    public class FaqRequestCommandHandler : CommandHandler<FaqRequestCommand>
    {
        protected override void OnHandling(FaqRequestCommand command, CommandResult result)
        {
            FaqRequest request = new FaqRequest
            {
                Question = command.Question,
                UserId = UserContext.UserId,
                Status = FaqRequestStatus.Open,
                CreatedAt = DateTime.Now
            };

            DataContext.FaqRequests.Add(request);
        }
    }
}