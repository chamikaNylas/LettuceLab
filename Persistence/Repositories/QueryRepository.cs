using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public  class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {

        private readonly ApplicationDbContext _dbContext;

        public QueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public DbSet<TEntity> Query() => _dbContext.Set<TEntity>();
    }
}
