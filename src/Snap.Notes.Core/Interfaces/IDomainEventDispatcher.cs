using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
