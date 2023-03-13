using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using News.Model;

namespace News.Entities
{
    public class DataLayer : DbContext
    {
        private static DataLayer _Data;
        public static string connectionString = ConfigDB.GetConfigConnectionString();
       
        private DataLayer() : base(connectionString)
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
                //if the first default model list is null use seed and start the DB
                if (Subjects.Count() == 0) Seed();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataLayer Data { get { if (_Data == null) { _Data = new DataLayer(); } return _Data; } }

        //first entrace to DB
        private void Seed()
        {
            //default subjects
            InitSubjects();

            SaveChanges();
        }
        public void AddSubject(string Name)
        {
            Subject subject = new Subject { Name = Name };
            Subjects.Add(subject);
        }
         
        public void InitSubjects()
        {
            AddSubject("מבזקי חדשות");
            AddSubject("רכב");
            AddSubject("תיירות");
            AddSubject("ספורט");
            AddSubject("כלכלה");
            AddSubject("תרבות");
            AddSubject("צרכנות");
            AddSubject("דעות");
            AddSubject("קריירה");
            AddSubject("מוזיקה");
            AddSubject("יהדות");
            AddSubject("אופנה/סטייל");
            AddSubject("בריאות");
            AddSubject("נדלן");
            AddSubject("אוכל");
        }

        //DBset lists of models to DB
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
