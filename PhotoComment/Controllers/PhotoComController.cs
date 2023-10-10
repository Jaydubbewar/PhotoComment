using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoComment.Models;

namespace PhotoComment.Controllers
{
    public class PhotoComController : Controller
    {
        private readonly PhotoContext _context;

        public PhotoComController(PhotoContext context)
        {
            _context = context;
        }

        private List<PhotoModel> photos = new List<PhotoModel>();
        private List<CommentModel> comments = new List<CommentModel>();

       
        // GET: PhotoComController
        public ActionResult Index()
        {
            var viewModel = new PhotoCommentViewModel
            {
                Photos = _context.Photos.ToList(),
                Comments = _context.Comments.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddComment(int id, string commentText)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                return NotFound(); // Handle not found
            }

            // Add the comment (e.g., save to the database)
            var comment = new CommentModel { Text = commentText, PhotoId = id };
            _context.Comments.Add(comment);
            _context.SaveChanges();
           
            return RedirectToAction("index");
        }

        // GET: PhotoComController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoComController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhotoModel photo)
        {
          
          
                _context.Photos.Add(photo);
                _context.SaveChanges();

                return RedirectToAction("Index");
          
        }

      

       

       
    }
}
