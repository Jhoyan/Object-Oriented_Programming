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
        public async void UpdatePessoa(Proprietario proprietario)
        {
            string sql = "UPDATE pessoa SET nome_pessoa = @Nome, cpf_pessoa = @Cpf, dataNasc_pessoa = @DataNasc, sexo_pessoa = @Sexo WHERE id_pessoa = @Id;";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@Id", proprietario.Id_pessoa);
                comando.Parameters.AddWithValue("@Nome", proprietario.Nome);
                comando.Parameters.AddWithValue("@Cpf", proprietario.Cpf);
                comando.Parameters.AddWithValue("@DataNasc", proprietario.DataNasc);
                comando.Parameters.AddWithValue("@Sexo", proprietario.Sexo);

                comando.ExecuteNonQuery();

                ProprietarioDAO proprietarioDAO = new ProprietarioDAO();
                proprietarioDAO.UpdateProprietario(proprietario);
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao atualizar pessoa: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
