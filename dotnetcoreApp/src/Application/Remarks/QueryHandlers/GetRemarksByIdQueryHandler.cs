using ApplicationShared.Remarks.Queries;
using AutoMapper;
using Common.Dtos.Read;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Remarks.QueryHandlers
{
    public class GetRemarksByIdQueryHandler : IQueryHandler<GetRemarksByIdQuery, RemarkReadDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRemarksByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RemarkReadDto> Handle(GetRemarksByIdQuery request, CancellationToken cancellationToken)
        {
            Remark remark = await _unitOfWork
                .GetGenericRepository<Remark>()
                .FindBy(x => x.Id == request.Id)
                .Include(x => x.Shout)
                .FirstOrDefaultAsync();

            return _mapper.Map<RemarkReadDto>(remark);
        }
    }
}
