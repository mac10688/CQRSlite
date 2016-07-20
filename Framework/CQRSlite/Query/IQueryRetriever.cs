namespace CQRSlite.Query
{
    public interface IQueryRetriever
    {
        T Query<T>(IQuery<T> query);
    }
}
