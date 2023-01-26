using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public String AboutDetails1 { get; set; }
        public String AboutDetails2 { get; set; }
        public String AboutImage1 { get; set; }
        public String AboutImage2 { get; set; }
        public String AboutMapLocation { get; set; }
        public bool AboutStatus{ get; set; }
        
    }
}
