using Book.API.IntegrationEvents.Events;
using EslamiSepehr.EventBus.Abstractions;
using System;

namespace Book.API.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IEventBus eventBus;

        public BookService(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public Model.Book AddBook(string name, string email)
        {
            Random rand = new Random();
            Model.Book book = new Model.Book { Id = rand.Next(), Name = name };

            var @event = new EmailSendIntegrationEvent(email, "New Book Added", book.ToString());
            eventBus.Publish(@event);

            return book;
        }

    }
}