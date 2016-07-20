using System.Threading.Tasks;

namespace CQRSlite.Commands
{
    public interface ICommandSenderAsync
    {
        Task Send<T>(T command) where T : ICommandAsync;
    }
}
