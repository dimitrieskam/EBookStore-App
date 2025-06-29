using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.DTO
{
    public class PublisherDTO
    {
        public string Name { get; set; }
        
        public string Address { get; set; }
       
        public double Rating { get; set; }
       
        public string MobileNum { get; set; }
    }
}
