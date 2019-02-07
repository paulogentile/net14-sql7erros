using System.Data.SqlClient;

namespace MeuTrabalho.Repo
{
    public class LogRepository : ILogRepository
    {
        string _connectionString;
        public LogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertLog(string info)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT tbLog(texto) VALUES (@texto)", connection);

                cmd.Parameters.AddWithValue("@texto", info);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
