using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Remark : EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ShoutId { get; set; }

        public Shout Shout { get; set; }

        [StringLength(512, ErrorMessage = "Remarks must be 512 characters or less.")]
        public string Body { get; set; }
    }
}
