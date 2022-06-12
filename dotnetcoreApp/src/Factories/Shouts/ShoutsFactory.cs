using ApplicationShared.Shouts.Commands;
using AutoMapper;
using Domain;
using System;

namespace Factories.Shouts
{
    public class ShoutFactory : IShoutFactory
    {
        private readonly IMapper _mapper;

        public ShoutFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Shout UpdateShout(Shout destination, EditShoutCommand source)
        {
            if (source is null)
            {
                throw new NullReferenceException($"{nameof(EditShoutCommand)} is null");
            }

            if (source.Body == destination.Body)
            {
                destination.Body = source.Body;
            }

            if (source.Upvotes == destination.Upvotes)
            {
                destination.Upvotes = source.Upvotes;
            }

            if (source.Downvotes == destination.Downvotes)
            {
                destination.Downvotes = source.Downvotes;
            }

            return destination;
        }
    }
}
