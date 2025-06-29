using EBookStore.Domain.Identity;
using EBookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<EBookStoreAppUser> entities;
        string errorMessage = string.Empty;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<EBookStoreAppUser>();
        }
        public void Delete(EBookStoreAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public EBookStoreAppUser Get(string id)
        {
            var strGuid = id.ToString();
            return entities
                .Include(z => z.UserCart)
                .Include(z => z.UserCart.ProductInShoppingCarts)
                .Include("UserCart.ProductInShoppingCarts.Book")
                .First(s => s.Id == strGuid);
        }

        public IEnumerable<EBookStoreAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(EBookStoreAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(EBookStoreAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
