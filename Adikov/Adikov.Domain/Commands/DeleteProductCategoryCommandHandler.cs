using System.Data.Entity;

namespace Adikov.Domain.Commands
{
    public class DeleteProductCategoryCommand : ICommand
    {
        public int Id { get; }

        public DeleteProductCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductCategoryCommandHandler : CommandHandler<DeleteProductCategoryCommand>
    {
        protected override void OnHandling(DeleteProductCategoryCommand command)
        {
            var item = DataContext.ProductCategories.Find(command.Id);

            if (item != null)
            {
                item.IsDeleted = true;
                DataContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}