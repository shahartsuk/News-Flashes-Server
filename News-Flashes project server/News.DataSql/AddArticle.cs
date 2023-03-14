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
    public class AddArticle
    {
        public void AddArticleToDB(Article article)
        {
            DataLayer.Data.Articles.Add(article);
            DataLayer.Data.SaveChanges();
        }
    }
}
