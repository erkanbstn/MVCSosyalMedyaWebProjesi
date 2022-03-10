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
    public class AdminActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityDal());

        //[Authorize]
        public ActionResult Index()
        {
            var activityvalues = am.GetList();
            return View(activityvalues);
        }
        [HttpGet]
        public ActionResult AddActivity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddActivity(Activity p)
        {
            ActivityValidator activityvalidator = new ActivityValidator();
            ValidationResult results = activityvalidator.Validate(p);
            if(results.IsValid)
            {
                am.ActivityAdd(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteActivity(int id)
        {
            var activityvalue = am.GetByID(id);
            am.ActivityDelete(activityvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditActivity(int id)
        {
            var activityvalue = am.GetByID(id);
            return View(activityvalue);
        }

        [HttpPost]
        public ActionResult EditActivity(Activity p)
        {
            am.ActivityUpdate(p);
            return RedirectToAction("Index");
        }
    }
}