using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ProductPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int TipoId { get; set; }
        public int TipoIdSec { get; set; }
        public int RegionId { get; set; }

        public ProductTipo Tipo { get; set; }
        public ProductRegion Region { get; set; }



    }
}
