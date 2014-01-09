using DSources.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ICollection<String> Problems { get; }

    }

    /**
     * Mosto-dekorator do InternalParser udostępniąjący publicznie 
     * jedynie metody z intefejsu Parser.<br>
     * Tworzy most do interfejsu InternalParser.
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

        public ICollection<string> Problems
        {
            get { return parser.Problems; }
        }
    }

    /**
     * Korzeń hierarchii dziedziczenia dla wszystkich parserów.
     */
    abstract class InternalParser
    {
        internal abstract ParserInfo Arguments { get; set; }
        internal abstract InternalParser ClonePrototype();
        internal virtual bool IsFinal { get; set; }
        internal abstract void Init();
        internal abstract void ConfigureItSelf(DSources.Logic.ParserConfiguration configuration);
        internal abstract Table Parse();
        protected ISet<String> problems = new HashSet<String>();

        internal virtual ICollection<string> Problems
        {
            get { return new ReadOnlyCollection<string>(problems.ToList()); }
        }

        internal virtual bool IsValid { get { return problems.Count == 0; } }
    }


    /**
     * StubParser, zwracany w sytuacji, gdy potrzebny jest parser, który nie robi nic.
     */
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
            throw new NotSupportedException();
        }

        internal override void ConfigureItSelf(ParserConfiguration configuration)
        {
            throw new NotSupportedException();
        }

        internal override Table Parse()
        {
            throw new NotSupportedException();
        }


        internal override  bool IsFinal
        {
            get { return false; }
        }


        internal  override void Init()
        {
            throw new NotSupportedException();
        }
    }
}
