
using System.Linq.Expressions;



namespace Shared.Kernal.Spesifications
{
    public abstract class Specification<T> 
    {
        public abstract bool IsSatisfiedBy(T entity);

        public Expression<Func<T, bool>> Criteria { get; }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}


