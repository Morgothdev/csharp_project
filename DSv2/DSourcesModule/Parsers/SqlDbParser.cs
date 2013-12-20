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
    abstract class SqlDbParser : DBParser
    {
        internal DbConnection connectionToBase;

        internal override bool IsFinal { get { return false; } }

        internal abstract DbConnectionStringBuilder getOdbcConnectionStringBuilder();
        internal abstract DbConnection getOdbcConnection(string connectionString);
        internal abstract DbCommand getOdbcCommand(string sql, DbConnection connection);

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

            DbConnectionStringBuilder builder = getOdbcConnectionStringBuilder();
            builder.Add("server", serverIp);
            if (serverPort > 0) builder.Add("port", serverPort);
            builder.Add("database", databaseName);
            builder.Add("user id", userName);
            builder.Add("password", userPassword);
            if (R.DEBUG) Console.WriteLine("used constr: || " + builder.ConnectionString + " ||");
            connectionToBase = getOdbcConnection(builder.ConnectionString);

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
            DbDataReader reader = null;
            try
            {
                connectionToBase.Open();
                DbCommand cmd = getOdbcCommand(request, connectionToBase);
                reader = cmd.ExecuteReader();
                int Columns = reader.FieldCount;
                for (int i = 0; i < Columns; ++i)
                {
                    ParserCore.SetColumnName(reader.GetName(i));
                }
                ParserCore.GotoStart();
                while (reader.Read())
                {
                    for (int i = 0; i < Columns; ++i)
                    {
                        ParserCore.AddCellInRowAndGoToNextColumn(Convert.ToString(reader.GetValue(i)));
                    }
                    ParserCore.GotoNextRow();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connectionToBase != null)
                {
                    connectionToBase.Close();
                }
            }
        }
    }
}
