using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testpwu
{

    class Program
    {
        static void Main(string[] args)
        {
            string source = "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]";
            string[] stringSeparators = new string[] { "[stop]" };
            string[] result;

            // ...
            result = source.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in result)
            {
                Console.Write("'{0}' ",s);
            }

            Console.Read();
        }
    }
}
