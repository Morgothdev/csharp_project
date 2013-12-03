using DSources.Logic;
using DSources.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources
{
    public class DSourcesFacade
    {
        private static DSourcesFacade _instance;
        private ParsersManager _parsersManager;

        public static DSourcesFacade Instance { 
            get {
                if (_instance == null) { _instance = new DSourcesFacade(); }
                return _instance; 
            } 
        
        }
        private DSourcesFacade()
        {
            _parsersManager = ParsersManager.Instance;
            _parsersManager.Configure();
            Console.WriteLine("DSourcesFacade configured");           
        }

        public Parser GetParser(ParserConfiguration configuration){
            return _parsersManager.GetParser(configuration);
        }

        public ParserInfo[] GetParsersInfo()
        {
            return _parsersManager.GetParsersInfo().ToArray<ParserInfo>();
        }

        public ICollection<ParserInfo> GetParsersInfoAsCollection()
        {
            return _parsersManager.GetParsersInfo();
        }
    }
}
