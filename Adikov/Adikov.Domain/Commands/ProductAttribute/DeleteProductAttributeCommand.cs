using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class DeleteProductAttributeCommand : CommandBase
    {
        public int Id { get; }

        public DeleteProductAttributeCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductAttributeCommandHandler : CommandHandler<DeleteProductAttributeCommand>
    {
        protected override void OnHandling(DeleteProductAttributeCommand command, CommandResult result)
        {
            var item = DataContext.ProductAttributes.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = true;
            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}