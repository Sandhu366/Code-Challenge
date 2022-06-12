using Core.CommandManager;

namespace ApplicationShared.Remarks.Commands
{
    public class EditRemarkCommand : ICommand
    {
        public EditRemarkCommand(
            int id,
            string body)
        {
            Id = id;
            Body = body;
        }

        public int Id { get; }
        public string Body { get; }
    }
}
