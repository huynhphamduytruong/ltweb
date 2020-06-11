﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ltweb.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public  Category Category { get; set; } 
        public int CategoryId { get; set; }
        
    }
}