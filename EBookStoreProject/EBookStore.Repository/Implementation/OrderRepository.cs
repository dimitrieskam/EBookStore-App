using EBookStore.Domain.Domain;
using EBookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
         public List<Order> GetAllOrders()
         {
             return entities
                 .Include(z => z.BooksInOrders)
                 .Include("BooksInOrders.OrderedProduct")
                 .Include(z => z.Owner)
                 .ToList();

         }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(z => z.BooksInOrders)
                .Include(z => z.Owner)
                .Include("BooksInOrders.OrderedProduct")
                .Include("BooksInOrders.OrderedProduct.Author")
                .Include("BooksInOrders.OrderedProduct.Publisher")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
