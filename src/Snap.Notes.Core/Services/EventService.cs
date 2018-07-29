using Ardalis.GuardClauses;
using Snap.Notes.Core.Events;
using Snap.Notes.Core.Interfaces;
using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Services
{
    public class EventService<T> : IHandler<CompletedEvent<T>> where T: BaseEntity
    {
        public void Handle(CompletedEvent<T> domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do nothing
        }
    }
}
