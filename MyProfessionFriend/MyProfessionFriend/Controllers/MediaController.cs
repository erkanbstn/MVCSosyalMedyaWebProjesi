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
    public class MediaController : Controller
    {
        MediaManager mm = new MediaManager(new EfMediaDal());
        PeopleManager pm = new PeopleManager(new EfPeopleDal());

        // GET: Media
        public ActionResult Index()
        {
            var mediavalues = mm.GetList();
            return View(mediavalues);
        }

        public ActionResult MediaReport()
        {
            var mediavalues = mm.GetList();
            return View(mediavalues);
        }

        [HttpGet]
        public ActionResult AddMedia()
        {
            List<SelectListItem> valuepeople = (from x in pm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PeopleName,
                                                    Value = x.PeopleID.ToString()
                                                }).ToList();

            ViewBag.vlp = valuepeople;
            return View();
        }

        [HttpPost]
        public ActionResult AddMedia(Media p)
        {

            mm.MediaAdd(p);
            return RedirectToAction("Index");
        }





        public ActionResult MediaByPeople(int id)
        {
            var mediavalues = mm.GetListByPeopleID(id);
            return View(mediavalues);
        }

        [HttpGet]
        public ActionResult EditMedia(int id)
        {
            List<SelectListItem> valuepeople = (from x in pm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PeopleName,
                                                    Value = x.PeopleID.ToString()
                                                }).ToList();
            ViewBag.vlp = valuepeople;
            var MediaValue = mm.GetByID(id);
            return View(MediaValue);
        }

        [HttpPost]
        public ActionResult EditMedia(Media p)
        {
            mm.MediaUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMedia(int id)
        {
            var MediaValue = mm.GetByID(id);
            MediaValue.MediaStatus = false;
            mm.MediaDelete(MediaValue);
            return RedirectToAction("Index");
        }
    }
}