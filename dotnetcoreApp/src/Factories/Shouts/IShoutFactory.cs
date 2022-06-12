using ApplicationShared.Shouts.Commands;
using Domain;

namespace Factories.Shouts
{
    public interface IShoutFactory
    {
        Shout UpdateShout(Shout destination, EditShoutCommand source);
    }
}
