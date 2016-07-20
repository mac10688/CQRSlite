using CQRSlite.Commands;
using CQRSlite.Events;
using CQRSlite.Messages;
using CQRSlite.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSlite.Bus
{
    public class InProcessBusAsync : ICommandSenderAsync, IEventPublisherAsync, IQueryRetrieverAsync, IHandleRegistrarAsync
    {
        private readonly Dictionary<Type, List<Action<IMessageAsync>>> _routes = new Dictionary<Type, List<Action<IMessageAsync>>>();
        //private readonly Dictionary<Type, List<Func<IMessageAsync,Response>>> _queryHandlers = new Dictionary<Type, List<Func<IMessageAsync,>>>();

        public Task RegisterHandler<T>(Action<T> handler) where T : IMessageAsync
        {
            List<Action<IMessageAsync>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessageAsync>>();
                _routes.Add(typeof(T), handlers);
            }

            return Task.FromResult(0);
        }

        //public void RegisterHandler<T>(Action<T> handler) where T : IMessageAsync
        //{
        //    List<Action<IMessageAsync>> handlers;
        //    if (!_routes.TryGetValue(typeof(T), out handlers))
        //    {
        //        handlers = new List<Action<IMessageAsync>>();
        //        _routes.Add(typeof(T), handlers);
        //    }
        //    handlers.Add((x => handler((T)x)));
        //}

        public async Task Send<T>(T command) where T : ICommandAsync
        {
            List<Action<IMessageAsync>> handlers;
            if (_routes.TryGetValue(typeof(T), out handlers))
            {
                if (handlers.Count != 1)
                {
                    throw new InvalidOperationException("Cannot send to more than one handler");
                }
                await Task.Factory.StartNew(() => { handlers[0](command); });                
            }
            else
            {
                throw new InvalidOperationException("No handler registered");
            }
        }

        //public void Send<T>(T command) where T : ICommand
        //{
        //    List<Action<IMessage>> handlers;
        //    if (_routes.TryGetValue(typeof(T), out handlers))
        //    {
        //        if (handlers.Count != 1)
        //        {
        //            throw new InvalidOperationException("Cannot send to more than one handler");
        //        }
        //        handlers[0](command);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("No handler registered");
        //    }
        //}

        public async Task Publish<T>(T @event) where T : IEventAsync
        {
            List<Action<IMessageAsync>> handlers;
            if (!_routes.TryGetValue(@event.GetType(), out handlers))
            {
                await Task.FromResult(0);
            }

            await Task.Factory.StartNew(() =>
            {
                foreach (var handler in handlers)
                {
                    handler(@event);
                }
            });            
        }

        //public void Publish<T>(T @event) where T : IEvent
        //{
        //    List<Action<IMessage>> handlers;
        //    if (!_routes.TryGetValue(@event.GetType(), out handlers))
        //    {
        //        return;
        //    }

        //    foreach (var handler in handlers)
        //    {
        //        handler(@event);
        //    }
        //}

        public Task<T> Query<T>(IQueryAsync<T> query)
        {
            //List<Action<IMessageAsync>> handlers;
            //if (_routes.TryGetValue(typeof(T), out handlers))
            //{
            //    if (handlers.Count != 1)
            //    {
            //        throw new InvalidOperationException("Cannot send to more than one handler");
            //    }
            //    await Task.Factory.StartNew(() => { handlers[0](query); });
            //}
            //else
            //{
            //    throw new InvalidOperationException("No handler registered");
            //}
            throw new NotImplementedException();
        }
    }
}
