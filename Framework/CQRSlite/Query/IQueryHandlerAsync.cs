using System.Threading.Tasks;

namespace CQRSlite.Query
{
    public interface IQueryHandlerAsync<in TQueryAsync, TResponse> where TQueryAsync : IQueryAsync<TResponse>
    {
        Task<TResponse> Handle(TQueryAsync query);
    }
}
