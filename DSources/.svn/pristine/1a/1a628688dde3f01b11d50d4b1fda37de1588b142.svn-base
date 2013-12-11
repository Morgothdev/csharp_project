using DSources.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;

namespace DSources.Parsers
{
    /**
     * Interfejs zwracanego z DSourcesFacade parsera.
     */
    public interface Parser
    {
        Table Parse();
        bool IsValid { get; }
    }

    /**
     * Mosto-dekorator do InternalParser udostępniąjący publicznie 
     * jedynie metody z intefejsu Parser.
     */
    public class ParserBridge : Parser
    {
        internal InternalParser parser;

        public Table Parse()
        {
            return parser.Parse();
        }

        public bool IsValid
        {
            get { return parser.IsValid; }
        }
    }

    internal abstract class InternalParser
    {
        internal abstract ParserInfo Arguments { get; set; }
        internal abstract InternalParser ClonePrototype();
        internal virtual bool IsFinal { get; set; }
        internal abstract void Init();
        internal abstract void ConfigureItSelf(DSources.Logic.ParserConfiguration configuration);
        internal abstract Table Parse();
        internal abstract bool IsValid { get; }
    }


    internal class StubParser : InternalParser
    {

        public StubParser()
        {
            Arguments = new ParserInfo();
            Arguments.ParserName = "Stub Parser!";
        }

        internal  override ParserInfo Arguments { get; set; }

        internal override bool   IsValid { get { return false; } }

        internal override InternalParser ClonePrototype()
        {
            throw new NotImplementedException();
        }

        internal override void ConfigureItSelf(ParserConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        internal override Table Parse()
        {
            throw new NotImplementedException();
        }


        internal override  bool IsFinal
        {
            get { return false; }
        }


        internal  override void Init()
        {
            throw new NotImplementedException();
        }
    }
}
