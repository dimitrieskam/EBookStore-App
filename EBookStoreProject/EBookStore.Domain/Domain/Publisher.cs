using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.Domain
{
    public class Publisher : BaseEntity
    {
 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string MobileNum { get; set; }

    }
}
