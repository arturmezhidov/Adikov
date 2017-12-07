using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Categories
{
    public class EditCategoryCommand : CommandBase
    {
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public bool IsFileChanged { get; set; }
    }

    public class EditCategoryCommandHandler : CommandHandler<EditCategoryCommand>
    {
        protected override void OnHandling(EditCategoryCommand command, CommandResult result)
        {
            var category = DataContext.Categories.Find(command.Id);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            category.Name = command.Name;
            category.Icon = command.Icon;

            if (command.IsFileChanged)
            {
                category.FileId = command.FileId;
            }

            DataContext.Entry(category).State = EntityState.Modified;
        }
    }
}