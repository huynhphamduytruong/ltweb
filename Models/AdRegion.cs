using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ltweb.Models
{
    public class AdRegion
    {
        public int Id { get; set; }
        public  Region Region { get; set; }
        public int RegionId { get; set; }
    }
}