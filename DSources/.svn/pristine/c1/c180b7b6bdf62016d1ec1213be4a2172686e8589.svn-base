using DSources.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSources.Logic
{
    internal class ParsersManager
    {
        private static ParsersManager _instance;
        private List<ParserInfo> parsersInfo = new List<ParserInfo>();
        private IDictionary<String, InternalParser> parsers = new Dictionary<String, InternalParser>();

        private ParsersManager()
        {
            IsConfigured = false;
        }

        internal void Configure()
        {
            ICollection<MyType> typesImplementing = new ClassesFilter().getAssembliesImplementInterface(typeof(Parser));
            ICollection<InternalParser> loadedParsers = new ParsersLoader().LoadParsers(typesImplementing);
            AcceptParsersCollection(loadedParsers);
            IsConfigured = true;
        }

        internal static ParsersManager Instance { 
            get {
                if (_instance == null) { _instance = new ParsersManager(); }
                return _instance; 
            } 
        }
        internal bool IsConfigured { get; set; }

        internal void AcceptParsersCollection(ICollection<InternalParser> loadedParsers)
        {
            parsersInfo = new List<ParserInfo>();
            foreach (InternalParser parser in loadedParsers)
            {
                parsersInfo.Add(parser.Arguments);
                parsers.Add(parser.Arguments.ParserName, parser);
            }
        }

        internal ICollection<ParserInfo> GetParsersInfo()
        {
            return parsersInfo;
        }

        internal InternalParser GetParser(ParserConfiguration configuration)
        {
            if(configuration==null){
                return new StubParser();
            }


            InternalParser result;
            if (configuration.GetParserName() == null)
            {
                return new StubParser();
            }

            parsers.TryGetValue(configuration.GetParserName(), out result);
            if (result == null)
            {
                return new StubParser();
            }
            
            result = result.ClonePrototype();
            result.ConfigureItSelf(configuration);
            return result;
        }

        internal static ParsersManager Reset()
        {
            _instance = new ParsersManager();
            return Instance;
        }
    }
}
