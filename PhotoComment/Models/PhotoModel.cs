using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoComment.Models
{
    [Table("photo")]
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        // Relationship to Comment model (one-to-many)
        public List<CommentModel> Comments { get; set; }
    }
}
