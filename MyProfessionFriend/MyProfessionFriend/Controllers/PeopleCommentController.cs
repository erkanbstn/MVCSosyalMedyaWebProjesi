using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class PeopleCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public ActionResult MyComment(string p)
        {
            Context c = new Context();

            p = (string)Session["PeopleMail"];
            var Peopleinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var Commentvalues = cm.GetListByPeople(Peopleinfo);
            return View(Commentvalues);
        }
    }
}