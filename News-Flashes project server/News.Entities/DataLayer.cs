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
        //public static string connectionString = MainManager.Instance.configDB.GetConfigConnectionString();
        //"Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=News-Flashes-Project;Data Source=SHAHAR\\SQLEXPRESS01";
        //MainManager.Instance.configDB.GetConfigConnectionString();
<<<<<<< Updated upstream
        private DataLayer() : base(connectionString)
=======
        private DataLayer() : base("Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=News-Flashes-Project;Data Source=localhost\\SQLEXPRESS")
>>>>>>> Stashed changes
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            //if the first default model list is null use seed and start the DB
            if (Subjects.Count() == 0) Seed();
        }
        public static DataLayer Data { get { if (_Data == null) { _Data = new DataLayer(); } return _Data; } }

        //first entrace to DB
        private void Seed()
        {
            //default subjects
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

            SaveChanges();
        }
        public void AddSubject(string Name)
        {
            Subject subject = new Subject { Name = Name };
            Subjects.Add(subject);
        }

        //DBset lists of models to DB
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
