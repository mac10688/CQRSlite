using CQRSlite.Messages;

namespace CQRSlite.Events
{
    public interface IEventHandlerAsync<in T> : IHandlerAsync<T> where T : IEventAsync
    { }
}
