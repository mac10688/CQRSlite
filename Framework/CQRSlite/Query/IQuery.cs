using CQRSlite.Messages;

namespace CQRSlite.Query
{
    public interface IQuery<out TResponse> : IMessage
    {
    }
}
