using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class RecoveryBlogCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class RecoveryBlogCommandHandler : CommandHandler<RecoveryBlogCommand>
    {
        protected override void OnHandling(RecoveryBlogCommand command, CommandResult result)
        {
            var item = DataContext.Blogs.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = false;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}