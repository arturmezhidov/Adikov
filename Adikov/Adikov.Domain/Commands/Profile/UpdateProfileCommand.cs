using System.Data.Entity;
using Adikov.Infrastructura.Commands;
using Adikov.Infrastructura.Security;

namespace Adikov.Domain.Commands.Profile
{
    public class UpdateProfileCommand : CommandBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Occupation { get; set; }

        public string Interests { get; set; }

        public string About { get; set; }

        public string Website { get; set; }
    }

    public class UpdateProfileCommandHandler : CommandHandler<UpdateProfileCommand, CommandResult>
    {
        protected override void OnHandling(UpdateProfileCommand command, CommandResult result)
        {
            ApplicationUser user = DataContext.Users.Find(UserContext.UserId);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Fail;
                return;
            }

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.PhoneNumber = command.PhoneNumber;
            user.Occupation = command.Occupation;
            user.Interests = command.Interests;
            user.About = command.About;
            user.Website = command.Website;

            UserContext.UpdateClaim(ClaimsTypes.USER_FIRST_NAME, command.FirstName);
            UserContext.UpdateClaim(ClaimsTypes.USER_LAST_NAME, command.LastName);
            UserContext.UpdateClaim(ClaimsTypes.USER_PHONE_NUMBER, command.PhoneNumber);
            UserContext.UpdateClaim(ClaimsTypes.USER_OCCUPATION, command.Occupation);
            UserContext.UpdateClaim(ClaimsTypes.USER_INTERESTS, command.Interests);
            UserContext.UpdateClaim(ClaimsTypes.USER_ABOUT, command.About);
            UserContext.UpdateClaim(ClaimsTypes.USER_WEBSITE, command.Website);

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}