using System.Data.SqlClient;
namespace DAL
{
    public class ConnectionManager
    {
        public readonly SqlConnection _connection;

        public ConnectionManager(string connection)
        {
            _connection = new SqlConnection(connection);
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}