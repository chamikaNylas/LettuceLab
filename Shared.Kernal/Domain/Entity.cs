using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernal.Domain
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
    {
        protected Entity(TId id)
        {
            Id = id;
        }

        public TId Id { get; protected set; }

        public bool Equals(Entity<TId>? other)
        {
            return Equals(other as Entity<TId>);
          
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !Equals(left, right);
        }
    }

}
