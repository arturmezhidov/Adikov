using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutLinksQueryResult
    {
        public AboutLinks Links { get; set; }

        public string ImageUrl { get; set; }
    }

    public class GetAboutLinksQuery : BaseSettingsQuery<EmptyCriterion, GetAboutLinksQueryResult>
    {
        protected override GetAboutLinksQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetAboutLinksQueryResult result = new GetAboutLinksQueryResult
            {
                Links = GetSettings<AboutLinks>()
            };

            result.ImageUrl = GetFileUrl(GetFile(result.Links.ImageId));

            return result;
        }
    }
}