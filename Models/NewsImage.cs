using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ltweb.Models
{
    public class NewsImage
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        public  News News { get; set; } 
        [Required]
        public int NewsId { get; set; }

    }
}