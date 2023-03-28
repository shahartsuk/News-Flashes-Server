using News.Model;
using News.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class MainManager: BaseEntity
    {
        private MainManager() { Init(); }

        private static readonly MainManager _Instance = new MainManager();
        public static MainManager Instance { get { return _Instance; } }

        public UserManager userManager;
        public SubjectManager subjectManager;

        public ArticleManager articleManager;
        public RequestGet requestGet { get; set; }
        public RequestPost requestPost { get; set; }
        public Logger logger { get; set; }
        
        public void Init()
        {
            subjectManager= new SubjectManager();
            userManager = new UserManager();
            articleManager= new ArticleManager();
            requestGet = new RequestGet();
            requestPost = new RequestPost();
            logger = new Logger("File");

        }
    }
}
