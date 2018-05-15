using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class PublishBlogCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class PublishBlogCommandHandler : CommandHandler<PublishBlogCommand>
    {
        protected override void OnHandling(PublishBlogCommand command, CommandResult result)
        {
            var item = DataContext.Blogs.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsPublished = true;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}