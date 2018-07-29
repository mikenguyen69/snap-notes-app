using Snap.Notes.Core.Events;
using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }   
    }
}
