using Common.Dtos.Read;
using Core.QueryManager;
using System.Collections.Generic;

namespace ApplicationShared.Shouts
{
    public class GetShoutsQuery: IQuery<List<ShoutReadDto>>
    {
    }
}
