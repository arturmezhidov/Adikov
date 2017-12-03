namespace Adikov.Infrastructura.Queries
{
    public interface IQueryBuilder
    {
        IQueryFor<TResponse> For<TResponse>() where TResponse : class;
    }
}