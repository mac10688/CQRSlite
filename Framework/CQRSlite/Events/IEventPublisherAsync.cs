using System.Threading.Tasks;

namespace CQRSlite.Events
{
    public interface IEventPublisherAsync
    {
        Task Publish<T>(T @event) where T : IEventAsync;
    }
}
