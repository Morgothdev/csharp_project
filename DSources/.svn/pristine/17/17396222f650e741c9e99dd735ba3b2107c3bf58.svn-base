using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Logic
{
    internal class ClassesFilter
    {
        internal ICollection<MyType> getAssembliesImplementInterface(Type AnInterface)
        {
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => AnInterface.IsAssignableFrom(p));
            ICollection<MyType> result = new List<MyType>();

            foreach (Type t in types)
            {
               //Console.WriteLine(t);
                if (!t.IsInterface && !t.IsAbstract)
                {
                    result.Add(new MyType(t));
                }
            }
            return result;
        }
    }
}
