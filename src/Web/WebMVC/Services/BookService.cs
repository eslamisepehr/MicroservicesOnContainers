using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class BookService : IBookService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly ILogger<BookService> _logger;
        private readonly string _bookByPassUrl;

        public BookService(HttpClient httpClient, IOptions<AppSettings> settings, ILogger<BookService> logger)
        {
            _apiClient = httpClient;
            _settings = settings;
            _logger = logger;

            _bookByPassUrl = $"{_settings.Value.BookUrl}/api";
        }

        public async Task<Book> AddBook(string name, string email)
        {
            var uri = API.Book.DoSomething(_bookByPassUrl, name, email);
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new Book() :
                JsonConvert.DeserializeObject<Book>(responseString);
        }
    }
}
