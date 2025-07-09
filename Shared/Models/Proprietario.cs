using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Proprietario : Pessoa
    {        
        public int? Id_proprietario { get; set; }

        [Required(ErrorMessage = "A CNH é obrigatória.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "A CNH deve conter 11 dígitos numéricos.")]
        public string Cnh { get; set; }                     
    }
}
