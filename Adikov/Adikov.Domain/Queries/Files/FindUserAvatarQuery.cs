using System;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.Files
{
    public class FindUserAvatarQueryResult
    {
        public File Avatar { get; set; }

        public string ImageUrl { get; set; }
    }

    public class FindUserAvatarQuery : Query<IdCriterion, FindUserAvatarQueryResult>
    {
        protected override FindUserAvatarQueryResult OnExecuting(IdCriterion criterion)
        {
            ApplicationUser user = DataContext.Users.Find(criterion.Id);

            if (user?.AvatarId == null)
            {
                return null;
            }

            File file = DataContext.Files.Find(user.AvatarId);

            if (file == null)
            {
                return null;
            }

            FindUserAvatarQueryResult result = new FindUserAvatarQueryResult
            {
                Avatar = file,
                ImageUrl = String.Format(PlatformConfiguration.UploadedUserFilePathTemplate, criterion.Id, file.PhysicalName)
            };

            return result;
        }
    }
}