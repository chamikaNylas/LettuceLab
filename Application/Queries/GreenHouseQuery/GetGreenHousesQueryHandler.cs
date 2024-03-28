using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GreenHouseQuery
{
    public class GetGreenHousesQueryHandler : IRequestHandler<GetGreenHousesQuery, IEnumerable<GreenHouseDto>>
    {
        private readonly IQueryRepository<GreenHouse> _queryRepository;
        public GetGreenHousesQueryHandler(IQueryRepository<GreenHouse> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<GreenHouseDto>> Handle(GetGreenHousesQuery request, CancellationToken cancellationToken)
        {
            var greenHouses = await _queryRepository.Query().ToListAsync(cancellationToken);
            return greenHouses.Select(g => new GreenHouseDto
            {
                No = g.No,
                Name = g.Name
            });
        }
    }
}
