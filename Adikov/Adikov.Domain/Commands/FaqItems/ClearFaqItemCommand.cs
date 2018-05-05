using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.FaqItems
{
    public class ClearFaqItemCommand : CommandBase
    {
    }

    public class ClearFaqItemCommandHandler : CommandHandler<ClearFaqItemCommand>
    {
        protected override void OnHandling(ClearFaqItemCommand command, CommandResult result)
        {
            IEnumerable<FaqItem> items = DataContext.FaqItems.Where(i => i.IsDeleted);

            DataContext.FaqItems.RemoveRange(items);
        }
    }
}