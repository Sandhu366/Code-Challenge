using Common.Dtos.Read;
using Core.QueryManager;

namespace ApplicationShared.Remarks.Queries
{
    public class GetRemarksByIdQuery: IQuery<RemarkReadDto>
    {
        public int Id { get; set; }
        
        public GetRemarksByIdQuery(int id)
        {
            Id = id;
        }
    }
}
