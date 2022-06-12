using Core.CommandManager;

namespace ApplicationShared.Remarks.Commands
{
    public class DeleteRemarkCommand : ICommand
    {
        public DeleteRemarkCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
