using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FriendRequest
    {
        [Key]
        public int RFID { get; set; }
        public int RequestID { get; set; }
        public DateTime RFDate { get; set; }

        public int PeopleID { get; set; }
        public virtual People People { get; set; }

    }
}
