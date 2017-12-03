using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductCategory
{
    public class AddProductCategoryCommand : CommandBase
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public ProductCategoryType Type { get; set; }
    }

    public class AddProductCategoryCommandHandler : CommandHandler<AddProductCategoryCommand>
    {
        protected override void OnHandling(AddProductCategoryCommand command, CommandResult result)
        {
            var newItem = new  Models.ProductCategory
            {
                Icon = command.Icon,
                Name = command.Name,
                Type = command.Type,
                FileId = command.FileId
            };

            DataContext.ProductCategories.Add(newItem);
        }
    }
}