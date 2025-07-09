using MySql.Data.MySqlClient;
using Server.Utilities;
using Shared.Models;

namespace Server.DAO
{
    public class ProprietarioDAO
    {
        public void CreateProprietario(Proprietario proprietario, int ultimoInserido)
        {
            string sql = "INSERT INTO proprietario(cnh_proprietario, FK_id_pessoa) VALUES(@cnh, @id_pessoa);";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@cnh", proprietario.Cnh);
                comando.Parameters.AddWithValue("@id_pessoa", ultimoInserido);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao inserir proprietario: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        public List<Proprietario> ListProprietario()
        {
            List<Proprietario> proprietarios = new List<Proprietario>();

            try
            {
                string sql = "SELECT id_proprietario, nome_pessoa, cpf_pessoa, cnh_proprietario FROM proprietario INNER JOIN pessoa ON proprietario.FK_id_pessoa = pessoa.id_pessoa;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proprietario proprietario = new Proprietario
                        {
                            Id_proprietario = reader.GetInt32("id_proprietario"),
                            Nome = reader.GetString("nome_pessoa"),
                            Cpf = reader.GetString("cpf_pessoa"),
                            Cnh = reader.GetString("cnh_proprietario")
                        };
                        proprietarios.Add(proprietario);
                    }
                }

                Conexao.Desconectar();
                return proprietarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Proprietario ListProprietarioPorId(int? id)
        {
            Proprietario proprietarioPorId = new Proprietario();
            proprietarioPorId.Id_proprietario = id ?? 0;
            try
            {
                string sql = "SELECT id_proprietario, nome_pessoa, cpf_pessoa, cnh_proprietario, dataNasc_pessoa, sexo_pessoa, FK_id_pessoa FROM proprietario INNER JOIN pessoa ON proprietario.FK_id_pessoa = pessoa.id_pessoa WHERE id_proprietario = @id;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proprietarioPorId.Nome = reader.GetString("nome_pessoa");
                        proprietarioPorId.Cpf = reader.GetString("cpf_pessoa");
                        proprietarioPorId.Cnh = reader.GetString("cnh_proprietario");
                        proprietarioPorId.DataNasc = reader.GetDateTime("dataNasc_pessoa");
                        proprietarioPorId.Sexo = reader.GetString("sexo_pessoa");
                        proprietarioPorId.Id_pessoa = reader.GetInt32("FK_id_pessoa");
                    }
                }

                Conexao.Desconectar();
                return proprietarioPorId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProprietario(Proprietario proprietario)
        {
            string sql = "UPDATE proprietario SET cnh_proprietario = @cnh WHERE id_proprietario = @id;";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@id", proprietario.Id_proprietario);
                comando.Parameters.AddWithValue("@cnh", proprietario.Cnh);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao atualizar proprietario: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
