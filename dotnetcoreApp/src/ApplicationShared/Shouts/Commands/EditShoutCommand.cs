using Core.CommandManager;

namespace ApplicationShared.Shouts.Commands
{
    public class EditShoutCommand : ICommand
    {
        public EditShoutCommand(
            int id,
            string body,
            int upvotes,
            int downvotes
            )
        {
            Id = id;
            Body = body;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }

        public int Id { get; }
        public string Body { get; }
        public int Upvotes { get; }
        public int Downvotes { get; }
    }
}
