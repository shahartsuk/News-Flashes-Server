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
        public List<Article> GetArticleForEachUserDataSQL(string email)
        {
            List<Article> articlesUserList = new List<Article>();

            try
            {
                List<UserSubject> userSubjectsDB = DataLayer.Data.UserSubjectAllIncludes().ToList().FindAll(u => u.user.Email == email);

                if (userSubjectsDB.Count() > 0)
                {
                    foreach (UserSubject userSubject in userSubjectsDB)
                    {
                        List<Article> articlesDB = DataLayer.Data.Articles.ToList().FindAll(a => a.subjectName == userSubject.subject.Name);
                        foreach (Article article in articlesDB)
                        {
                            articlesUserList.Add(article);
                        }
                    }

                }
                return articlesUserList;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

    }
}
