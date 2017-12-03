using System.Collections.Generic;
using System.Linq;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Product
{
    public class AddProductCommand : CommandBase
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public List<int> AttributesIds { get; set; }
    }

    public class AddProductCommandHandler : CommandHandler<AddProductCommand>
    {
        protected override void OnHandling(AddProductCommand command, CommandResult result)
        {
            Models.Product product = new Models.Product
            {
                Name = command.Name,
                ProductCategoryId = command.CategoryId
            };

            List<Models.ProductAttribute> attributes = DataContext
                .ProductAttributes
                .Where(i => command.AttributesIds.Contains(i.Id))
                .ToList();

            attributes.ForEach(i =>
            {
                product.ProductAttributes.Add(i);
            });

            DataContext.Products.Add(product);
        }
    }
}