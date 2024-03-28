using Microsoft.EntityFrameworkCore;
using Shared.Kernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Query();   
    }
   
}
