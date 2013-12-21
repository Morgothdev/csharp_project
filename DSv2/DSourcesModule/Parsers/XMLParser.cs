using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSources.Parsers
{
    /**
     * Parser plików XML.
     * Wymaga podania ścieżki do pliku, ról wczytanych kolumn, oraz 
     * kolejności danych, czyli co jest na pierwszym poziomie zagnieżdżenia.
     * Format plików jest ustalony, znacznik główny musi być <data><br>
     * potem na pierwszym poziomie zagnieżdżenia albo lista kolumn:<br>
     * <BLOCKQUOTE>
     * <column><br>
     * &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<column-name>Nazwa</column-name><cell>wartosc-komorki-w-pierwszym-wierszu</cell><cell>wartosc-komorki-w-drugim-wierszu</cell>...<br>
     * </column><br>
     * <column><br>
     * &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<column-name>Nazwa-drugiej-kolumny</column-name><cell>wartosc-komorki-w-pierwszym-wierszu</cell><cell>wartosc-komorki-w-drugim-wierszu</cell>...<br>
     * </column><br>
     * </BLOCKQUOTE>
     * albo lista wierszy, gdzie w pierwszym wierszu są nazwy kolumn, a w kolejnych komórki:<br>
     * <BLOCKQUOTE>
     * <row><br>
     * &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<column-name>Nazwa-pierwszej-kolumny</column-name><column-name>Nazwa-drugiej-kolumny</column-name>...<br>
     * <row><br>
     * <row><br>
     * &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<cell>wartosc-pierwszej-komorki-w-pierwszej-kolumnie</cell><cell>wartosc-pierwszej-komorki-w-drugiej-kolumnie</cell><br>
     * </row><br>
     * <row><br>
     * &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<cell>wartosc-drugiej-komorki-w-pierwszej-kolumnie</cell><cell>wartosc-drugiej-komorki-w-drugiej-kolumnie</cell><br>
     * </row><br>
     * </BLOCKQUOTE>
     */
    class XMLParser : FileParser
    {
        private XName firstNestLabel;
        private XName rootLabel = "data";
        private XName columnNameLabel = "column-name";
        private XName secondNestLabel = "cell";
        internal static string Name = "XML File";

        internal override bool IsFinal { get { return true; } }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = Name;
        }


        internal override InternalParser ClonePrototype()
        {
            InternalParser nev=  new XMLParser();
            nev.Init();
            return nev;
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
        }

        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        internal override List<string> SplitFirstNest(string Data)
        {
            XDocument doc = XDocument.Load(GenerateStreamFromString(Data));

            firstNestLabel = RowsInFirstNest ? "row" : "column";

            XElement[] elements = doc.Element(rootLabel).Elements(firstNestLabel).ToArray();
            List<String> lines = new List<string>();
            foreach (XElement element in elements)
            {
                String line = "";
                foreach (XNode node in element.Nodes())
                {
                    line = string.Concat(line, node.ToString());
                }
                lines.Add(line);
            }
            return lines;
        }

        internal override List<string> SplitSecondNest(string line)
        {
            XDocument doc = XDocument.Load(GenerateStreamFromString(string.Concat("<temp>", line, "</temp>")));
            List<String> elements = new List<string>();
            
            XElement[] nodes = doc.Element("temp").Elements(columnNameLabel).ToArray();
            foreach (XElement node in nodes)
            {
                elements.Add(node.Value);
            }
            nodes = doc.Element("temp").Elements(secondNestLabel).ToArray();
            foreach (XElement node in nodes)
            {
                elements.Add(node.Value);
            }

            return elements;
        }

        internal override string parserName { get { return "XML"; } }

    }
}
