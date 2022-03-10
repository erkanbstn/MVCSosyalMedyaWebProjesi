using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfessionFriend.Models
{
    public class ViewModel
    {
        public List<Media> ViewMedia { get; set; }

        public List<Comment> ViewComment { get; set; }
        public Media Media { get; set; }

    }
}