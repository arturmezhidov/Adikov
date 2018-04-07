using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutQueryResults
    {
        public GetAboutHeaderQueryResult HeaderResult { get; set; }

        public GetAboutServicesQueryResult ServicesResult { get; set; }

        public GetAboutCompanyQueryResult AboutResult { get; set; }

        public GetAboutMembersQueryResult MembersResult { get; set; }

        public GetAboutLinksQueryResult LinksResult { get; set; }
    }

    public class GetAboutQuery : BaseSettingsQuery<EmptyCriterion, GetAboutQueryResults>
    {
        protected override GetAboutQueryResults OnExecuting(EmptyCriterion criterion)
        {
            GetAboutQueryResults result = new GetAboutQueryResults
            {
                HeaderResult = new GetAboutHeaderQuery().Execute(new EmptyCriterion()),
                ServicesResult = new GetAboutServicesQuery().Execute(new EmptyCriterion()),
                AboutResult = new GetAboutCompanyQuery().Execute(new EmptyCriterion()),
                MembersResult = new GetAboutMembersQuery().Execute(new EmptyCriterion()),
                LinksResult = new GetAboutLinksQuery().Execute(new EmptyCriterion())
            };
            
            return result;
        }
    }
}