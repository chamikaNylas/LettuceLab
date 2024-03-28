using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernal.Spesifications
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification1;
        private readonly Specification<T> _specification2;

        public AndSpecification(Specification<T> specification1, Specification<T> specification2)
        {
            _specification1 = specification1;
            _specification2 = specification2;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return _specification1.IsSatisfiedBy(entity) && _specification2.IsSatisfiedBy(entity);
        }
    }
}
