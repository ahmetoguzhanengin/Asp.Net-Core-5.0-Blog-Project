using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID{ get; set; }
        public String WriterName{ get; set; }
        public String WriterAbout{ get; set; }
        public String WriterImage{ get; set; }
        public String WriterMail{ get; set; }
        public String WriterPassword{ get; set; }
        public bool WriterStatus{ get; set; }
		public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver{ get; set; }
    }
}
