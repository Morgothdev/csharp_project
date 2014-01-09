using Microsoft.Win32;
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
    internal enum DataSourceType { System, User }

    /**
     * Parser źródeł DSN (Data Source Name).<br>
     * Używa zdefiniowanych w systemie źródeł DSN zarówno systemowych jak i użytkownika<br>
     * Podaje wszystkie odczytane z rejestru systemowego w ParserArgumentInfo.AdditionalData<br>
     * Wymaga podania argumentów do połączenia:
     * <ul>
     * <li>Dsn - nazwa źródła</li>
     * </ul>
     * oraz potrzebnych do pobrania danych:
     * <ul>
     * <li>request do wykonania</li>
     * </ul>
     */
    class DSNParser : AbstractParser, DbReadable
    {

        internal static string REQUEST_KEY = "Request";
        internal static string DSN_NAME_KEY = "DSN:";
        private string request;
        private string dnsName;
        private OdbcConnection connectionToBase;
        internal static string Name = "Data Source Name Parser (DSN)";

        internal override bool IsFinal { get { return true; } }

        internal override InternalParser ClonePrototype()
        {
            InternalParser nev = new DSNParser();
            nev.Init();
            return nev;
        }


        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = Name;
            ParserArgumentInfo dsnName = new ParserArgumentInfo(DSN_NAME_KEY, ArgType.Enum, String.Join(",", getDSNs()));
            ParserArgumentInfo request = new ParserArgumentInfo(REQUEST_KEY, ArgType.Text, "Body of request to execute");

            Arguments.AddArgument(dsnName);
            Arguments.AddArgument(request);
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);

            if (Arguments.ContainsArgument(REQUEST_KEY))
            {
                request = configuration.GetProperty(REQUEST_KEY);
                if (R.DEBUG) Console.WriteLine("request: " + request);
                if (request == null)
                {
                    problems.Add("Absent argument: " + REQUEST_KEY);
                }
            }


            if (Arguments.ContainsArgument(DSN_NAME_KEY))
            {
                dnsName = configuration.GetProperty(DSN_NAME_KEY);
                if (R.DEBUG) Console.WriteLine("dnsName: " + dnsName);
                if (dnsName == null)
                {
                    problems.Add("Absent argument: " + DSN_NAME_KEY);
                }
            }

            if (IsValid)
            {
                OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
                builder.Dsn = dnsName;
                if (R.DEBUG) Console.WriteLine("used constr: || " + builder.ConnectionString + " ||");
                connectionToBase = new OdbcConnection(builder.ConnectionString);

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
        }

        internal override void Read()
        {
            DbReader.Read(this);
        }

        public DbConnection GetConnectionToBase()
        {
            return connectionToBase;
        }

        public ParserCore GetParserCore()
        {
            return ParserCore;
        }

        public DbCommand GetDbCommand()
        {
            return new OdbcCommand(request, connectionToBase);
        }

        private String[] getDSNs()
        {
            List<string> list = new List<string>();
            list.AddRange(GetUserDataSourceNames());
            list.AddRange(GetSystemDataSourceNames());
            return list.ToArray();
        }

        private IEnumerable<string> GetSystemDataSourceNames()
        {
            SortedList<string,DataSourceType> dsnList = new SortedList<string,DataSourceType>();

            // get system dsn's
            RegistryKey reg = (Registry.LocalMachine).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC.INI");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBC Data Sources");
                        if (reg != null)
                        {
                            // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                            foreach (string sName in reg.GetValueNames())
                            {
                                dsnList.Add(sName, DataSourceType.System);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { /* ignore this exception if we couldn't close */ }
                    }
                }
            }

            return dsnList.Keys;
        }

        private IEnumerable<string> GetUserDataSourceNames()
        {
            SortedList<string, DataSourceType> dsnList = new SortedList<string, DataSourceType>();

            // get user dsn's
            RegistryKey reg = (Registry.CurrentUser).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC.INI");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBC Data Sources");
                        if (reg != null)
                        {
                            // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                            foreach (string sName in reg.GetValueNames())
                            {
                                dsnList.Add(sName, DataSourceType.User);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { /* ignore this exception if we couldn't close */ }
                    }
                }
            }

            return dsnList.Keys;
        }
    }
}
