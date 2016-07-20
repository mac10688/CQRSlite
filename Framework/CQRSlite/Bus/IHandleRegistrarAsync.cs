using CQRSlite.Messages;
using System;
using System.Threading.Tasks;

namespace CQRSlite.Bus
{
    public interface IHandleRegistrarAsync
    {
        Task RegisterHandler<T>(Action<T> handler) where T : IMessageAsync;
    }
}
