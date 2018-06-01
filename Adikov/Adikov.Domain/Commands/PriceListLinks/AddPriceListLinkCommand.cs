using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.PriceListLinks
{
    public class AddPriceListLinkCommand : CommandBase
    {
        public string Text { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }

    public class AddPriceListLinkCommandHandler : CommandHandler<AddPriceListLinkCommand>
    {
        protected override void OnHandling(AddPriceListLinkCommand command, CommandResult result)
        {
            var newItem = new PriceListLink
            {
                Text = command.Text,
                Description = command.Description,
                Url = command.Url,
                IsDeleted = false
            };

            try
            {
                newItem.OrderNumber = DataContext.PriceListLinks.Count() + 1;
            }
            catch
            {
                newItem.OrderNumber = 1;
            }

            DataContext.PriceListLinks.Add(newItem);
        }
    }
}