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
    public class TagController : Controller
    {
        // GET: Tag

        TagManager tm = new TagManager(new EfTagDal());

        public ActionResult Index()
        {
            var tagvalues = tm.GetList();
            return View(tagvalues);
        }

        [HttpGet]
        public ActionResult AddTag()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddTag(Tag p)
        {

            tm.TagAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult TagByMedia(int id)
        {
            var tagvalues = tm.GetListByMediaID(id);
            return View(tagvalues);
        }
        [HttpGet]
        public ActionResult EditTag(int id)
        {
            var TagValue = tm.GetByID(id);
            return View(TagValue);
        }
    }
}