using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqCategories
{
    public class ClearFaqCategoryCommand : CommandBase
    {
    }

    public class ClearFaqCategoryCommandHandler : CommandHandler<ClearFaqCategoryCommand>
    {
        protected override void OnHandling(ClearFaqCategoryCommand command, CommandResult result)
        {
            IEnumerable<FaqCategory> categories = DataContext.FaqCategories.Where(i => i.IsDeleted);

            DataContext.FaqCategories.RemoveRange(categories);
        }
    }
}