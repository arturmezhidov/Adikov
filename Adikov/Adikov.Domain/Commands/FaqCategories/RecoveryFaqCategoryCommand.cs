using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class RecoveryFaqCategoryCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class RecoveryFaqCategoryCommandHandler : CommandHandler<RecoveryFaqCategoryCommand>
    {
        protected override void OnHandling(RecoveryFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = DataContext.FaqCategories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.IsDeleted = false;

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}