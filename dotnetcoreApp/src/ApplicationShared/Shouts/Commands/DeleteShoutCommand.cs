using Core.CommandManager;

namespace ApplicationShared.Shouts.Commands
{
    public class DeleteShoutCommand : ICommand
    {
        public DeleteShoutCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
