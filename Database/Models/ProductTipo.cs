using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ProductTipo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductPokemon> ProductPokemon { get; set; }
    }
}
