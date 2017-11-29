namespace Adikov.Domain.Queries
{
    public interface IQueryBuilder
    {
        IQueryFor<TResult> For<TResult>() where TResult : class;
    }
}