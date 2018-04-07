using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.About
{
    public class Member
    {
        public string Id { get; set; }

        public string FullName { get; set; }
    }

    public class GetAboutMembersQueryResult
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Member1Id { get; set; }

        public string Member2Id { get; set; }

        public string Member3Id { get; set; }

        public string Member4Id { get; set; }

        public List<Member> Members { get; set; }
    }

    public class GetAboutMembersQuery : BaseSettingsQuery<EmptyCriterion, GetAboutMembersQueryResult>
    {
        protected override GetAboutMembersQueryResult OnExecuting(EmptyCriterion criterion)
        {
            AboutMembers members = GetSettings<AboutMembers>();

            GetAboutMembersQueryResult result = new GetAboutMembersQueryResult
            {
                Title = members.Title,
                SubTitle = members.SubTitle,
                Member1Id = members.Member1Id,
                Member2Id = members.Member2Id,
                Member3Id = members.Member3Id,
                Member4Id = members.Member4Id,
                Members = DataContext.Users.Select(ToMember).ToList()
            };

            return result;
        }

        protected Member ToMember(ApplicationUser user)
        {
            Member member = new Member
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };

            if (String.IsNullOrWhiteSpace(member.FullName))
            {
                member.FullName = user.UserName;
            }

            return member;
        }
    }
}