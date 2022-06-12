using ApplicationShared.Shouts;
using AutoMapper;
using Common.Dtos.Read;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Shouts.QueryHandlers
{
    public class GetShoutsQueryHandler : IQueryHandler<GetShoutsQuery, List<ShoutReadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetShoutsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ShoutReadDto>> Handle(GetShoutsQuery request, CancellationToken cancellationToken)
        {
            List<Shout> shouts = await _unitOfWork
                .GetGenericRepository<Shout>()
                .GetAll()
                .Include(x => x.Remarks)
                .AsQueryable()
                .ToListAsync();

            return _mapper.Map<List<ShoutReadDto>>(shouts);
        }
    }
}
