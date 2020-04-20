using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public interface IBookService
    {
        Task<Book> AddBook(string name, string email);
    }
}