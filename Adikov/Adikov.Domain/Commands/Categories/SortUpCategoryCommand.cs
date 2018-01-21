using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class SortUpCategoryCommand : CommandBase
    {
        public int CategoryId { get; set; }
    }

    public class SortUpCategoryCommandHandler : CommandHandler<SortUpCategoryCommand>
    {
        protected override void OnHandling(SortUpCategoryCommand command, CommandResult result)
        {
            List<Category> categories = DataContext.Categories.OrderBy(i => i.SortNumber).ToList();

            if (!categories.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (categories.First().Id == command.CategoryId)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = 1; i < categories.Count; i++)
            {
                Category category = categories[i];
                category.SortNumber = i;

                if (category.Id == command.CategoryId)
                {
                    Category prevCategory = categories[i - 1];
                    category.SortNumber = prevCategory.SortNumber;
                    prevCategory.SortNumber = i;
                }

                DataContext.Entry(category).State = EntityState.Modified;
            }
        }
    }
}