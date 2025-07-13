using MySql.Data.MySqlClient;
using Server.Utilities;
using Shared.Models;

namespace Server.DAO
{
    public class ModeloDAO
    {
        public List<Modelo> ListarModelos()
        {
            List<Modelo> modelos = new List<Modelo>();

            try
            {
                string sql = "SELECT id_modelo, nome_modelo FROM modelo;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Modelo modelo = new Modelo
                        {
                            Id_modelo = reader.GetInt32("id_modelo"),
                            Nome_modelo = reader.GetString("nome_modelo")
                        };
                        modelos.Add(modelo);
                    }
                }
                
                return modelos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar modelos: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public Modelo ListarModeloPorId(int id_modelo)
        {
            Modelo modelo = new Modelo();

            try
            {
                string sql = "SELECT id_modelo, nome_modelo FROM modelo WHERE id_modelo = @id_modelo;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_modelo", id_modelo);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        modelo.Id_modelo = reader.GetInt32("id_modelo");
                        modelo.Nome_modelo = reader.GetString("nome_modelo");
                    }
                }

                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar modelo por ID: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
