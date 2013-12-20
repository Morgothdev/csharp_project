using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DSources.Parsers
{
    /**
     * Podstawowa jednostka danych o argumencie konfiguracji parsera.
     */
    public class ParserArgumentInfo
    {
        /**
         * Zawiera informację jakiego rodzaju powinien być to argument -> przydatne dla GUI
         */
        public virtual ArgType Type { get ; private set; }
        /**
         * Przestawia nazwę argumentu, która powinna być użyta do ustawiania tego argumentu w Logic.ParserConfiguration.Builder
         */
        public virtual String Name { get; private set; }
        /**
         * Zawiera krótką informację opisującą argument
         */
        public virtual String Description { get; private set; }
        /**
         * Zawiera zbiór dostępnych wartości argumentu oddzielonych przecinkiem, jeśli ParserArgumentInfo.Type == ArgType.Enum
         */
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
