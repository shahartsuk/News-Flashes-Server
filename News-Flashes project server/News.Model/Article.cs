using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public abstract class Article
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "LinkImage")]
        public string Title { get; set; }

        [Required, Display(Name = "Description")]
        public string LinkImage { get; set; }

        [Required, Display(Name = "Title")]
        public string Description { get; set; }

        [Required, Display(Name = "WebLink")]
        public string WebLink { get; set; }

        [Required, Display(Name = "Subject")]
        public Subject subject { get; set; }
    }
}
