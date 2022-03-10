using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Media
    {
        [Key]
        public int MediaID { get; set; }
        [StringLength(100)]
        public string MediaSelf { get; set; }
        [StringLength(1000)]
        public string MediaContent { get; set; }

        public DateTime MediaAdded { get; set; }
        public bool MediaStatus { get; set; }
        
        public ICollection<Tag> Tags{ get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int PeopleID { get; set; }
        public virtual People  People { get; set; }
    }
}
