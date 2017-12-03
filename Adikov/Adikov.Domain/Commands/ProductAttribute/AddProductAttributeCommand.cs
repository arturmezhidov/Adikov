using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class AddProductAttributeCommand : CommandBase
    {
        public string Name { get; set; }

        public ProductAttributeType Type { get; set; }
    }

    public class AddProductAttributeCommandHandler : CommandHandler<AddProductAttributeCommand>
    {
        protected override void OnHandling(AddProductAttributeCommand command, CommandResult result)
        {
            var newItem = new Models.ProductAttribute
            {
                Name = command.Name,
                Type = command.Type
            };

            DataContext.ProductAttributes.Add(newItem);
        }
    }
}