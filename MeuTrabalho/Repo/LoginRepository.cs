using System.Data;
using System.Data.SqlClient;

namespace MeuTrabalho.Repo
{
    public class LoginRepository : ILoginRepository
    {
        string _connectionString;
        public LoginRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool UsuarioValido(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT username FROM tbLogin WHERE email=@Email AND pwd=@Pass", connection);

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = password;

                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.NextResult();
                }
            }
        }
    }
}
