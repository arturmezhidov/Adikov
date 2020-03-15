using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.Contacts
{
    public class GetQuestionQueryResult
    {
        public ContactsQuestion Question { get; set; }
    }

    public class GetQuestionQuery : BaseSettingsQuery<EmptyCriterion, GetQuestionQueryResult>
    {
        protected override GetQuestionQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetQuestionQueryResult result = new GetQuestionQueryResult
            {
                Question = GetSettings<ContactsQuestion>()
            };

            return result;
        }
    }
}