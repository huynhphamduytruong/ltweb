using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ltweb.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public  Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Region Region { get; set; }
        [Required]
        public int RegionId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        
    }
}