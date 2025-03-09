using Microsoft.Data.SqlClient;

namespace Ado.netDisconnectedOrientedExamplewith3databases.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        SqlConnection MidLandSqlConnectionString();
        SqlConnection Northwind_DBSqlConnectionString();
        SqlConnection HotelmanagementsqlConnectionString();
    }
}
