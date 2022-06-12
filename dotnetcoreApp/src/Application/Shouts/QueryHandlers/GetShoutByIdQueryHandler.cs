using ApplicationShared.Shouts.Queries;
using AutoMapper;
using Common.Dtos.Read;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Shouts.QueryHandlers
{
    public class GetShoutByIdQueryHandler : IQueryHandler<GetShoutByIdQuery, ShoutReadDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetShoutByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShoutReadDto> Handle(GetShoutByIdQuery request, CancellationToken cancellationToken)
        {
            Shout shout = await _unitOfWork
                .GetGenericRepository<Shout>()
                .FindBy(x => x.Id == request.Id)
                .Include(x => x.Remarks)
                .SingleOrDefaultAsync();

            return _mapper.Map<ShoutReadDto>(shout);
        }
    }
}
