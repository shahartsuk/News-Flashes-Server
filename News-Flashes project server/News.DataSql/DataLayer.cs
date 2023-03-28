using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using News.Model;
using News.Dal;
using System.Security.Cryptography.X509Certificates;

namespace News.DataSql
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
                if (Subjects.Count() == 0)
                { Seed(); }
              
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
        
        public void InitSubjects()
        {
            //https://rss.walla.co.il/feed/
            //http://www.ynet.co.il/Integration/StoryRss + .xml
            //https://www.maariv.co.il/Rss/
            //Walla 22 | Ynet 1854 | Maariv RssFeedsMivzakiChadashot
            AddSubject_UrlSubject("מבזקי חדשות", "22", "1854", "RssFeedsMivzakiChadashot");
            //walla 31?type=main | Ynet 550 | Maariv RssFeedsRechev
            AddSubject_UrlSubject("רכב", "31?type=main", "550", "RssFeedsRechev");
            //Walla 2500 | Ynet 598 | Maariv RssFeedsTayarot
            AddSubject_UrlSubject("תיירות", "2500", "598", "RssFeedsTayarot");
            //Walla 3?type=main | Ynet 3 | Maariv RssFeedsSport
            AddSubject_UrlSubject("ספורט", "3?type=main","3", "RssFeedsSport");
            //Walla 2?type=main | Ynet 6 | Maariv RssFeedsKalkalaBaArez
            AddSubject_UrlSubject("כלכלה", "2?type=main","6", "RssFeedsKalkalaBaArez");
            //Walla 4?type=main  | Ynet 538 | Maariv RssFeedsTarbot
            AddSubject_UrlSubject("תרבות", "4?type=main","538", "RssFeedsTarbot");
            //Walla 127 | Ynet 5363 | Maariv RssFeedsZarchanot
            AddSubject_UrlSubject("צרכנות", "127", "5363", "RssFeedsZarchanot");
            //Walla 4997 | Ynet 194 | Maariv RssFeedsOpinions
            AddSubject_UrlSubject("דעות", "4997","194", "RssFeedsOpinions");
            //Walla 12864 | Ynet 4111 | Maariv
            AddSubject_UrlSubject("קריירה", "12864","4111","");
            //Walla 272 | Ynet | Maariv RssFeedsMozika
            AddSubject_UrlSubject("מוזיקה", "272","", "RssFeedsMozika");
            //Walla 138?type=main | Ynet 4403 | Maariv jewishism
            AddSubject_UrlSubject("יהדות", "138?type=main", "4403", "jewishism");
            //Walla 24?type=main | Ynet | Maariv RssFeedsOfna
            AddSubject_UrlSubject("אופנה/סטייל", "24?type=main","", "RssFeedsOfna");
            //Walla 139?type=main | Ynet 1208 | Maariv RssFeedsBriotVeYeoz
            AddSubject_UrlSubject("בריאות", "139?type=main","1208", "RssFeedsBriotVeYeoz");
            //Walla 13111 | Ynet | Maariv RssFeedsNadlan
            AddSubject_UrlSubject("נדלן", "13111","", "RssFeedsNadlan");
            //Walla 9?type=main | Ynet 975 | Maariv RssFeedsOchel
            AddSubject_UrlSubject("אוכל", "9?type=main","975", "RssFeedsOchel");         
        }
        public void AddSubject_UrlSubject(string Name, string WallaUrl, string YnetUrl, string MaarivUrl)
        {
            string[] strings = { WallaUrl, YnetUrl, MaarivUrl };
            RssSubjectsUrl subjectsUrl=null;
            Subject subject = new Subject { Name = Name };

            for (int i = 0; i < strings.Length; i++)
            {
                //check if there is link for the rss and orginize them by webs
                //create the default subject url item and add him to the subject item
                if (i == 0)
                {
                    subjectsUrl =new RssSubjectsUrl { Link = $"https://rss.walla.co.il/feed/{WallaUrl}" };
                    subject.AddRssSubjectUrl(subjectsUrl);
                }
                else if (YnetUrl != "" && i == 1)
                {
                    subjectsUrl = new RssSubjectsUrl { Link = $"http://www.ynet.co.il/Integration/StoryRss{YnetUrl}.xml" };
                    subject.AddRssSubjectUrl(subjectsUrl);
                }
                else if(MaarivUrl != "" && i == 2)
                {
                    subjectsUrl = new RssSubjectsUrl { Link = $"https://www.maariv.co.il/Rss/{MaarivUrl}" }; 
                    subject.AddRssSubjectUrl(subjectsUrl);
                }
                RssUrls.Add(subjectsUrl);
            }

            //add the both of them to the db list
            Subjects.Add(subject);

        }

       public List<Subject> SubjectsAllIncludes()
        {
            List<Subject> subjects = Subjects.Include(s=>s.RssSubjects).ToList();
            return subjects;
        }

        public List<UserSubject> UserSubjectAllIncludes()
        {
            List<UserSubject> userSubjects = UserSubjects.Include(u=>u.user).Include(u=>u.subject).ToList();
            return userSubjects;
        }

        //DBset lists of models to DB
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RssSubjectsUrl> RssUrls { get; set; }
        public DbSet<UserSubject> UserSubjects { get; set; } 
    }
}
