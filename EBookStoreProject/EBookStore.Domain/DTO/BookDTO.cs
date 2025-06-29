using EBookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.DTO
{
    public class BookDTO
    {
        public String Title { get; set; }
       
        public string BookCover { get; set; }
        public String Description { get; set; }
       
        public double Rating { get; set; }
       
        public String Genre { get; set; }
       
        public Int32 QuantityAvaiable { get; set; }
        public double Price { get; set; }
        public AuthorDTO Author { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
