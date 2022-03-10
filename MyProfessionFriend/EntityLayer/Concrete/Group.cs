using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        [StringLength(100)]
        public string GroupName { get; set; }
        [StringLength(1000)]
        public string GroupNote { get; set; }
        public bool GroupStatus { get; set; }

        public ICollection<People> Peoples { get; set; }

    }
}
