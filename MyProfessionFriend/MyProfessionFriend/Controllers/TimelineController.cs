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

namespace MyProfessionFriend.Controllers
{
    public class TimelineController : Controller
    {
        MediaManager mm = new MediaManager(new EfMediaDal());
        PeopleManager pm = new PeopleManager(new EfPeopleDal()); 
        Context c = new Context();

        public ActionResult Index(string p)
        {
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var mediavalues = mm.GetListByPeople(peopleidinfo);
            return View(mediavalues);

        }

        public ActionResult PeopleProfile(string p)
        {
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var profilevalues = pm.GetByID(peopleidinfo);
            return View(profilevalues);

        }

        public ActionResult PeopleAbout(string p)
        {
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var profilevalues = pm.GetByID(peopleidinfo);
            return View(profilevalues);

        }

        public ActionResult PeopleAlbum(int id = 10)
        {
            var mediavalues = mm.GetListByPeopleID(id);
            return View(mediavalues);
        }

        public ActionResult PeopleFriends(int id = 10)
        {
            var mediavalues = mm.GetListByPeopleID(id);
            return View(mediavalues);
        }

        public PartialViewResult Banner(int id)
        {
            return PartialView(); 
        }

    }

}