using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Logic
{
    /**
     *Konfiguracja parsera, tworzona przez użytkownika
     *w celu uzyskania obiektu parsera, który będzie mógł odczytać pewne źródło danych
     *Wszystkie dane potrzebne do lokalizacji źródła danych oraz jego formatu
     *muszą być wstawione do konfiguracji.
     *Budowana za pomocą budowniczego ParserConfiguration.Builder
    */
    [SerializableAttribute]
    public class ParserConfiguration
    {
        private IDictionary<string, string> _properties;
        
        /**
         * Budowniczy konfiguracji parsera.
         * Dostępny ze statycznego gettera w ParserConfiguration.
         * Główna metoda to SetProperty, za pomocą której klient ustawia kolejne wartości.
         * Po czym wywołanie Build zwraca zbudowaną konfigurację.
         */
        public interface Builder
        {
            ParserConfiguration.Builder SetProperty(string Key, string Value);
            ParserConfiguration.Builder SetParserName(string Name);
            ParserConfiguration Build();
        }

        public static ParserConfiguration.Builder GetBuilder()    {
            return new BuilderImpl();
        }

        internal IDictionary<string, string> getProperties()
        {
            return _properties;
        }

        internal void SetProperties(IDictionary<String, String> Properties)
        {
            this._properties = Properties;
        }

        internal virtual String GetProperty(string Key)
        {
            String value;
            if (_properties.TryGetValue(Key, out value))
            {
                return value;
            }
            else { return null; }

        }

        internal virtual String GetParserName()
        {
            return GetProperty("name");
        }

        internal ParserConfiguration remove(string Key)
        {
            _properties.Remove(Key);
            return this;
        }

        internal virtual ParserConfiguration ReplaceValue(string Key, string NewValue)
        {
            _properties.Remove(Key);
            _properties.Add(Key, NewValue);
            return this;
        }
    }
    /**
     * Podstawowa implementacja ParserConfiguration.Builder'a
     */
    class BuilderImpl : ParserConfiguration.Builder
    {
        private IDictionary<String, String> properties = new Dictionary<String, String>();

        public BuilderImpl() { if (R.DEBUG) { Console.WriteLine("builder created"); } }

        public ParserConfiguration.Builder SetProperty(string Key, string Value)
        {
            if (Key == null || Value == null)
            {
                throw new NullReferenceException();
            }
            if (R.DEBUG) { Console.WriteLine("setting propety: " + Key+"="+Value); }
            properties.Remove(Key);
            properties.Add(Key, Value);
            return this;
        }

        public ParserConfiguration Build()
        {
            ParserConfiguration configuration = new ParserConfiguration();
            configuration.SetProperties(properties);
            return configuration;
        }


        public ParserConfiguration.Builder SetParserName(string Name)
        {
            if (R.DEBUG) { Console.WriteLine("setting parser name=" + Name);  }
            SetProperty("name", Name);
            return this;
        }
    }
}
