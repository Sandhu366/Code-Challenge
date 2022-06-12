using ApplicationShared.Shouts.Commands;
using Common.Errors;
using Core.CommandManager;
using Domain;
using MediatR;
using Persistence;
using Persistence.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Shouts.CommandHandlers
{
    public class CreateShoutCommandHandler : ICommandHandler<CreateShoutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;

        public CreateShoutCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork, IUnitOfWork unitOfWork)
        {
            _persistenceUnitOfWork = persistenceUnitOfWork;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateShoutCommand commmand, CancellationToken cancellationToken)
        {
            if (commmand is null)
            {
                throw new RemarkNotSavedException("Create Shout command is null.");
            }

            Shout shout = MapRequestToShout(commmand);

            _unitOfWork
                .GetGenericRepository<Shout>()
                .Add(shout);

            await _persistenceUnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        private static Shout MapRequestToShout(CreateShoutCommand request)
        {
            return new Shout
            {
                Body = request.Body,
                Upvotes = request.Upvotes,
                Downvotes = request.Downvotes
            };
        }
    }
}
