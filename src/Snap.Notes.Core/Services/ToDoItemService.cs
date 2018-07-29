using Ardalis.GuardClauses;
using Snap.Notes.Core.Events;
using Snap.Notes.Core.Interfaces;

namespace Snap.Notes.Core.Services
{
    public class ToDoItemService : IHandler<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do nothing
        }
    }
}
