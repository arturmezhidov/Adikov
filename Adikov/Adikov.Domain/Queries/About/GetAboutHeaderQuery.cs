using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutHeaderQueryResult
    {
        public AboutHeader Header { get; set; }

        public string BackgroundImageUrl { get; set; }
    }

    public class GetAboutHeaderQuery : BaseSettingsQuery<EmptyCriterion, GetAboutHeaderQueryResult>
    {
        protected override GetAboutHeaderQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetAboutHeaderQueryResult result = new GetAboutHeaderQueryResult
            {
                Header = GetSettings<AboutHeader>()
            };

            result.BackgroundImageUrl = GetFileUrl(GetFile(result.Header.BackgroundImageId));

            return result;
        }
    }
}