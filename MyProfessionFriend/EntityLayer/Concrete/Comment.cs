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
        public int CommentID { get; set; }
        [StringLength(1000)]
        public string CommentContent { get; set; }

        public DateTime CommentAdded { get; set; }
        public bool CommentStatus { get; set; }

        public int PeopleID { get; set; }
        public virtual People People { get; set; }

        public int? MediaID { get; set; }
        public virtual Media Media { get; set; }  
    }
}

