using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;
using System;

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

        protected override string GetFileUrl(File file, string template = null)
        {
            if (file == null)
            {
                return String.Empty;
            }

            return String.Format(PlatformConfiguration.UploadedSettingsPathTemplate, file.PhysicalName);
        }
    }
}