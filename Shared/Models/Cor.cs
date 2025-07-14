using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Cor
    {
        public int Id_cor { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória")]
        public string Nome_cor { get; set; }
                
    }
}
