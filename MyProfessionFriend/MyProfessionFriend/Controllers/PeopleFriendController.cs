using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class PeopleFriendController : Controller
    {
        // GET: PeopleFriend
        public ActionResult MyFriend()
        {
            return View();
        }

        public ActionResult FriendRequests()
        {
            return View();
        }
    }
}