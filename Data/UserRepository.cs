using Microsoft.Data.SqlClient;

namespace SecureUserApp.Data
{
    public class UserRepository
    {
        public void SaveUser(string username, string email)
        {
            string query =
                "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";

            using SqlConnection connection =
                new SqlConnection("ConnectionString");

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Email", email);
        }
    }
}