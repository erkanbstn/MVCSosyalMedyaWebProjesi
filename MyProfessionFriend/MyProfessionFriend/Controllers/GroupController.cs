using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class GroupController : Controller
    {
        GroupManager grm = new GroupManager(new EfGroupDal());
        public ActionResult Index()
        {
            var groupvalues = grm.GetList();
            return View(groupvalues);
        }

        [HttpGet]
        public ActionResult AddGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGroup(Group p)
        {
            grm.GroupAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult GroupPartial()
        {
            return PartialView();
        }

    }
}