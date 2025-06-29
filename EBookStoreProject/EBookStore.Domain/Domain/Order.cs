using EBookStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EBookStore.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string? OwnerId { get; set; }
        public EBookStoreAppUser? Owner { get; set; }

        public IEnumerable <BookInOrder>? BooksInOrders { get; set; }
    }
}
