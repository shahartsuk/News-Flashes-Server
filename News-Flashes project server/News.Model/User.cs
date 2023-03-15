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
        public User() { /*Subjects = new List<Subject>();*/ }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required,Display(Name = "Email")] 
        public string Email { get; set; }

        //private List<UserSubjects> _Subjects { set; }
        //public List<Subject> Subjects { get; set; }
        
        //public void AddSubject(Subject subject) { Subjects.Add(subject); }
    }
}
