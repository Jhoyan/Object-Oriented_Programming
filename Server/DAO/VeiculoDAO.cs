using Shared.Models;
using Server.Utilities;
using MySql.Data.MySqlClient;


namespace Server.DAO
{
    public class VeiculoDAO
    {
        public void CreateVeiculo(Veiculo veiculo)
        {
            string sql = "INSERT INTO veiculo (chassi_veiculo, placa_veiculo, FK_id_proprietario, FK_id_modelo, FK_id_cor, FK_id_tipoveiculo)VALUES(@chassi, @placa, @id_proprietario, @id_modelo, @id_cor, @id_tipoveiculo);";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
            try
            {
                comando.Parameters.AddWithValue("@chassi", veiculo.Chassi_veiculo);
                comando.Parameters.AddWithValue("@placa", veiculo.Placa_veiculo);
                comando.Parameters.AddWithValue("@id_proprietario", veiculo.FK_id_proprietario);
                comando.Parameters.AddWithValue("@id_modelo", veiculo.FK_id_modelo);
                comando.Parameters.AddWithValue("@id_cor", veiculo.FK_id_cor);
                comando.Parameters.AddWithValue("@id_tipoveiculo", veiculo.FK_id_tipoveiculo);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao inserir veículo: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
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
        public Veiculo ListarVeiculoPorId(int id_veiculo)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Id_veiculo = id_veiculo;
            try
            {
                string sql = "SELECT id_veiculo, chassi_veiculo, placa_veiculo, FK_id_proprietario, FK_id_modelo, FK_id_cor, FK_id_tipoveiculo FROM veiculo WHERE id_veiculo = @id_veiculo;";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@id_veiculo", id_veiculo);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        veiculo.Id_veiculo = reader.GetInt32("id_veiculo");
                        veiculo.Chassi_veiculo = reader.GetString("chassi_veiculo");
                        veiculo.Placa_veiculo = reader.GetString("placa_veiculo");
                        veiculo.FK_id_proprietario = reader.GetInt32("FK_id_proprietario");
                        veiculo.FK_id_modelo = reader.GetInt32("FK_id_modelo");
                        veiculo.FK_id_cor = reader.GetInt32("FK_id_cor");
                        veiculo.FK_id_tipoveiculo = reader.GetInt32("FK_id_tipoveiculo");
                        veiculo.cor_veiculo = new CorDAO().ListarCorPorId(veiculo.FK_id_cor);
                        veiculo.modelo_veiculo = new ModeloDAO().ListarModeloPorId(veiculo.FK_id_modelo);
                        veiculo.tipoVeiculo_veiculo = new TipoVeiculoDAO().ListarTipoVeiculoPorId(veiculo.FK_id_tipoveiculo);
                        veiculo.proprietario_veiculo = new ProprietarioDAO().ListProprietarioPorId(veiculo.FK_id_proprietario);
                    }
                }

                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar veículo por ID: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        public void UpdateVeiculo(Veiculo veiculo)
        {
            string sql = "UPDATE veiculo SET chassi_veiculo = @chassi, placa_veiculo = @placa, FK_id_proprietario = @proprietario, FK_id_modelo = @modelo, FK_id_cor = @cor, FK_id_tipoveiculo = @tipoveiculo WHERE id_veiculo = @id_veiculo";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@chassi", veiculo.Chassi_veiculo);
                comando.Parameters.AddWithValue("@placa", veiculo.Placa_veiculo);
                comando.Parameters.AddWithValue("@proprietario", veiculo.FK_id_proprietario);
                comando.Parameters.AddWithValue("@modelo", veiculo.FK_id_modelo);
                comando.Parameters.AddWithValue("@cor", veiculo.FK_id_cor);
                comando.Parameters.AddWithValue("@tipoveiculo", veiculo.FK_id_tipoveiculo);
                comando.Parameters.AddWithValue("@id_veiculo", veiculo.Id_veiculo);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao atualizar veículo: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        public void DeleteVeiculo(int id_veiculo)
        {
            string sql = "DELETE FROM veiculo WHERE id_veiculo = @id_veiculo;";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            try
            {
                comando.Parameters.AddWithValue("@id_veiculo", id_veiculo);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao excluir veículo: {ex.Message}");
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}