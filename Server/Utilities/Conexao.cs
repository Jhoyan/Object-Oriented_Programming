using MySql.Data.MySqlClient;

namespace Server.Utilities
{
    internal class Conexao
    {
        public static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=ReiDaVaga;Convert Zero Datetime=true";

                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                return conexao;
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }
        public static void Desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();
            }
        }
    }
}