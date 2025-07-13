using Shared.Models;
using Server.Utilities;
using MySql.Data.MySqlClient;


namespace Server.DAO
{
    public class VeiculoDAO
    {
        public List<Veiculo> ListarVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            try
            {
                string sql = "SELECT id_veiculo, chassi_veiculo, placa_veiculo, FK_id_proprietario, FK_id_modelo, FK_id_cor, FK_id_tipoveiculo FROM Veiculo";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Veiculo veiculo = new Veiculo
                        {
                            Id_veiculo = reader.GetInt32("id_veiculo"),
                            Chassi_veiculo = reader.GetString("chassi_veiculo"),
                            Placa_veiculo = reader.GetString("placa_veiculo"),
                            FK_id_proprietario = reader.GetInt32("FK_id_proprietario"),
                            FK_id_modelo = reader.GetInt32("FK_id_modelo"),
                            FK_id_cor = reader.GetInt32("FK_id_cor"),
                            FK_id_tipoveiculo = reader.GetInt32("FK_id_tipoveiculo"),
                            proprietario_veiculo = new ProprietarioDAO().ListProprietarioPorId(reader.GetInt32("FK_id_proprietario")),
                            cor_veiculo = new CorDAO().ListarCorPorId(reader.GetInt32("FK_id_cor")),
                            modelo_veiculo = new ModeloDAO().ListarModeloPorId(reader.GetInt32("FK_id_modelo")),
                            tipoVeiculo_veiculo = new TipoVeiculoDAO().ListarTipoVeiculoPorId(reader.GetInt32("FK_id_tipoveiculo"))
                        };
                        veiculos.Add(veiculo);
                    }
                }
                return veiculos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar veículos: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}