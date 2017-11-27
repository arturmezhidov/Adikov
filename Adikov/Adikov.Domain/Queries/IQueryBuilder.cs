namespace Adikov.Domain.Queries
{
    public interface IQueryBuilder
    {
        IQueryFor<TEntity> For<TEntity>() where TEntity : class;
    }
}