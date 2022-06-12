using ApplicationShared.Remarks.Commands;
using Core.CommandManager;
using Domain;
using Factories.Remarks;
using MediatR;
using Persistence;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Remarks.CommandHandlers
{
    public class EditRemarkCommandHandler : ICommandHandler<EditRemarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRemarkFactory _remarkFactory;
        private readonly IPersistenceUnitOfWork _persistentUnitOfWork;

        public EditRemarkCommandHandler(
            IUnitOfWork unitOfWork,
            IPersistenceUnitOfWork persistentUnitOfWork,
            IRemarkFactory remarkFactory)
        {
            _unitOfWork = unitOfWork;
            _persistentUnitOfWork = persistentUnitOfWork;
            _remarkFactory = remarkFactory;
        }

        public async Task<Unit> Handle(EditRemarkCommand request, CancellationToken cancellationToken)
        {
            Remark remark = await _unitOfWork
                .GetGenericRepository<Remark>()
                .FindByIdAsync(request.Id);

            _remarkFactory.UpdateRemark(remark, request);

            if (!_unitOfWork.HasUnsavedChanges())
            {
                return Unit.Value;
            }

            var success = await _persistentUnitOfWork.SaveChangesAsync() > 0;

            if (success)
            {
                return Unit.Value;
            }

            throw new Exception("Problem with updating remark");
        }
    }
}
