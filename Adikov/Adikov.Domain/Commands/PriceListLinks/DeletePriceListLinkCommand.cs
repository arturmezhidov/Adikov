using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class DeletePriceListLinkCommand : CommandBase
    {
        public int Id { get; set; }
    }

    public class DeletePriceListLinkCommandHandler : CommandHandler<DeletePriceListLinkCommand>
    {
        protected override void OnHandling(DeletePriceListLinkCommand command, CommandResult result)
        {
            var item = DataContext.PriceListLinks.Find(command.Id);

            if(item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;
            item.OrderNumber = -1;

            DataContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}