namespace Shared.Models
{
    public class Proprietario
    {
        private int id { get; set; }
        private string nome { get; set; }
        private string cpf { get; set; }
        private DateOnly dataNascimento { get; set; }
        private char sexo { get; set; }
        private string cnh { get; set; }
    }
}
