using ApplicationShared.Shouts.Commands;
using Core.CommandManager;
using Domain;
using Factories.Shouts;
using MediatR;
using Persistence;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Shouts.CommandHandlers
{
    public class EditShoutCommandHandler : ICommandHandler<EditShoutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoutFactory _shoutFactory;
        private readonly IPersistenceUnitOfWork _persistentUnitOfWork;

        public EditShoutCommandHandler(
            IUnitOfWork unitOfWork,
            IPersistenceUnitOfWork persistentUnitOfWork,
            IShoutFactory shoutFactory)
        {
            _unitOfWork = unitOfWork;
            _persistentUnitOfWork = persistentUnitOfWork;
            _shoutFactory = shoutFactory;
        }

        public async Task<Unit> Handle(EditShoutCommand request, CancellationToken cancellationToken)
        {
            Shout shout = await _unitOfWork
                .GetGenericRepository<Shout>()
                .FindByIdAsync(request.Id);

            _shoutFactory.UpdateShout(shout, request);

            if (!_unitOfWork.HasUnsavedChanges())
            {
                return Unit.Value;
            }

            var success = await _persistentUnitOfWork.SaveChangesAsync() > 0;

            if (success)
            {
                return Unit.Value;
            }

            throw new Exception("Problem with updating Shout");
        }
    }
}
