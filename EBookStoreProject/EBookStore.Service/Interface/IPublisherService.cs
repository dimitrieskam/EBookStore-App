
using EBookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Interface
{
    public interface IPublisherService
    {
        List<Publisher> GetAllPublishers();
        Publisher GetDetailsForPublisher(Guid? id);
        void CreateNewPublisher(Publisher p);
        void UpdateExistingPublisher(Publisher p);
        void DeletePublisher(Guid id);
        Publisher GetPublisherByName(string name);
    }
}
