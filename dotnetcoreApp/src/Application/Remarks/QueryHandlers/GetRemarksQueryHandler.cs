using ApplicationShared.Remarks.Queries;
using AutoMapper;
using Common.Dtos.Read;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Remarks.QueryHandlers
{
    public class GetRemarksQueryHandler : IQueryHandler<GetRemarksQuery, List<RemarkReadDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRemarksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RemarkReadDto>> Handle(GetRemarksQuery request, CancellationToken cancellationToken)
        {

            List<Remark> remarks = await _unitOfWork
                .GetGenericRepository<Remark>()
                .GetAll()
                .Include(x => x.Shout)
                .ToListAsync();

            return _mapper.Map<List<RemarkReadDto>>(remarks);
        }
    }
}
