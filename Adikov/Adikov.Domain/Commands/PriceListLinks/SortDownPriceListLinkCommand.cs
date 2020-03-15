using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;
using System.Data.Entity;
using System.Linq;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class SortDownPriceListLinkCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class SortDownPriceListLinkCommandHandler : CommandHandler<SortDownPriceListLinkCommand>
    {
        protected override void OnHandling(SortDownPriceListLinkCommand command, CommandResult result)
        {
            var items = DataContext.PriceListLinks
                .Where(i => !i.IsDeleted)
                .OrderBy(i => i.OrderNumber)
                .ToList();

            if (!items.Any())
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (items.Last().Id == command.Id)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = items.Count - 2; i >= 0; i--)
            {
                PriceListLink item = items[i];
                item.OrderNumber = i;

                if (item.Id == command.Id)
                {
                    PriceListLink next = items[i + 1];
                    item.OrderNumber = next.OrderNumber;
                    next.OrderNumber = i;
                }

                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}