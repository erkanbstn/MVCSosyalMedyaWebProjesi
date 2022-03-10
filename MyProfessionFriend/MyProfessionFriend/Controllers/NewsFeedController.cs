using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MyProfessionFriend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class NewsFeedController : Controller
    {
        MediaManager mm = new MediaManager(new EfMediaDal());
        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        CommentManager cm = new CommentManager(new EfCommentDal());
        Context c = new Context();
        public ActionResult Index()
        {
            var mediavalues = mm.GetList();
            return View(mediavalues);
        }


        public ActionResult test()
        {
            ViewModel vm = new ViewModel();
            vm.ViewMedia = mm.GetList();
            vm.ViewComment = cm.GetList();
            return View(vm);
        }

    }
}
