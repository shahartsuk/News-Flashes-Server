using News.Entities;
using News.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class AddArticles
    {
        public void AddArticleToDB(List<Article> articles)
        {

            foreach (Article article in articles)
            {
                DataLayer.Data.Articles.Add(article);
                Console.WriteLine(DataLayer.Data.Articles.Count());
                Console.WriteLine(article.Title);

            }
           
        }
    }
}
