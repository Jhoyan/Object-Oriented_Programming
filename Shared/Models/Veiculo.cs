using System.Reflection.PortableExecutable;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Veiculo
    {
        public int Id_veiculo { get; set; }

        [Required(ErrorMessage = "O chassi é obrigatório.")]
        public string Chassi_veiculo { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória.")]
        [RegularExpression(@"^[A-Z]{3}-\d{4}$|^[A-Z]{3}-\d{1}[A-Z]{1}\d{3}$", ErrorMessage = "A placa deve estar no formato AAA-0000 ou AAA-0A00.")] // BUGADO, SÓ FUNCIONA AAA-0000
        public string Placa_veiculo { get; set; }


        public int FK_id_proprietario { get; set; }


        public int FK_id_modelo { get; set; }


        public int FK_id_cor { get; set; }


        public int FK_id_tipoveiculo { get; set; }


        public Proprietario proprietario_veiculo { get; set; }


        public Cor cor_veiculo { get; set; }


        public Modelo modelo_veiculo { get; set; }


        public TipoVeiculo tipoVeiculo_veiculo { get; set; }
    }
}
