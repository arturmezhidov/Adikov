using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Users
{
    public class UserInfo
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public string Interests { get; set; }

        public string About { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsLock { get; set; }
    }

    public class Users
    {
        public List<UserInfo> ActiveUsers { get; set; }

        public List<UserInfo> LockedUsers { get; set; }
    }

    public class GetAllUsersQueryResult
    {
        public Users Users { get; set; }
    }

    public class GetAllUsersQuery : Query<EmptyCriterion, GetAllUsersQueryResult>
    {
        private string adminId;

        protected override GetAllUsersQueryResult OnExecuting(EmptyCriterion criterion)
        {
            adminId = DataContext.Roles.FirstOrDefault(i => i.Name == "admin")?.Id;

            var users = DataContext.Users.Include(i => i.Roles).Select(ToUserInfo).ToList();

            var result = new GetAllUsersQueryResult
            {
                Users = new Users
                {
                    ActiveUsers = users.Where(i => !i.IsLock).ToList(),
                    LockedUsers = users.Where(i => i.IsLock).ToList()
                }
            };

            return result;
        }

        private UserInfo ToUserInfo(ApplicationUser user)
        {
            return new UserInfo
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                About = user.About,
                Occupation = user.Occupation,
                Interests = user.Interests,
                Website = user.Website,
                IsLock = user.IsLock,
                IsAdmin = user.Roles.Any(i => i.RoleId == adminId)
            };
        }
    }
}