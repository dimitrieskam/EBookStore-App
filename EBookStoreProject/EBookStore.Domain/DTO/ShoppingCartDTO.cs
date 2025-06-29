using EBookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<BookInShoppingCart>? AllBooks { get; set; }
        public double TotalPrice { get; set; }
    }
}
