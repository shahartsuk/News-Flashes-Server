using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class UserSubjects
    {
        [Key] 
        public int Id { get; set; }
        Subject subject { get; set; }
        User user { get; set; }
    }
}
