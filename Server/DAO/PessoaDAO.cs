using Server.Utilities;
using MySql.Data.MySqlClient;
using Shared.Models;

namespace Server.DAO
{
    public class PessoaDAO
    {
        public async void CreatePessoa(Proprietario proprietario)
        {
            string sql = "INSERT INTO pessoa(nome_pessoa, cpf_pessoa, dataNasc_pessoa, sexo_pessoa) VALUES(@Nome, @Cpf, @DataNasc, @Sexo);";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@nome", proprietario.Nome);
                comando.Parameters.AddWithValue("@CPF", proprietario.Cpf);
                comando.Parameters.AddWithValue("@DataNasc", proprietario.DataNasc);
                comando.Parameters.AddWithValue("@sexo", proprietario.Sexo);

                comando.ExecuteNonQuery();

                ProprietarioDAO proprietarioDAO = new ProprietarioDAO();                
                proprietarioDAO.CreateProprietario(proprietario, (int)comando.LastInsertedId);
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
