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
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }


        public void CreateNewAuthor(Author a)
        {
            _authorRepository.Insert(a);
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _authorRepository.Get(id);
            _authorRepository.Delete(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public Author GetDetailsForAuthor(Guid? id)
        {
            var author = _authorRepository.Get(id);
            return author;
        }

        public void UpdateExistingAuthor(Author a)
        {
            _authorRepository.Update(a);
        }
        public Author GetAuthorByFullName(string firstName, string lastName)
        {
            return _authorRepository.GetAll()
                .FirstOrDefault(a => a.Name.ToLower() == firstName.ToLower() && a.Surname.ToLower() == lastName.ToLower());
        }
    }
}
