using Shared.Kernal.Domain;
using Shared.Kernal.Spesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    // Generic repository interface
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        Task<IEnumerable<TEntity>> GetBySpecificationAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    }

}
