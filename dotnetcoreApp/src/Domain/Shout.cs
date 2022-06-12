using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Shout : EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(256, ErrorMessage = "Remarks must be 512 characters or less.")]
        public string Body { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public ICollection<Remark> Remarks { get; set; }
    }
}
