using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.Integration
{
    public class Orders
    {
        public Guid Id { get; set; }
        public DateTime OrderedDate { get; set; }
    }
}
