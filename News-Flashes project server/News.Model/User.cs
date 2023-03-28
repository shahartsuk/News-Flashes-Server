using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class User
    {
        public User() {  }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required,Display(Name = "Email")] 
        public string Email { get; set; }

        //public List<UserSubject> Subjects { get; set; }
        
        //public void AddSubject(Subject subject) 
        //{
        //    UserSubject subjectUser = new UserSubject{ subject = subject,user=this };

        //    Subjects.Add(subjectUser); 
        //}
    }
}
