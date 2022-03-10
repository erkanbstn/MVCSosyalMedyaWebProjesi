using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        [StringLength(100)]
        public string SchoolName { get; set; }
        [StringLength(100)]
        public string SchoolAdress { get; set; }
        [StringLength(50)]
        public string SchoolTel { get; set; }

        public bool SchoolStatus { get; set; }

        public ICollection<SchoolPart> SchoolParts { get; set; }
    }
}
