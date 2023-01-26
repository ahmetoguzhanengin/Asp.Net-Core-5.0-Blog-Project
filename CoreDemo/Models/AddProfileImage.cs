using Microsoft.AspNetCore.Http;
using System;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public String WriterName { get; set; }
        public String WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public String WriterMail { get; set; }
        public String WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
