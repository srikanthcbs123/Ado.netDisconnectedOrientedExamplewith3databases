using Ado.netDisconnectedOrientedExamplewith3databases.Interfaces;
using Ado.netDisconnectedOrientedExamplewith3databases.Utility;
using Microsoft.Data.SqlClient;

namespace Ado.netDisconnectedOrientedExamplewith3databases.Connection
{
    public class ConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _config;
        public ConnectionFactory(IConfiguration config) 
        {
            this._config = config;
        }
        //Don't hard code connecting sting like below.
        // string connectionString = "data source=DESKTOP-AAO14OC;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement;integrated security=yes";
        //always read the connection string from appsettings.json file like below.
        public SqlConnection HotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Hotelmanagement_DBConnectionstringname).Value);
            // Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }

        public SqlConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Midland_DBConnectionstringname).Value);
            //Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection con = new SqlConnection(connStr);
            return con;
        }

        public SqlConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection(Connectionstringname.Northwind_DBConnectionstringname).Value);
            // Creates an SqlConnection Object to store the sqlconnection.
            SqlConnection _connection = new SqlConnection(connStr);
            return _connection;
        }
    }
}
