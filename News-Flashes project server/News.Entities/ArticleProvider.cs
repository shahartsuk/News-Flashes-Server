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
        public Article myArticle =new Article();

        public ArticleProvider(string provider) 
        {
            if (provider.Contains("https://rss.walla.co.il/feed/"))
            {
                myArticle.Source = "Walla";
            } else if (provider.Contains("http://www.ynet.co.il/Integration/StoryRss"))
            {
                myArticle.Source = "Ynet";
            } else if (provider.Contains("https://www.maariv.co.il/Rss/"))
            {
                myArticle.Source = "Maariv";

            }
        }
    }
}
