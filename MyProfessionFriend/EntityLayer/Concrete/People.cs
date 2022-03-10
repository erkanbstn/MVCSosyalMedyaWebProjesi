using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class People
    {
        [Key]
        public int PeopleID{ get; set; }

        [Required]
        [StringLength(50)]
        public string PeopleName { get; set; }

        [Required]
        [StringLength(50)]
        public string PeopleSurName { get; set; }

        [StringLength(150)]
        public string PeopleImage { get; set; }

        [StringLength(150)]
        public string TimelineImage { get; set; }
        public DateTime PeopleBirth { get; set; }
        public DateTime PeopleAdded { get; set; }

        [StringLength(150)]
        public string PeopleAbout { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string PeopleMail { get; set; }
       
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string PeoplePass { get; set; }


        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Compare("PeoplePass")]
        public string PeopleRepass { get; set; }

        [StringLength(50)]
        public string PeopleTitle { get; set; }
        public bool PeopleStatus { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Media> Medias { get; set; }

        public ICollection<Activity> Activities { get; set; }

        public ICollection<People> Peoples { get; set; }


        public int? GroupID { get; set; }
        public virtual Group Group { get; set; }

        public int? ScpartID { get; set; }
        public virtual SchoolPart SchoolPart{ get; set; }

        //public int? ActivityID { get; set; }
        //public virtual Activity Acitivity { get; set; }

    }
}
