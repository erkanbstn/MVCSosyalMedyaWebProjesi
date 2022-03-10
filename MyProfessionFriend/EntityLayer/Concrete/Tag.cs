using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [StringLength(50)]
        public string TagName { get; set; }

        public int MediaID { get; set; }
        public virtual Media Media { get; set; }
    }
}
