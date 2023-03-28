using News.DataSql;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class ArticleManager: BaseEntity
    {
        public ArticleDB articleDB = new ArticleDB();
        public List<Article> GetArticleForEachUserEntities(string email)
        {
            return articleDB.GetArticleForEachUserDataSQL(email);
        }

        
    }
}
