using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.Contacts
{
    public class GetContactsMapQueryResult
    {
        public ContactsMap Map { get; set; }
    }

    public class GetContactsMapQuery : BaseSettingsQuery<EmptyCriterion, GetContactsMapQueryResult>
    {
        protected override GetContactsMapQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetContactsMapQueryResult result = new GetContactsMapQueryResult
            {
                Map = GetSettings<ContactsMap>()
            };

            return result;
        }
    }
}