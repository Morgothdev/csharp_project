using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DSources.Parsers
{
    public class ParserArgumentInfo
    {
        public virtual ArgType Type { get ; private set; }
        public virtual String Name { get; private set; }
        public virtual String Description { get; private set; }
        public virtual String AdditionalData { get; private set; }

        public ParserArgumentInfo(String NameOfArgument, ArgType TypeOfArgument, String DescriptionForUser)
        {
            Type = TypeOfArgument;
            Name = NameOfArgument;
            Description = DescriptionForUser;
            AdditionalData = "";
        }
        public ParserArgumentInfo(String NameOfArgument, ArgType TypeOfArgument, String DescriptionForUser, String AdditionalData)
        {
            Type = TypeOfArgument;
            Name = NameOfArgument;
            Description = DescriptionForUser;
            this.AdditionalData = AdditionalData;            
        }
    }
}
