using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello Email Microservice :)";
        }
    }
}