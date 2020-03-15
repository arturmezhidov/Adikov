using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;
using System.Data.Entity;
using System.Linq;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class SortUpPriceListLinkCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class SortUpPriceListLinkCommandHandler : CommandHandler<SortUpPriceListLinkCommand>
    {
        protected override void OnHandling(SortUpPriceListLinkCommand command, CommandResult result)
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

            if (items.First().Id == command.Id)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            for (int i = 1; i < items.Count; i++)
            {
                PriceListLink item = items[i];
                item.OrderNumber = i;

                if (item.Id == command.Id)
                {
                    PriceListLink prevItem = items[i - 1];
                    item.OrderNumber = prevItem.OrderNumber;
                    prevItem.OrderNumber = i;
                }

                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}