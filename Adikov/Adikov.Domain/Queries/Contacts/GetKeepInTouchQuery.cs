using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.Contacts
{
    public class GetKeepInTouchQueryResult
    {
        public ContactsKeepInTouch KeepInTouch { get; set; }
    }

    public class GetKeepInTouchQuery : BaseSettingsQuery<EmptyCriterion, GetKeepInTouchQueryResult>
    {
        protected override GetKeepInTouchQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetKeepInTouchQueryResult result = new GetKeepInTouchQueryResult
            {
                KeepInTouch = GetSettings<ContactsKeepInTouch>()
            };

            return result;
        }

        public static ContactsKeepInTouch Execute()
        {
            return new GetKeepInTouchQuery().Execute(new EmptyCriterion()).KeepInTouch;
        }
    }
}