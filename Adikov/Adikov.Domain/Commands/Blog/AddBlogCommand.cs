using System;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Blog
{
    public class AddBlogCommand : CommandBase
    {
        public string Title { get; set; }

        public string PreviewContent { get; set; }

        public string HtmlContent { get; set; }

        public bool IsPublished { get; set; }

        public int FileId { get; set; }
    }

    public class AddBlogCommandResult : CommandResult
    {
        public Models.Blog Blog { get; set; }
    }

    public class AddBlogCommandHandler : CommandHandler<AddBlogCommand, AddBlogCommandResult>
    {
        protected override void OnHandling(AddBlogCommand command, AddBlogCommandResult result)
        {
            var newItem = new Models.Blog
            {
                Title = command.Title,
                PreviewContent = command.PreviewContent,
                HtmlContent = command.HtmlContent,
                IsPublished = command.IsPublished,
                CreatedDate = DateTime.Now,
                FileId = command.FileId,
            };

            DataContext.Blogs.Add(newItem);

            result.Blog = newItem;
        }
    }
}