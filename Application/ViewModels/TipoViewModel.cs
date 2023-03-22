using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TipoViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Debes Colocar el tipo")]
        public string Name { get; set; }
       
    }
}
