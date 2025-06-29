using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.DTO
{
    public class AuthorDTO
    {
        public String Name { get; set; }
        
        public String Surname { get; set; }
       
        public string AuthorImage { get; set; }
       
        public string Biography { get; set; }
    }
}
