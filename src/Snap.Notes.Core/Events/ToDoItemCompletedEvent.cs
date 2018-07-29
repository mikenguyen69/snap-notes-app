using Snap.Notes.Core.Entities;
using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }

    }
}
