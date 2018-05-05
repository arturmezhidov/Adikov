using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class DeleteFaqCategoryCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeleteFaqCategoryCommandHandler : CommandHandler<DeleteFaqCategoryCommand>
    {
        protected override void OnHandling(DeleteFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = DataContext.FaqCategories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.IsDeleted = true;

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}