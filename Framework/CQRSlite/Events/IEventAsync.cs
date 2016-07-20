using CQRSlite.Messages;
using System;

namespace CQRSlite.Events
{
    public interface IEventAsync : IMessageAsync
    {
        Guid Id { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}
