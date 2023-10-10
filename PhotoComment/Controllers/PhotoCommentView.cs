using PhotoComment.Models;

namespace PhotoComment.Controllers
{
    internal class PhotoCommentView
    {
        public List<PhotoModel> Photos { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}