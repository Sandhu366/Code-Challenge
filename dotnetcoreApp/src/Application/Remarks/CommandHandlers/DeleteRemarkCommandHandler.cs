using ApplicationShared.Remarks.Commands;
using Core.CommandManager;
using Domain;
using MediatR;
using Persistence;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Remarks.CommandHandlers
{
    public class DeleteRemarkCommandHandler : ICommandHandler<DeleteRemarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;

        public DeleteRemarkCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork, IUnitOfWork unitOfWork)
        {
            _persistenceUnitOfWork = persistenceUnitOfWork;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRemarkCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork
                .GetGenericRepository<Remark>()
                .RemoveById(request.Id);
            
            bool success = await _persistenceUnitOfWork.SaveChangesAsync() > 0;

            if(success)
            {
                return Unit.Value;
            }

            throw new Exception("Problem deleting the remark");
        }
    }
}
