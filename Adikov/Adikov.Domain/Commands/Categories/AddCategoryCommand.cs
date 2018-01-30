using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class AddCategoryCommand : CommandBase
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public CategoryType Type { get; set; }
    }

    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand>
    {
        protected override void OnHandling(AddCategoryCommand command, CommandResult result)
        {
            var newItem = new Category
            {
                Icon = command.Icon,
                Name = command.Name,
                Type = command.Type,
                FileId = command.FileId,
                SortNumber = DataContext.Categories.Count()
            };

            DataContext.Categories.Add(newItem);
        }
    }
}