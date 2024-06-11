using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cervantesforms.Repositorios
{
    public class DbConexao : IDisposable

    {
        private readonly IDbConnection connection;
        public DbConexao()
        {
            connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=cadastropessoa_canal;User Id=postgres;Password=gustavoroldao;");
        }

        public IDbConnection GetConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}
