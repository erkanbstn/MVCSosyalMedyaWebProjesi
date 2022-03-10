using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager(new EfCommentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommentByMedia(int id)
        {
            var CommentValue = cm.GetListByMediaID(id);
            return View(CommentValue);
        }
    }
}