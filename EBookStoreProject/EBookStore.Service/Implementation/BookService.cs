using EBookStore.Domain.Domain;
using EBookStore.Repository.Interface;
using EBookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateNewBook(Book book)
        {
            _bookRepository.Insert(book);
        }

        public void DeleteBook(Guid id)
        {
            var product = _bookRepository.Get(id);
            _bookRepository.Delete(product);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            var book = _bookRepository.Get(id);
            return book;
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
