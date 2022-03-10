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

namespace MyProfessionFriend.Controllers
{
    public class PeopleActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityDal());

        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        Context c = new Context();

        public ActionResult MyActivities(string p)
        {
            
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y=>y.PeopleID).FirstOrDefault();
            var activityvalues = am.GetListByPeople(peopleidinfo);
            return View(activityvalues);
        }

        public ActionResult AllActivities()
        {
            var activityvalues = am.GetList();
            return View(activityvalues);
        }

        [HttpGet]
        public ActionResult NewActivity()
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
        public ActionResult NewActivity(Activity p)
        {
            string peoplemailinfo = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == peoplemailinfo).Select(y => y.PeopleID).FirstOrDefault();
            p.ActivityAdded = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.PeopleID = peopleidinfo;
            p.ActivityStatus = true;
            am.ActivityAdd(p);
            return RedirectToAction("MyActivities");
        }


        [HttpGet]
        public ActionResult EditActivity(int id)
        {
            List<SelectListItem> valuepeople = (from x in pm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PeopleName,
                                                    Value = x.PeopleID.ToString()
                                                }).ToList();
            ViewBag.vlp = valuepeople;
            var ActivitValue = am.GetByID(id);
            return View(ActivitValue);
        }

        [HttpPost]
        public ActionResult EditActivity(Activity p)
        {
            am.ActivityUpdate(p);
            return RedirectToAction("MyActivities");
        }

        public ActionResult DeleteActivity(int id)
        {
            var ActivityValue = am.GetByID(id);
            ActivityValue.ActivityStatus = false;
            am.ActivityDelete(ActivityValue);
            return RedirectToAction("MyActivities");
        }
    }
}