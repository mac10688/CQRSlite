using System.Threading.Tasks;

namespace CQRSlite.Query
{
    public interface IQueryRetrieverAsync
    {
        Task<T> Query<T>(IQueryAsync<T> query);
    }
}
