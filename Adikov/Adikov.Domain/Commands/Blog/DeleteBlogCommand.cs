using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class DeleteBlogCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteBlogCommandHandler : CommandHandler<DeleteBlogCommand>
    {
        protected override void OnHandling(DeleteBlogCommand command, CommandResult result)
        {
            var item = DataContext.Blogs.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}