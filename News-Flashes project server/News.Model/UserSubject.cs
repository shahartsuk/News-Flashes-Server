using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class UserSubject
    {
        public UserSubject() { }
        [Key] 
        public int Id { get; set; }
        [Display(Name = "UserID")]
        public User user { get; set; }
        [Display(Name = "SubjectID")]
        public Subject subject { get; set; }
    }
}
