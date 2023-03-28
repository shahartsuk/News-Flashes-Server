using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class UserDB
    {
        private readonly object obj = new object();
        public void CreateNewUser(User user)
        {
            if (DataLayer.Data.Users.ToList().Exists(u => u.Email == user.Email) == false)
            {
                try
                {
                    lock (obj)
                    {
                        if (DataLayer.Data.Users.ToList().Exists(u => u.Email == user.Email) == false)
                        {
                            DataLayer.Data.Users.Add(user);

                            DataLayer.Data.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            } 
        }
        public void AddUserSubjectsToDB(string email, string[] subjects)
        {
           int subjectCounter = 0;
            UserSubject userSubject;
            try
            {
                User user = DataLayer.Data.Users.ToList().Find(u => u.Email == email);

                if (user != null)
                {
                    List<UserSubject> userSubjectsDB = DataLayer.Data.UserSubjectAllIncludes().FindAll(u => u.user.Email == email);

                    if (userSubjectsDB.Count() > 0)
                    {
                        foreach (UserSubject userSubjectDB in userSubjectsDB)
                        {
                            DataLayer.Data.UserSubjects.Remove(userSubjectDB);
                        }
                    }

                    foreach (Subject subject in DataLayer.Data.SubjectsAllIncludes())
                    {
                        if (subject.Id == int.Parse(subjects[subjectCounter]))
                        {
                            userSubject = new UserSubject { subject= subject, user = user};

                            DataLayer.Data.UserSubjects.Add(userSubject);

                            if(subjectCounter < subjects.Length-1)
                            {
                                subjectCounter++;
                            }
                        }
                    }
                    DataLayer.Data.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
            



        public List<Article> GetArticlesForeachUserDataSQL(string userEmail)
        {
            List<UserSubject> DBuserSubjectsList = DataLayer.Data.UserSubjectAllIncludes().FindAll(u=>u.user.Email==userEmail);

            List<Article> DBarticlesList = DataLayer.Data.Articles.ToList();

            List<Article> UserArticlesList = new List<Article>();

            List<Article> ArticlesForEachSubList ;



            if (DBuserSubjectsList.Count > 0)
            {
              
                    foreach (UserSubject userSubject in DBuserSubjectsList)
                    {
                    ArticlesForEachSubList= DBarticlesList.FindAll(a => a.subjectName == userSubject.subject.Name);

                        foreach (Article article in ArticlesForEachSubList)
                        {
                            UserArticlesList.Add(article);
                        }
                    }
                
            }



            return UserArticlesList.OrderBy(u => u.Source).OrderBy(u=>u.subjectName).ToList(); 

        }

    }
}
