using MySql.Data.MySqlClient;
using Shared.Models;
using Server.Utilities;

namespace Server.DAO
{
    public class TipoVeiculoDAO
    {
        public List<TipoVeiculo> ListarTiposVeiculo()
        {
            List<TipoVeiculo> tiposVeiculo = new List<TipoVeiculo>();

            try
            {
                string sql = "SELECT id_tipoveiculo, nome_tipoveiculo FROM TipoVeiculo;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoVeiculo tipoVeiculo = new TipoVeiculo
                        {
                            Id_tipoVeiculo = reader.GetInt32("id_tipoveiculo"),
                            Nome_tipoVeiculo = reader.GetString("nome_tipoveiculo")
                        };
                        tiposVeiculo.Add(tipoVeiculo);
                    }
                }

                return tiposVeiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar tipos de veículo: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public TipoVeiculo ListarTipoVeiculoPorId(int id)
        {
            TipoVeiculo tipoVeiculo = new TipoVeiculo();

            try
            {
                string sql = "SELECT id_tipoveiculo, nome_tipoveiculo FROM TipoVeiculo WHERE id_tipoveiculo = @id;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipoVeiculo.Id_tipoVeiculo = reader.GetInt32("id_tipoveiculo");
                        tipoVeiculo.Nome_tipoVeiculo = reader.GetString("nome_tipoveiculo");
                    }
                }
                return tipoVeiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar tipo de veículo por ID: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
