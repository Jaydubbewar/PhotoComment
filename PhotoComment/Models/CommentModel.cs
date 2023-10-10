using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoComment.Models
{
    [Table("comment")]

    public class CommentModel
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        // Foreign key for Photo (one-to-many)
        public int PhotoId { get; set; }
        public PhotoModel Photo { get; set; }
    }
}
