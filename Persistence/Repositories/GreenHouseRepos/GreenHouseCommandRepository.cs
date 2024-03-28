using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.GreenHouseRepos
{
    internal class GreenHouseCommandRepository : CommandRepository<GreenHouse>
    {
        public GreenHouseCommandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
