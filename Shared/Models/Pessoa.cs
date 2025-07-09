using System.ComponentModel.DataAnnotations;


namespace Shared.Models
{
    public class Pessoa
    {        
        public int? Id_pessoa { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF deve conter 11 digitos numéricos.")]
        public string Cpf { get; set; }

        static string DataHoje = (DateOnly.FromDateTime(DateTime.Now)).ToString();

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]        
        // Falta implementar uma lógica para não permitir datas futuras. Fiquei travado aqui.
        public DateTime? DataNasc { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório.")]
        public string Sexo { get; set; }
                
    }
}
