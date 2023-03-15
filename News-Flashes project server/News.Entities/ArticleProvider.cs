using News.Model;
using News.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class ArticleProvider
    {
        public Article myArticle { get; set; }

        public ArticleProvider(string provider) 
        {
            if (provider.Contains("walla"))
            {
                myArticle = new WallaRSS();
            }else if(provider.Contains("ynet"))
            {
                myArticle = new YnetRSS();
            }else if (provider.Contains("maariv"))
            {
                myArticle= new MaarivRSS();
            }
        }
    }
}
