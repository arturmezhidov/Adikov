using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class UpdateFaqCategoryCommand : CommandBase
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsPublished { get; set; }
    }

    public class UpdateFaqCategoryCommandHandler : CommandHandler<UpdateFaqCategoryCommand>
    {
        protected override void OnHandling(UpdateFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = DataContext.FaqCategories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.Name = command.CategoryName;
            category.IsPublished = command.IsPublished;

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}