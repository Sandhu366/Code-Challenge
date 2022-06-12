using Core.CommandManager;

namespace ApplicationShared.Remarks.Commands
{
    public class CreateRemarkCommand : ICommand
    {

        public CreateRemarkCommand(
            string body,
            int shoutId)
        {
            Body = body;
            ShoutId = shoutId;
        }

        public string Body { get; }
        public int ShoutId { get; }
    }
}
