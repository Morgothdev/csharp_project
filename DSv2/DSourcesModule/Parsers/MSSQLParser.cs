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
        internal static string Name = "MSSQL DataBase";
        internal override bool IsFinal { get { return true; } }

        internal override InternalParser ClonePrototype()
        {
            InternalParser nev = new MSSQLParser();
            nev.Init();
            return nev;
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName=Name;
            Arguments.RemoveArgument(SqlDbParser.SERVER_PORT_KEY);
        }

        internal override DbConnectionStringBuilder getDbConnectionStringBuilder() { return new SqlConnectionStringBuilder(); }
        internal override DbConnection getDbConnection(string connectionString) { return new SqlConnection(connectionString); }
        internal override DbCommand getDbCommand(string sql, DbConnection connection) { return new SqlCommand(sql, (SqlConnection)connection); }

    }
}
