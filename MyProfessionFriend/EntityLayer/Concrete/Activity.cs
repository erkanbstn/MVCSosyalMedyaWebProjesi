using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [StringLength(100)]
        public string ActivityName { get; set; }

        [StringLength(100)]
        public string ActivityContent { get; set; }

        public DateTime ActivityDate { get; set; }

        public DateTime ActivityAdded { get; set; }
        public bool ActivityStatus { get; set; }

        //public ICollection<People> Peoples { get; set; }

        public int? PeopleID { get; set; }
        public virtual People People { get; set; }
    }
}
