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
        public void CreateNewUser(User user)
        {
            User currUser = DataLayer.Data.Users.ToList().Find(u=>u.Email == user.Email);
            if (currUser == null) 
            {
                DataLayer.Data.Users.Add(user);
                DataLayer.Data.SaveChanges();
            } 
        }
        public void AddUserSubjectsToDB(string email, string[] subjects)
        {
            int subjectCounter = 0;
            User user = DataLayer.Data.Users.ToList().Find(u => u.Email == email);
            if (user != null)
            {
                foreach (Subject subject in DataLayer.Data.Subjects.ToList()) 
                {
                    if(subject.Name == subjects[subjectCounter])
                    {
                        //user.AddSubject(subject);
                        subjectCounter++;
                    }
                }
            }
            DataLayer.Data.SaveChanges();
        }
    }
}
