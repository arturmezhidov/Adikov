using Adikov.Infrastructura.Commands;

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

            DataContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}