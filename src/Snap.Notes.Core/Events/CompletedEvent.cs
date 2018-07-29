using Snap.Notes.Core.Entities;
using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Events
{
    public class CompletedEvent<T> : BaseDomainEvent where T : BaseEntity
    {
        public T CompletedItem { get; set; }

        public CompletedEvent(T completedItem)
        {
            CompletedItem = completedItem;
        }

    }
}
