using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name, string email)
        {
            Book book = await _bookService.AddBook(name, email);
            return View(book);
        }


    }
}