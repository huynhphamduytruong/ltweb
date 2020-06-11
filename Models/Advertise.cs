using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ltweb.Models
{
    public class Advertise
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public AdRegion AdRegion { get; set; }
        [Required]  
        public int AdRegionId { get; set; }
            
    }
}