using CQRSlite.Messages;

namespace CQRSlite.Query
{
    public interface IQueryAsync<out Response> : IMessageAsync
    {
    }
}
