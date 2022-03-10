using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MyProfessionFriend.Models;

namespace MyProfessionFriend.Controllers
{
    public class PeopleMediaController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        MediaManager mm = new MediaManager(new EfMediaDal());
        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        Context c = new Context();


        public ActionResult MyMedia(string p)
        {
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var mediavalues = mm.GetListByPeople(peopleidinfo);
            return View(mediavalues);
        }

        [HttpGet]
        public ActionResult NewMedia()
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
        public ActionResult NewMedia(Media p)
        {
            string peoplemailinfo = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == peoplemailinfo).Select(y => y.PeopleID).FirstOrDefault();

            p.MediaAdded = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.PeopleID = peopleidinfo;
            p.MediaStatus = true;
            mm.MediaAdd(p);
            return RedirectToAction("MyMedia");
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
            return RedirectToAction("MyMedia");
        }

        public ActionResult DeleteMedia(int id)
        {
            var MediaValue = mm.GetByID(id);
            MediaValue.MediaStatus = false;
            mm.MediaDelete(MediaValue);
            return RedirectToAction("MyMedia");
        }

        public ActionResult AllMedia(int sayfa=1)
        {

            //ViewModel model = new ViewModel();
            //model.ViewMedia = c.Medias.ToList();
            //model.ViewComment = c.Comments.ToList();
            //return View(model);

            var medias = mm.GetList().ToPagedList(sayfa, 4);
            return View(medias);
        }

        public PartialViewResult Index(int id)
        {
            var commentlist = cm.GetListByMediaID(id);
            //var md = mm.GetByID(id);
            //ViewBag.i = md.MediaID;
            return PartialView(commentlist);
        }

        
        public PartialViewResult Comment(int id)
        {
            var commentlist = cm.GetListByMediaID(id);
            //var md = mm.GetByID(id);
            //ViewBag.i = md.MediaID;
            return PartialView(commentlist);
        }
    }
}