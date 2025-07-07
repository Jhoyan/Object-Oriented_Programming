using Server.Utilities;
using MySql.Data.MySqlClient;
using Shared.Models;

namespace Server.DAO
{
    public class PessoaDAO
    {
        public void CreatePessoa(Pessoa pessoa)
        {
            string sql = "INSERT INTO pessoa(nome_pessoa, cpf_pessoa, dataNasc_pessoa, sexo_pessoa) VALUES(@Nome, @Cpf, @DataNasc, @Sexo);";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
                comando.Parameters.AddWithValue("@DataNasc", pessoa.DataNasc);
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao inserir pessoa: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public Pessoa Get()
        {
            // Aqui você pode implementar a lógica para buscar uma pessoa no banco de dados
            return new Pessoa();
        }
    }
}
