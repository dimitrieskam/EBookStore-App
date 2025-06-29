using EBookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Interface
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        Book GetDetailsForBook(Guid? id);
        void CreateNewBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);

    }
}
