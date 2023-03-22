using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AllViewModel
    {
        public List<ProPokeViewModel> Poke { get; set; } = new();
        public List<RegionViewModel> Region { get; set; } = new();
        public List<TipoViewModel> Tipo { get; set; } = new();
    }
}
