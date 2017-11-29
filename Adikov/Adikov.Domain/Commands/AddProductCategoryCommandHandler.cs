using Adikov.Domain.Models;

namespace Adikov.Domain.Commands
{
    public class AddProductCategoryCommand : Command
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public ProductCategoryType Type { get; set; }
    }

    public class AddProductCategoryCommandHandler : CommandHandler<AddProductCategoryCommand>
    {
        protected override void OnHandling(AddProductCategoryCommand command)
        {
            var newItem = new ProductCategory
            {
                Icon = command.Icon,
                Name = command.Name,
                Type = command.Type
            };

            DataContext.ProductCategories.Add(newItem);
        }
    }
}