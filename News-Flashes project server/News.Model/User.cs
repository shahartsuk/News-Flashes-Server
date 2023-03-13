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
        //private User() { Subjects = new List<Subject>(); }
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Email")] 
        public string Email { get; set; }

        //private List<UserSubjects> _Subjects { set; }
        //public List<UserSubjects> Subjects
        //{
        //    get { }
        //    set
        //    {

        //    }
        //}

    }
}
