using Book.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public string Index()
        {
            return "Hello Book Microservice :)";
        }

        public int DoSomething(string name, string email)
        {
            var book = bookService.AddBook(name, email);
            return book.Id;
        }
    }
}