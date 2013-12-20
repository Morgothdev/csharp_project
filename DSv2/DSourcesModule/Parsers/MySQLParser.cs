using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Czytnik do bazy danych <A HREF="http://www.mysql.com/">MySQL</a><br>
     * Wymaga podania parametrów do połączenia z bazą 
     * <ul><li>adres serwera</li><li>port</li><li>login/hasło użytkownika</li><li>nazwa bazy danych</li></ul><br>
     * oraz requestu sqlowego do wykonania w podanej bazie.
     */
    class MySQLParser : SqlDbParser
    {

        internal override bool IsFinal { get { return true; } }

        internal override string parserName { get { return "MySQL"; } }

        internal override InternalParser ClonePrototype()
        {
            return new MySQLParser();
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = "MySQL DataBase";
        }

        internal override DbConnectionStringBuilder getOdbcConnectionStringBuilder() { return new MySqlConnectionStringBuilder(); }
        internal override DbConnection getOdbcConnection(string connectionString) { return new MySqlConnection(connectionString); }
        internal override DbCommand getOdbcCommand(string sql, DbConnection connection) { return new MySqlCommand(sql, (MySqlConnection)connection); }

    }
}
