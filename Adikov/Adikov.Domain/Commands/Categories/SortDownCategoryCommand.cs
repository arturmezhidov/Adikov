using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class SortDownCategoryCommand : CommandBase
    {
        public int CategoryId { get; set; }
    }

    public class SortDownCategoryCommandHandler : CommandHandler<SortDownCategoryCommand>
    {
        protected override void OnHandling(SortDownCategoryCommand command, CommandResult result)
        {
            List<Category> categories = DataContext.Categories.OrderBy(i => i.SortNumber).ToList();

            if (!categories.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (categories.Last().Id == command.CategoryId)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = categories.Count - 2; i >= 0; i--)
            {
                Category category = categories[i];
                category.SortNumber = i;

                if (category.Id == command.CategoryId)
                {
                    Category nextCategory = categories[i + 1];
                    category.SortNumber = nextCategory.SortNumber;
                    nextCategory.SortNumber = i;
                }

                DataContext.Entry(category).State = EntityState.Modified;
            }
        }
    }
}