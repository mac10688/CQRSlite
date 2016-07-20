using CQRSlite.Messages;

namespace CQRSlite.Commands
{
    public interface ICommandAsync : IMessageAsync
    {
        int ExpectedVersion { get; set; }
    }
}
