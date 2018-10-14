using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Models
{
    public class DbConnection
    {
        public static string ConnectionId;

        private static string ConnectionString = @"Server=DESKTOP-4K8O21F\SQLEXPRESS;Database=DP;Integrated Security=True;User Id=root;Password=root";

        private static DbConnection instance = new DbConnection();

        private SqlConnection Connection;

        private SqlCommand Command;

        private DbConnection()
        {
            Connection = new SqlConnection(ConnectionString);
            ConnectionId = Guid.NewGuid().ToString();
        }

        private void Connect()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
                Connection.Open();
        }

        public static DbConnection GetInstance() => instance;


        public int Execute(string query, List<SqlParameter> parameters)
        {
            Connect();

            Command = new SqlCommand(query, Connection);

            if (Command != null)
                foreach (var parameter in parameters)
                    Command.Parameters.Add(parameter);

            int result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;
        }

        public DataTable Get(string query, List<SqlParameter> parameters)
        {
            Connect();

            Command = new SqlCommand(query, Connection);

            if (parameters != null)
                foreach (var parameter in parameters)
                    Command.Parameters.Add(parameter);

            SqlDataAdapter adapter = new SqlDataAdapter(Command);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            Connection.Close();

            return dataTable;
        }

        public object Scalar(string query, List<SqlParameter> parameters)
        {
            Connect();

            Command = new SqlCommand(query, Connection);

            if (parameters != null)
                foreach (var parameter in parameters)
                    Command.Parameters.Add(parameter);

            object result = Command.ExecuteScalar();

            Connection.Close();

            return result;
        }

    }
}
