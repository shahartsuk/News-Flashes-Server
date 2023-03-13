using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class RssSubjectsUrl
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name = "Link")]
        public string Link { get; set; }
        //[Required,Display(Name = "Subject")]
        //public Subject subject { get; set; }
    }
}
