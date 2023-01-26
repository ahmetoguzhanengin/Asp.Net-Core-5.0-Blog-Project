using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public String CommentUserName { get; set; }
        public String CommentTitle { get; set; }
        public String CommentContent{ get; set; }
        public DateTime CommentDate{ get; set; }
        public int BlogScore { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
