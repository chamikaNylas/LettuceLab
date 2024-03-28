using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using Shared.Kernal.Spesifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public CommandRepository(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetBySpecificationAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
           return  await _dbContext.Set<TEntity>()
           .Where(specification.Criteria)
           .ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }


        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
