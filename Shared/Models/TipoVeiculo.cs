using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TipoVeiculo
    {
        public int Id_tipoVeiculo { get; set; }
        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        public string Nome_tipoVeiculo { get; set; }        
    }
}
