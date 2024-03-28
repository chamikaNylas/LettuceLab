using Shared.Kernal.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernal.Domain
{
    public class AggregateRoot : Entity<Guid>
    {
        private readonly List<IDomainEvent> _changes = new();
        public AggregateRoot(Guid id):base(id)
        {
        }
        protected void RaiseDomainEvent(IDomainEvent @event)
        {
            _changes.Add(@event);
        }
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents()=>_changes.ToList();
        public void ClearDomainEvents()=>_changes.Clear();

    }
}
