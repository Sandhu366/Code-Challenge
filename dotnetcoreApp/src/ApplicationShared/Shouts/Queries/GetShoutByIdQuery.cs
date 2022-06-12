using Common.Dtos.Read;
using Core.QueryManager;

namespace ApplicationShared.Shouts.Queries
{
    public class GetShoutByIdQuery: IQuery<ShoutReadDto>
    {
        public int Id { get; set; }
        public GetShoutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
