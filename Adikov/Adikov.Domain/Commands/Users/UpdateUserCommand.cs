using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Users
{
    public class UpdateUserCommand : CommandBase
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

    public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand>
    {
        protected override void OnHandling(UpdateUserCommand command, CommandResult result)
        {
            var user = DataContext.Users.Find(command.Id);

            if (user == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            user.Id = command.Id;
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.PhoneNumber = command.PhoneNumber;
            user.About = command.About;
            user.Occupation = command.Occupation;
            user.Interests = command.Interests;
            user.Website = command.Website;

            DataContext.Entry(user).State = EntityState.Modified;
        }
    }
}