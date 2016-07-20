using System.Threading.Tasks;

namespace CQRSlite.Messages
{
    public interface IHandlerAsync<in T> where T : IMessageAsync
    {
        Task Handle(T message);
    }
}
