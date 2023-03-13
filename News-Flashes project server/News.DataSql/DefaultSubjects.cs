using News.Entities;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class DefaultSubjects
    {
        public void InitSubject()
        {
            //https://rss.walla.co.il/feed/
            AddSubject("מבזקי חדשות","22");            //Walla 22
            AddSubject("רכב","31?type=main");          //walla 31?type=main
            AddSubject("תיירות","2500");               //Walla 2500
            AddSubject("ספורט", "3?type=main");        //Walla 3?type=main
            AddSubject("כלכלה", "2?type=main");        //Walla 2?type=main
            AddSubject("תרבות", "4?type=main");        //Walla 4?type=main  
            AddSubject("צרכנות","127");                //Walla 127
            AddSubject("דעות","4997");                 //Walla 4997
            AddSubject("קריירה","12864");              //Walla 12864
            AddSubject("מוזיקה","272");                //Walla 272
            AddSubject("יהדות", "138?type=main");      //Walla 138?type=main
            AddSubject("אופנה/סטייל", "24?type=main"); //Walla 24?type=main
            AddSubject("בריאות", "139?type=main");     //Walla 139?type=main
            AddSubject("נדלן","13111");                //Walla 13111
            AddSubject("אוכל", "9?type=main");         //Walla 9?type=main
        }
        public void AddSubject(string Name,string RssLink)
        {
            //create new default RssSubjectsUrl to db 
            RssSubjectsUrl subjectsUrl = new RssSubjectsUrl { Link = $"https://rss.walla.co.il/feed/{RssLink}"};

            DataLayer.Data.RssUrls.Add(subjectsUrl);
            //create new default Subject to db
            Subject subject = new Subject { Name = Name};

            subject.AddRssSubjectUrl(subjectsUrl);

            //add the both of them to the db list
            DataLayer.Data.Subjects.Add(subject);
        }
    }
}
