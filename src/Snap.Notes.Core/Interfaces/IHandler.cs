using Snap.Notes.Core.SharedKernel;

namespace Snap.Notes.Core.Interfaces
{
    public interface IHandler<T> where T: BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
