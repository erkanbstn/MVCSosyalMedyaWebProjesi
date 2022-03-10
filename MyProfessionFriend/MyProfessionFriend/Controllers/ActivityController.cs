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
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EfActivityDal());
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetActivityList()
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
            //am.ActivityAddBL(p);
            ActivityValidator activityValidator = new ActivityValidator();
            ValidationResult results = activityValidator.Validate(p);
            if(results.IsValid)
            {
                am.ActivityAdd(p);
                return RedirectToAction("GetActivityList");
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
    }
}