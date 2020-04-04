namespace Book.API.Infrastructure.Services
{
    public interface IBookService
    {
        Model.Book AddBook(string name, string email);
    }
}
