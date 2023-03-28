using News.DataSql;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class UserManager: BaseEntity
    {
        public UserDB userDB = new UserDB();
        public void SendUserDetails(User user) 
        {
            userDB.CreateNewUser(user);
        }
        public void AddUserSubject(string email, string[] subjects)
        {
            userDB.AddUserSubjectsToDB(email, subjects);
        }



        public List<Article> GetArticlesForEachUserEntity(string UserEmail)
        {
          
          return userDB.GetArticlesForeachUserDataSQL(UserEmail);
        }
    }
}
