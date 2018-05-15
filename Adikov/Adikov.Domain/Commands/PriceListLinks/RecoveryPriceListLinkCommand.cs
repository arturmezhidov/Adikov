using Adikov.Infrastructura.Commands;
using System.Linq;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class RecoveryPriceListLinkCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class RecoveryPriceListLinkCommandHandler : CommandHandler<RecoveryPriceListLinkCommand>
    {
        protected override void OnHandling(RecoveryPriceListLinkCommand command, CommandResult result)
        {
            var item = DataContext.PriceListLinks.Find(command.Id);

            if(item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = false;
            item.OrderNumber = DataContext.PriceListLinks.Count() + 1;

            DataContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}