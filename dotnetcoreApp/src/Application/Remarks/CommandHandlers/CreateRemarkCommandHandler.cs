using ApplicationShared.Remarks.Commands;
using Common.Errors;
using Core.CommandManager;
using Domain;
using MediatR;
using Persistence;
using Persistence.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Remarks.CommandHandlers
{
    public class CreateRemarkCommandHandler : ICommandHandler<CreateRemarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;

        public CreateRemarkCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork, IUnitOfWork unitOfWork)
        {
            _persistenceUnitOfWork = persistenceUnitOfWork;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateRemarkCommand commmand, CancellationToken cancellationToken)
        {
            if (commmand is null)
            {
                throw new RemarkNotSavedException($"${nameof(CreateRemarkCommand)} is null.");
            }

            Remark remark = MapRequestToActivity(commmand);

            _unitOfWork
                .GetGenericRepository<Remark>()
                .Add(remark);

            await _persistenceUnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        private static Remark MapRequestToActivity(CreateRemarkCommand request)
        {
            return new Remark
            {
                Body = request.Body,
                ShoutId = request.ShoutId
            };
        }
    }
}
