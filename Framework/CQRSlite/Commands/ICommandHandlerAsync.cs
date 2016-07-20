using CQRSlite.Messages;

namespace CQRSlite.Commands
{
    public interface ICommandHandlerAsync<in T> : IHandlerAsync<T> where T : ICommandAsync
    {
    }
}
