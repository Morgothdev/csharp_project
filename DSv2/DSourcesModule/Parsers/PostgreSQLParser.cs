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
        public static string Name = "PostgreSQL DataBase";

        internal override bool IsFinal { get { return true; } }

        internal override InternalParser ClonePrototype()
        {
            InternalParser nev = new PostgreSQLParser();
            nev.Init();
            return nev;
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName =Name;
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
        }

        internal override DbConnectionStringBuilder getDbConnectionStringBuilder() { return new NpgsqlConnectionStringBuilder(); }
        internal override DbConnection getDbConnection(string connectionString) { return new NpgsqlConnection(connectionString); }
        internal override DbCommand getDbCommand(string sql, DbConnection connection) { return new NpgsqlCommand(sql, (NpgsqlConnection)connection); }
    }
}
