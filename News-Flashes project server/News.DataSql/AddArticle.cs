using News.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class AddArticle
    {
        public void AddArticleToDB(Article article)
        {
            try
            {
                DataLayer.Data.Articles.Add(article);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void SaveArticleList()
        {
            DataLayer.Data.SaveChanges();
        }
    }
}
