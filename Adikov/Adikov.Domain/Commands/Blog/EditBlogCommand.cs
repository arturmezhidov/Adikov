using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class EditBlogCommand : CommandBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PreviewContent { get; set; }

        public string HtmlContent { get; set; }

        public bool IsPublished { get; set; }

        public int? FileId { get; set; }
    }

    public class EditBlogCommandHandler : CommandHandler<EditBlogCommand>
    {
        protected override void OnHandling(EditBlogCommand command, CommandResult result)
        {
            var item = DataContext.Blogs.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Title = command.Title;
            item.PreviewContent = command.PreviewContent;
            item.HtmlContent = command.HtmlContent;
            item.IsPublished = command.IsPublished;

            if (command.FileId.HasValue)
            {
                item.FileId = command.FileId.Value;
            }

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}