using News.Model;
using News.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class MainManager
    {
        private MainManager() { Init(); }

        private static readonly MainManager _Instance = new MainManager();
        public static MainManager Instance { get { return _Instance; } }
        public RequestGet requestGet { get; set; }
        public RequestPost requestPost { get; set; }
        public DataLayer dataLayer { get; set; }
        public Logger logger { get; set; }
        public WallaRSS Walla { get; set; }

        public void Init()
        {
            requestGet = new RequestGet();
            requestPost = new RequestPost();
            dataLayer = DataLayer.Data;
            logger = new Logger("File");
            Walla = new WallaRSS();
        }
    }
}
