using EBookStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<EBookStoreAppUser> GetAll();
        EBookStoreAppUser Get(string id);
        void Insert(EBookStoreAppUser entity);
        void Update(EBookStoreAppUser entity);
        void Delete(EBookStoreAppUser entity);
    }
}
