using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class AddProductCommand : CommandBase
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TableId { get; set; }
    }

    public class AddProductCommandResult : CommandResult
    {
        public Product Product { get; set; }
    }

    public class AddProductCommandHandler : CommandHandler<AddProductCommand, AddProductCommandResult>
    {
        protected override void OnHandling(AddProductCommand command, AddProductCommandResult result)
        {
            Product product = new Product
            {
                Name = command.Name,
                CategoryId = command.CategoryId,
                TableId = command.TableId
            };

            DataContext.Products.Add(product);

            result.Product = product;
        }
    }
}