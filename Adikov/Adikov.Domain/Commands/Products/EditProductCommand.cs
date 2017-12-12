using System.Data.Entity;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class EditProductCommand : CommandBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TableId { get; set; }
    }

    public class EditProductCommandHandler : CommandHandler<EditProductCommand>
    {
        protected override void OnHandling(EditProductCommand command, CommandResult result)
        {
            Product product = DataContext.Products.Find(command.Id);

            if (product == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Category category = DataContext.Categories.Find(command.CategoryId);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Table table = DataContext.Tables.Find(command.TableId);

            if (table == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            product.Name = command.Name;
            product.CategoryId = command.CategoryId;
            product.TableId = command.TableId;

            DataContext.Entry(product).State = EntityState.Modified;
        }
    }
}