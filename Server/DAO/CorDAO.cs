using MySql.Data.MySqlClient;
using Shared.Models;
using Server.Utilities;
using System.Security.Cryptography.X509Certificates;

namespace Server.DAO
{
    public class CorDAO
    {
        public List<Cor> ListarCores()
        {
            List<Cor> Cores = new List<Cor>();

            try
            {
                string sql = "SELECT id_cor, nome_cor FROM cor;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cor cor = new Cor
                        {
                            Id_cor = reader.GetInt32("id_cor"),
                            Nome_cor = reader.GetString("nome_cor")
                        };
                        Cores.Add(cor);
                    }
                }
                
                return Cores;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar cores: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }            
        }
        public Cor ListarCorPorId(int id_cor)
        {
            Cor cor = new Cor();

            try
            {
                string sql = "SELECT id_cor, nome_cor FROM cor WHERE id_cor = @id_cor;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_cor", id_cor);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cor.Id_cor = reader.GetInt32("id_cor");
                        cor.Nome_cor = reader.GetString("nome_cor");
                    }
                }

                return cor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar cor por ID: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
}
