using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class ArticleDB
    {
        public List<Article> GetArticleForEachUser(string email)
        {
            List<Article> articlesUserList = new List<Article>();
            User user = DataLayer.Data.UsersAllIncludes().Find(u => u.Email == email);
            
            if(user != null)
            {
                foreach (UserSubject userSubject in user.Subjects)
                {
                    List<Article> articlesDB = DataLayer.Data.Articles.ToList().FindAll(a=>a.subjectName == userSubject.subject.Name );
                    foreach (Article article in articlesDB) 
                    {
                        articlesUserList.Add(article);
                    }
                }
                 
            }
            return articlesUserList;
        }

    }
}
