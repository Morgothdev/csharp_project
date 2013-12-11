using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSources.Parsers
{
    public class ParserInfo
    {
        private IDictionary<String,ParserArgumentInfo> arguments = new Dictionary<String,ParserArgumentInfo>();
        
        public virtual String ParserName {get; set;}
        
        public void AddArgument(ParserArgumentInfo NewArgument)
        {
            arguments.Add(NewArgument.Name, NewArgument);
        }

        public virtual ICollection<ParserArgumentInfo> GetNecessaryArgumentsAsCollection()
        {
            return arguments.Values;
        }

        public ParserArgumentInfo[] GetNecessaryArguments()
        {
            return arguments.Values.ToArray<ParserArgumentInfo>();
        }

        internal void RemoveArgument(string ArgumentName)
        {
            arguments.Remove(ArgumentName);
        }
    }
}
