﻿using DSources.Parsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Logic
{
    internal class ParsersLoader
    {
        internal ICollection<InternalParser> LoadParsers(ICollection<MyType> TypesCollection)
        {
            IList<InternalParser> loaded = new List<InternalParser>();
            foreach (MyType type in TypesCollection)
            {
                Console.WriteLine(type);
                InternalParser load = (InternalParser)type.DefaultConstructor.Invoke();
                if (load.IsFinal)
                {
                    load.Init();
                    loaded.Add(load);
                }
            }
            Console.WriteLine("loaded " + loaded.Count + " parsers.");
            return loaded;
        }
    }


    internal class MyType
    {
        [DefaultValue(false)]
        public virtual bool IsFinal
        {
            get;
            private set;
        }

        public virtual Type DecoratedType
        {
            get;
            set;
        }

        public MyType(Type TypeToDecore)
        {
            this.DecoratedType = TypeToDecore;
            this.DefaultConstructor = new MyConstructor(TypeToDecore.GetConstructor(Type.EmptyTypes));

            Console.WriteLine("MyType decored " + TypeToDecore);
        }

        public MyType() { }

        public virtual bool IsAbstract
        {
            get { return DecoratedType.IsAbstract; }
        }

        public virtual MyConstructor DefaultConstructor
        {
            get;
            set;
        }
    }

    internal class MyConstructor
    {
        public MyConstructor(ConstructorInfo constructorInfo)
        {
            this.DecoratedConstructor = constructorInfo;
            Console.WriteLine("MyConstructor decorated condtructor: \"" + constructorInfo + "\"");
        }

        public MyConstructor() { }

        public virtual ConstructorInfo DecoratedConstructor
        {
            get;
            set;
        }

        public virtual Object Invoke()
        {
            return DecoratedConstructor.Invoke(Type.EmptyTypes);
        }
    }
}
