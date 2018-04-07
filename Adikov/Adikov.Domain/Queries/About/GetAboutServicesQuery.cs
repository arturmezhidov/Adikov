using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutServicesQueryResult
    {
        public AboutServices Services { get; set; }
    }

    public class GetAboutServicesQuery : BaseSettingsQuery<EmptyCriterion, GetAboutServicesQueryResult>
    {
        protected override GetAboutServicesQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetAboutServicesQueryResult result = new GetAboutServicesQueryResult
            {
                Services = GetSettings<AboutServices>()
            };

            return result;
        }
    }
}