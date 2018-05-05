using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class UnpublishFaqCategoryCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class UnpublishFaqCategoryCommandHandler : CommandHandler<UnpublishFaqCategoryCommand>
    {
        protected override void OnHandling(UnpublishFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = DataContext.FaqCategories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.IsPublished = false;

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}