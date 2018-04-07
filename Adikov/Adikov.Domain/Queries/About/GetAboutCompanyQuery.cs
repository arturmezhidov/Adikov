using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutCompanyQueryResult
    {
        public AboutCompany AboutCompany { get; set; }
    }

    public class GetAboutCompanyQuery : BaseSettingsQuery<EmptyCriterion, GetAboutCompanyQueryResult>
    {
        protected override GetAboutCompanyQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetAboutCompanyQueryResult result = new GetAboutCompanyQueryResult
            {
                AboutCompany = GetSettings<AboutCompany>()
            };

            return result;
        }
    }
}