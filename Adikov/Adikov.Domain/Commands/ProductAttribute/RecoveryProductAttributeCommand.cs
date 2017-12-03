using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.ProductAttribute
{
    public class RecoveryProductAttributeCommand : CommandBase
    {
        public int Id { get; }

        public RecoveryProductAttributeCommand(int id)
        {
            Id = id;
        }
    }

    public class RecoveryProductAttributeCommandHandler : CommandHandler<RecoveryProductAttributeCommand>
    {
        protected override void OnHandling(RecoveryProductAttributeCommand command, CommandResult result)
        {
            var item = DataContext.ProductAttributes.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.IsDeleted = false;
            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}