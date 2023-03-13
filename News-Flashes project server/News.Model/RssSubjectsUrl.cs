﻿using System;
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
        [Required, Display(Name = "RssUrlLink")]
        public string Link { get; set; }
    }
}
