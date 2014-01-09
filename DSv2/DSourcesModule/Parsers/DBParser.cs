using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /** 
     * Niefunkcjonalny parser dla baz danych.
     */
    abstract class DBParser : AbstractParser
    {
        internal static string SERVER_IP_KEY = "Server IP";
        internal static string SERVER_PORT_KEY = "Server port";
        internal static string DATABASE_NAME_KEY = "Database name";
        internal static string USER_NAME_KEY = "User name";
        internal static string USER_PASSWORD_KEY = "User password";
        internal static string REQUEST_KEY = "Request";

        internal string serverIp;
        internal int serverPort =-1;
        internal string databaseName;
        internal string userName;
        internal string userPassword;
        internal string request;

        internal override void Init()
        {
            base.Init();
            ParserArgumentInfo serverIp = new ParserArgumentInfo(SERVER_IP_KEY, ArgType.Text, "Addres ip of database server");
            ParserArgumentInfo serverPort = new ParserArgumentInfo(SERVER_PORT_KEY, ArgType.Number, "port number of database serwer listen, leave empty for default");
            ParserArgumentInfo databaseName = new ParserArgumentInfo(DATABASE_NAME_KEY, ArgType.Text, "Name of database or collection(in MongoDB)");
            ParserArgumentInfo userName = new ParserArgumentInfo(USER_NAME_KEY, ArgType.Text, "");
            ParserArgumentInfo userPassword = new ParserArgumentInfo(USER_PASSWORD_KEY, ArgType.Text, "");
            ParserArgumentInfo request = new ParserArgumentInfo(REQUEST_KEY, ArgType.Text, "Body of request to execute");

            Arguments.AddArgument(serverIp);
            Arguments.AddArgument(serverPort);
            Arguments.AddArgument(databaseName);
            Arguments.AddArgument(userName);
            Arguments.AddArgument(userPassword);
            Arguments.AddArgument(request);
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
            if (Arguments.ContainsArgument(SERVER_IP_KEY))
            {
                serverIp = configuration.GetProperty(SERVER_IP_KEY);
                if (R.DEBUG) Console.WriteLine("serverIp: " + serverIp);
                if (serverIp == null)
                {
                    problems.Add("Absent argument: " + SERVER_IP_KEY);
                }
            }
            if (Arguments.ContainsArgument(SERVER_PORT_KEY))
            {
                string serverPortString = configuration.GetProperty(SERVER_PORT_KEY);
                if (R.DEBUG) Console.WriteLine("serverPort: " + serverPort);
                if (serverPortString == null)
                {
                    problems.Add("Absent argument: " + SERVER_PORT_KEY);
                }
                else if (serverPortString.Trim().Equals(""))
                {
                    serverPort = -1;
                    if (R.DEBUG) Console.WriteLine("using default port");
                }
                else
                {
                    try
                    {
                        serverPort = Int32.Parse(serverPortString);
                    }
                    catch (Exception)
                    {
                        problems.Add("Cannot parse \"" + serverPort + "\" to number");
                    }
                }

            }
            if (Arguments.ContainsArgument(DATABASE_NAME_KEY))
            {
                databaseName = configuration.GetProperty(DATABASE_NAME_KEY);
                if (R.DEBUG) Console.WriteLine("databaseName: " + databaseName);
                if (databaseName == null)
                {
                    problems.Add("Absent argument: " + DATABASE_NAME_KEY);
                }
            }
            if (Arguments.ContainsArgument(USER_NAME_KEY))
            {
                userName = configuration.GetProperty(USER_NAME_KEY);
                if (R.DEBUG) Console.WriteLine("userName: " + userName);
                if (userName == null)
                {
                    problems.Add("Absent argument: " + USER_NAME_KEY);
                }
            }
            if (Arguments.ContainsArgument(USER_PASSWORD_KEY))
            {
                userPassword = configuration.GetProperty(USER_PASSWORD_KEY);
                if (R.DEBUG) Console.WriteLine("userPassword: " + userPassword);
                if (userPassword == null)
                {
                    problems.Add("Absent argument: " + USER_PASSWORD_KEY);
                }
            }
            if (Arguments.ContainsArgument(REQUEST_KEY))
            {
                request = configuration.GetProperty(REQUEST_KEY);
                if (R.DEBUG) Console.WriteLine("request: " + request);
                if (request == null)
                {
                    problems.Add("Absent argument: " + REQUEST_KEY);
                }
            }
        }
    }
}
