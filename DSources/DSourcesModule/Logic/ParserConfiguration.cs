﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Logic
{
    [SerializableAttribute]
    public class ParserConfiguration
    {
        private IDictionary<string, string> _properties;

        public interface Builder
        {
            void SetProperty(string Key, string Value);
            void SetParserName(string Name);
            ParserConfiguration Build();
        }

        public static ParserConfiguration.Builder GetBuilder()    {
            return new BuilderImpl();
        }

        internal void SetProperties(IDictionary<String, String> Properties)
        {
            this._properties = Properties;
        }

        internal virtual String GetProperty(string Key)
        {
            String value;
            _properties.TryGetValue(Key, out value);
            return value;
        }

        internal virtual String GetParserName()
        {
            return GetProperty("name");
        }
    }

    class BuilderImpl : ParserConfiguration.Builder
    {
        private IDictionary<String, String> properties = new Dictionary<String, String>();


        public void SetProperty(string Key, string Value)
        {
            if (Key == null || Value == null)
            {
                throw new NullReferenceException();
            }
            properties.Add(Key, Value);
        }

        public ParserConfiguration Build()
        {
            ParserConfiguration configuration = new ParserConfiguration();
            configuration.SetProperties(properties);
            return configuration;
        }


        public void SetParserName(string Name)
        {
            SetProperty("name", Name);
        }
    }
}