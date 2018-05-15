using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class UnpublishBlogCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class UnpublishBlogCommandHandler : CommandHandler<UnpublishBlogCommand>
    {
        protected override void OnHandling(UnpublishBlogCommand command, CommandResult result)
        {
            var item = DataContext.Blogs.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsPublished = false;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}