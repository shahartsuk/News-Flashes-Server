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
            if (!DataLayer.Data.Users.ToList().Exists(u => u.Email == user.Email))
            {
                try
                {
                    lock (obj)
                    {
                        if (!DataLayer.Data.Users.ToList().Exists(u => u.Email == user.Email))
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
            User user = DataLayer.Data.UsersAllIncludes().Find(u => u.Email == email);
            if (user != null)
            {
                foreach (Subject subject in DataLayer.Data.SubjectsAllIncludes()) 
                {
                    if(subject.Id == int.Parse(subjects[subjectCounter]))
                    {
                        user.AddSubject(subject);
                        if(subjectCounter < subjects.Length-1) 
                        {
                            subjectCounter++;
                        }
                    }
                }
            }
            DataLayer.Data.SaveChanges();
        }
    }
}
