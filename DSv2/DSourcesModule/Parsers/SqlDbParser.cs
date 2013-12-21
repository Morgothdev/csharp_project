using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Nie funkcjonalny pośredni czytnik dla popularnych sqlowych baz danych.
     */
    abstract class SqlDbParser : DBParser, DbReadable
    {
        internal DbConnection connectionToBase;

        internal override bool IsFinal { get { return false; } }

        internal abstract DbConnectionStringBuilder getDbConnectionStringBuilder();
        internal abstract DbConnection getDbConnection(string connectionString);
        internal abstract DbCommand getDbCommand(string sql, DbConnection connection);

        internal override InternalParser ClonePrototype()
        {
            throw new NotSupportedException();
        }

        internal override void Init()
        {
            base.Init();
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);

            DbConnectionStringBuilder builder = getDbConnectionStringBuilder();
            builder.Add("server", serverIp);
            if (serverPort > 0) builder.Add("port", serverPort);
            builder.Add("database", databaseName);
            builder.Add("user id", userName);
            builder.Add("password", userPassword);
            if (R.DEBUG) Console.WriteLine("used constr: || " + builder.ConnectionString + " ||");
            connectionToBase = getDbConnection(builder.ConnectionString);

            try
            {
                connectionToBase.Open();
                connectionToBase.Close();
            }
            catch (Exception e)
            {
                problems.Add(e.Message);
                if (R.DEBUG) Console.WriteLine("error connecting to base sql");
            }
        }


        internal override void Read()
        {
            DbReader.Read(this);
        }

        public virtual DbConnection GetConnectionToBase()
        {
            return connectionToBase;
        }

        public ParserCore GetParserCore()
        {
            return ParserCore;
        }

        public DbCommand GetDbCommand()
        {
            return getDbCommand(request, connectionToBase);
        }
    }
}
