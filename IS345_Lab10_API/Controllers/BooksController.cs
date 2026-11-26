using Microsoft.AspNetCore.Mvc;

namespace IS345_Lab10_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        // GET api/Books/category/1
        [HttpGet("category/{cata}")]
        public IActionResult GetBooksByCategory(int cata)
        {
            var books = _context.Books.Where(b => b.Category == cata).ToList();

            if (books.Count == 0)
            {
                return NotFound(new { message = "No books found in this category" });
            }

            return Ok(books);
        }
    }
}
