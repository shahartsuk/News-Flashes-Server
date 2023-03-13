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
                //Seed();
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
        public void AddSubject(string Name, string RssLink)
        {
            //create new default RssSubjectsUrl to db 
            RssSubjectsUrl subjectsUrl = new RssSubjectsUrl { Link = $"https://rss.walla.co.il/feed/{RssLink}" };

            //create new default Subject to db
            Subject subject = new Subject { Name = Name };

            subject.AddRssSubjectUrl(subjectsUrl);

            //add the both of them to the db list
            Subjects.Add(subject);
            RssUrls.Add(subjectsUrl);
        }

        public void InitSubjects()
        {
            //https://rss.walla.co.il/feed/
            //http://www.ynet.co.il/Integration/StoryRss + .xml
            //https://www.maariv.co.il/Rss/
            //Walla 22 | Ynet 1854 | Maariv RssFeedsMivzakiChadashot
            AddSubject("מבזקי חדשות", "22");
            //walla 31?type=main | Ynet 550 | Maariv RssFeedsRechev
            AddSubject("רכב", "31?type=main");
            //Walla 2500 | Ynet 598 | Maariv RssFeedsTayarot
            AddSubject("תיירות", "2500");
            //Walla 3?type=main | Ynet 3 | Maariv RssFeedsSport
            AddSubject("ספורט", "3?type=main");
            //Walla 2?type=main | Ynet 6 | Maariv RssFeedsKalkalaBaArez
            AddSubject("כלכלה", "2?type=main");
            //Walla 4?type=main  | Ynet 538 | Maariv RssFeedsTarbot
            AddSubject("תרבות", "4?type=main");
            //Walla 127 | Ynet 5363 | Maariv RssFeedsZarchanot
            AddSubject("צרכנות", "127");
            //Walla 4997 | Ynet 194 | Maariv RssFeedsOpinions
            AddSubject("דעות", "4997");
            //Walla 12864 | Ynet 4111 | Maariv
            AddSubject("קריירה", "12864");
            //Walla 272 | Ynet | Maariv RssFeedsMozika
            AddSubject("מוזיקה", "272");
            //Walla 138?type=main | Ynet 4403 | Maariv jewishism
            AddSubject("יהדות", "138?type=main");
            //Walla 24?type=main | Ynet | Maariv RssFeedsOfna
            AddSubject("אופנה/סטייל", "24?type=main");
            //Walla 139?type=main | Ynet 1208 | Maariv RssFeedsBriotVeYeoz
            AddSubject("בריאות", "139?type=main");
            //Walla 13111 | Ynet | Maariv RssFeedsNadlan
            AddSubject("נדלן", "13111");
            //Walla 9?type=main | Ynet 975 | Maariv RssFeedsOchel
            AddSubject("אוכל", "9?type=main");         
        }

        //DBset lists of models to DB
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RssSubjectsUrl> RssUrls { get; set; }
        public DbSet<UserSubjects> UserSubjects { get; set; }
    }
}
