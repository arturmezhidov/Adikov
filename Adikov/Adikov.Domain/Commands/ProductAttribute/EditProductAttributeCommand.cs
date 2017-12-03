using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class EditProductAttributeCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EditProductAttributeCommandHandler : CommandHandler<EditProductAttributeCommand>
    {
        protected override void OnHandling(EditProductAttributeCommand command, CommandResult result)
        {
            var item = DataContext.ProductAttributes.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Name = command.Name;

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}