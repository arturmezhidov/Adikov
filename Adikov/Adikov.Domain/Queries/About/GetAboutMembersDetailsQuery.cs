using System;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class GetAboutMembersDetailsQueryResult
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string MemberAvatarUrl1 { get; set; }

        public string MemberFullName1 { get; set; }

        public string MemberAbout1 { get; set; }

        public string MemberAvatarUrl2 { get; set; }

        public string MemberFullName2 { get; set; }

        public string MemberAbout2 { get; set; }

        public string MemberAvatarUrl3 { get; set; }

        public string MemberFullName3 { get; set; }

        public string MemberAbout3 { get; set; }

        public string MemberAvatarUrl4 { get; set; }

        public string MemberFullName4 { get; set; }

        public string MemberAbout4 { get; set; }
    }

    public class GetAboutMembersDetailsQuery : BaseSettingsQuery<EmptyCriterion, GetAboutMembersDetailsQueryResult>
    {
        protected override GetAboutMembersDetailsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            AboutMembers members = GetSettings<AboutMembers>();

            GetAboutMembersDetailsQueryResult result = new GetAboutMembersDetailsQueryResult
            {
                Title = members.Title,
                SubTitle = members.SubTitle
            };

            ApplicationUser user1 = GetUser(members.Member1Id);
            result.MemberAbout1 = GetUserAbout(user1);
            result.MemberFullName1 = GetUsername(user1);
            result.MemberAvatarUrl1 = GetUserAvatar(user1);

            ApplicationUser user2 = GetUser(members.Member2Id);
            result.MemberAbout2 = GetUserAbout(user2);
            result.MemberFullName2 = GetUsername(user2);
            result.MemberAvatarUrl2 = GetUserAvatar(user2);

            ApplicationUser user3 = GetUser(members.Member3Id);
            result.MemberAbout3 = GetUserAbout(user3);
            result.MemberFullName3 = GetUsername(user3);
            result.MemberAvatarUrl3 = GetUserAvatar(user3);

            ApplicationUser user4 = GetUser(members.Member4Id);
            result.MemberAbout4 = GetUserAbout(user4);
            result.MemberFullName4 = GetUsername(user4);
            result.MemberAvatarUrl4 = GetUserAvatar(user4);

            return result;
        }

        protected ApplicationUser GetUser(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return null;
            }

            return DataContext.Users.Find(id);
        }

        protected string GetUserAbout(ApplicationUser user)
        {
            if (user == null)
            {
                return String.Empty;
            }

            return user.About;
        }

        protected string GetUsername(ApplicationUser user)
        {
            if (user == null)
            {
                return String.Empty;
            }

            string username = $"{user.FirstName} {user.LastName}";

            if (String.IsNullOrWhiteSpace(username))
            {
                username = user.UserName;
            }

            return username;
        }

        protected string GetUserAvatar(ApplicationUser user)
        {
            if (user == null)
            {
                return String.Empty;
            }

            File file = user.Avatar ?? GetFile(user.AvatarId?.ToString());

            if (file == null)
            {
                return String.Empty;
            }

            return GetFileUrl(file, PlatformConfiguration.UploadedUserPathTemplate);
        }
    }
}