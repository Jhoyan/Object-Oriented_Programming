using System.Reflection.PortableExecutable;

namespace Shared.Models
{
    public class Veiculo
    {
        public int Id_veiculo { get; set; }
        public string Chassi_veiculo { get; set; }
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
