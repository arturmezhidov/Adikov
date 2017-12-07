using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class AddProductCommand : CommandBase
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }

    public class AddProductCommandResult : CommandResult
    {
        public Models.Product Product { get; set; }
    }

    public class AddProductCommandHandler : CommandHandler<AddProductCommand, AddProductCommandResult>
    {
        protected override void OnHandling(AddProductCommand command, AddProductCommandResult result)
        {
            Models.Product product = new Models.Product
            {
                Name = command.Name,
                CategoryId = command.CategoryId
            };

            DataContext.Products.Add(product);

            result.Product = product;
        }
    }
}