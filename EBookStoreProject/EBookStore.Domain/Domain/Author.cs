using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.Domain
{
    public class Author : BaseEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public string AuthorImage { get; set; }
        [Required]
        public string Biography { get; set; }

    }
}
