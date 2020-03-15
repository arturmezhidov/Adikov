using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class EditPriceListLinkCommand : CommandBase
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }

    public class EditPriceListLinkCommandHandler : CommandHandler<EditPriceListLinkCommand>
    {
        protected override void OnHandling(EditPriceListLinkCommand command, CommandResult result)
        {
            var item = DataContext.PriceListLinks.Find(command.Id);

            if(item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Text = command.Text;
            item.Description = command.Description;
            item.Url = command.Url;

            DataContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}