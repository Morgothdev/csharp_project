using DSources.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;

namespace DSources.Parsers
{
    public interface Parser
    {
        Table Parse();
        bool IsValid { get; }
    }


    public interface ParserAssembly
    {
        ParserInfo Arguments { get; }
        InternalParser ClonePrototype();
        bool IsFinal { get; }
        void Init();
        void ConfigureItSelf(DSources.Logic.ParserConfiguration configuration);
    }

    public interface InternalParser : Parser, ParserAssembly { }


    public class StubParser : InternalParser
    {

        public StubParser()
        {
            Arguments = new ParserInfo();
            Arguments.ParserName = "Stub Parser!";
        }

        public ParserInfo Arguments { get; private set; }


        public bool IsValid { get { return false; } }


        public InternalParser ClonePrototype()
        {
            throw new NotImplementedException();
        }

        public void ConfigureItSelf(ParserConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public Table Parse()
        {
            throw new NotImplementedException();
        }


        public bool IsFinal
        {
            get { return false; }
        }


        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
