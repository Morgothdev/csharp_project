using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Czytnik do NoSQL bazy danych <a href="http://www.mongodb.org/">MongoDB</a><br>
     * Wymaga podania parametrów do połączenia z bazą 
     * <ul><li>adres serwera</li><li>port</li><li>login/hasło użytkownika</li><li>nazwa bazy danych</li></ul><br>
     * oraz nazwy kolekcji i listy pól do wczytania z kolekcji.
     * Należy zwrócić uwagę na nazwy pól, gdyż są case-sensitve.
     */
    class MongoDBParser : DBParser
    {
        MongoClient client;
        internal static string COLLECTION_NAME_KEY = "Collection name";
        internal static string FIELD_NAMES_KEY = "Field names";
        private string collectionName;
        private string[] fieldNames;
        private bool DEBUG;
        public static string Name = "MongoDB Parser";

        internal override bool IsFinal { get { return true; } }

        internal override InternalParser ClonePrototype()
        {
            return new MongoDBParser();
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName=Name ;
            Arguments.RemoveArgument(REQUEST_KEY);
            ParserArgumentInfo collectionName = new ParserArgumentInfo(COLLECTION_NAME_KEY, ArgType.Text, "Name of collection to fetch.");
            ParserArgumentInfo fieldNames = new ParserArgumentInfo(FIELD_NAMES_KEY, ArgType.Text, "Field names to get from colection.");
            Arguments.AddArgument(collectionName);
            Arguments.AddArgument(fieldNames);

        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);

            if (Arguments.ContainsArgument(COLLECTION_NAME_KEY))
            {
                collectionName = configuration.GetProperty(COLLECTION_NAME_KEY);
                Console.WriteLine("collectionName: " + collectionName);
                if (collectionName == null)
                {
                    problems.Add("Absent argument: " + COLLECTION_NAME_KEY);
                }
            }

            if (Arguments.ContainsArgument(FIELD_NAMES_KEY))
            {
                string fieldNamesString = configuration.GetProperty(FIELD_NAMES_KEY);
                Console.WriteLine("fieldNamesString: " + fieldNamesString);
                if (fieldNamesString == null)
                {
                    problems.Add("Absent argument: " + FIELD_NAMES_KEY);
                }
                else
                {
                    fieldNames = fieldNamesString.Split(',').Select<string, string>(s => s.Trim()).ToArray<string>();
                }
            }
            if (serverPort < 0)
            {
                problems.Add("I don't know default port for MongoDB, You must type it");
            }
            if (IsValid)
            {
                //spawdzenie połaczenia do bazy
                StringBuilder sb = new StringBuilder();
                sb.Append("mongodb://").Append(userName).Append(":").Append(userPassword).Append("@")
                    .Append(serverIp).Append(":").Append(serverPort);
                string connectionString = sb.ToString();
                if (R.DEBUG) Console.WriteLine("connection string: " + connectionString);
                client = new MongoClient(connectionString);
                try
                {
                    client.GetServer().GetDatabase(databaseName).GetCollection(collectionName).FindAll().GetEnumerator().MoveNext();
                }
                catch (MongoAuthenticationException e)
                {
                    if (e.GetBaseException() != null)
                    { problems.Add(e.Message + " " + e.GetBaseException().Message); }
                    else { problems.Add(e.Message); }
                }
                catch (MongoException e)
                {
                    problems.Add(e.Message);
                    if (R.DEBUG) Console.WriteLine(e.GetBaseException());
                }
            }
        }

        internal override void Read()
        {
            MongoDatabase dataBase = client.GetServer().GetDatabase(databaseName);
            IEnumerator<BsonDocument> en = dataBase.GetCollection(collectionName).FindAll().GetEnumerator();
            for (int i = 0; i < fieldNames.Length; ++i)
            {
                ParserCore.SetColumnName(fieldNames[i]);
            }
            Dictionary<String, String> tmp = new Dictionary<string, string>();
            while (en.MoveNext())
            {
                IEnumerator<BsonElement> en2 = en.Current.GetEnumerator();
                while (en2.MoveNext())
                {
                    tmp.Add(en2.Current.Name.ToString(), en2.Current.Value.ToString());
                    if (R.DEBUG) Console.WriteLine(en2.Current.Name + " == " + en2.Current.Value);
                }
                for (int i = 0; i < fieldNames.Length; ++i)
                {
                    string value;
                    if (tmp.TryGetValue(fieldNames[i], out value))
                    {
                        ParserCore.AddCellInRowAndGoToNextColumn(value);
                    }
                    else
                    {
                        throw new Exception("One of documents in colection hasn't fied named " + fieldNames[i] + ". Remember that keys in MongoDB are case sensitive");
                    }
                }
                ParserCore.GotoNextRow();
                tmp.Clear();
            }
        }
    }
}
