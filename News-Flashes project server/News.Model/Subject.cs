using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class Subject
    {
        public Subject() { RssSubjects = new List<RssSubjectsUrl>(); }
        [Key]
        public int Id { get; set; }
        [Required,Display(Name = "Name")]
        public string Name { get; set; }     
        public List<RssSubjectsUrl> RssSubjects { get; set; }
        public void AddRssSubjectUrl(RssSubjectsUrl rssSubject) 
        { 
            RssSubjects.Add(rssSubject); 
        }
    }
}
