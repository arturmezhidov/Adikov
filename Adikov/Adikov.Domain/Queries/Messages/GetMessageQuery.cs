using Adikov.Domain.Commands.Messages;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Messages
{
    public class GetMessageQueryResult
    {
        public Message Message { get; set; }

        public bool IsFound { get; set; }
    }

    public class GetMessageQuery : BaseSettingsQuery<IdCriterion, GetMessageQueryResult>
    {
        protected override GetMessageQueryResult OnExecuting(IdCriterion criterion)
        {
            var message = DataContext.Messages.Find(criterion.Id);

            GetMessageQueryResult result = new GetMessageQueryResult
            {
                Message = message,
                IsFound = message != null
            };

            if (result.IsFound)
            {
                ReadMessageCommand.Execute(message.Id);
            }

            return result;
        }
    }
}