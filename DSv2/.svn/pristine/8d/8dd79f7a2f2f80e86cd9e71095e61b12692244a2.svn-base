using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DSources.Parsers
{
    /**
     * Czytnik do bazy <A HREF="http://www.postgresql.org/">PostreSQL</A><br>
     * Wymaga podania parametrów do połączenia z bazą 
     * <ul><li>adres serwera</li><li>port</li><li>login/hasło użytkownika</li><li>nazwa bazy danych</li></ul><br>
     * oraz requestu sqlowego do wykonania w podanej bazie.
     */
    class PostgreSQLParser : SqlDbParser
    {

        internal override bool IsFinal { get { return true; } }

        internal override string parserName { get { return "PostgreSQL"; } }

        internal override InternalParser ClonePrototype()
        {
            return new PostgreSQLParser();
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = "PostgreSQL DataBase";
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
        }

        internal override DbConnectionStringBuilder getOdbcConnectionStringBuilder() { return new NpgsqlConnectionStringBuilder(); }
        internal override DbConnection getOdbcConnection(string connectionString) { return new NpgsqlConnection(connectionString); }
        internal override DbCommand getOdbcCommand(string sql, DbConnection connection) { return new NpgsqlCommand(sql, (NpgsqlConnection)connection); }
    }
}
