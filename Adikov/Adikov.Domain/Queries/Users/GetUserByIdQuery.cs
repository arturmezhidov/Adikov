using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Users
{
    public class EditUserInfo
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public string Interests { get; set; }

        public string About { get; set; }

        public string Website { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class GetUserByIdQueryResult
    {
        public EditUserInfo User { get; set; }

        public bool IsFound { get; set; }
    }

    public class GetUserByIdQuery : Query<IdCriterion, GetUserByIdQueryResult>
    {
        protected override GetUserByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            var user = DataContext.Users.Find(criterion.Id);

            var result = new GetUserByIdQueryResult
            {
                IsFound = user != null
            };

            if (result.IsFound)
            {
                result.User = new EditUserInfo
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    About = user.About,
                    Occupation = user.Occupation,
                    Interests = user.Interests,
                    Website = user.Website
                };
            }

            return result;
        }
    }
}