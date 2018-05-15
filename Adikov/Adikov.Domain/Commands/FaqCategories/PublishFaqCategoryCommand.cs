using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class PublishFaqCategoryCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class PublishFaqCategoryCommandHandler : CommandHandler<PublishFaqCategoryCommand>
    {
        protected override void OnHandling(PublishFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = DataContext.FaqCategories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.IsPublished = true;

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}