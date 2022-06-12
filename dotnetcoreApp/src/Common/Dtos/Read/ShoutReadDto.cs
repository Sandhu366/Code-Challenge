using System.Collections.Generic;

namespace Common.Dtos.Read
{
    public class ShoutReadDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public IEnumerable<RemarkReadDto> Remarks { get; set; }
    }
}
