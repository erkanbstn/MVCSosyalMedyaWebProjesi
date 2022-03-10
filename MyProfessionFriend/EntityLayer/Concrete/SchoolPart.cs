using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SchoolPart
    {
        [Key]
        public int ScpartID { get; set; }
        [StringLength(50)]
        public string ScpartName { get; set; }
        public bool ScpartStatus { get; set; }

        public ICollection<People> Peoples { get; set; }
        public int SchoolID { get; set; }
        public virtual School School { get; set; }
    }
}
