using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Czytnik dla <a href="http://www.microsoft.com/poland/sql-2012/">Microsoft Sql Server</a>.
     * Wymaga podania parametrów do połączenia z bazą 
     * <ul><li>adres serwera</li><li>login/hasło użytkownika</li><li>nazwa bazy danych</li></ul><br>
     * oraz requestu sqlowego do wykonania w podanej bazie.
     */
    class MSSQLParser : SqlDbParser
    {
        internal override bool IsFinal { get { return true; } }

        internal override string parserName { get { return "MSSQL"; } }

        internal override InternalParser ClonePrototype()
        {
            return new MySQLParser();
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = "MSSQL DataBase";
            Arguments.RemoveArgument(SqlDbParser.SERVER_PORT_KEY);
        }

        internal override DbConnectionStringBuilder getOdbcConnectionStringBuilder() { return new SqlConnectionStringBuilder(); }
        internal override DbConnection getOdbcConnection(string connectionString) { return new SqlConnection(connectionString); }
        internal override DbCommand getOdbcCommand(string sql, DbConnection connection) { return new SqlCommand(sql, (SqlConnection)connection); }

    }
}
