using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class AddFaqCategoryCommand : CommandBase
    {
        public string CategoryName { get; set; }

        public bool IsPublished { get; set; }
    }

    public class AddFaqCategoryCommandHandler : CommandHandler<AddFaqCategoryCommand>
    {
        protected override void OnHandling(AddFaqCategoryCommand command, CommandResult result)
        {
            FaqCategory category = new FaqCategory
            {
                Name = command.CategoryName,
                IsPublished = command.IsPublished
            };

            DataContext.FaqCategories.Add(category);
        }
    }
}