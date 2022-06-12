using Core.CommandManager;

namespace ApplicationShared.Shouts.Commands
{
    public class CreateShoutCommand : ICommand
    {
        public CreateShoutCommand(
            string body,
            int upvotes,
            int downvotes)
        {
            Body = body;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }

        public string Body { get; }
        public int Upvotes { get; }
        public int Downvotes { get; }
    }
}
