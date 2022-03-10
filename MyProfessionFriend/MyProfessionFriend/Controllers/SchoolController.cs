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
    public class SchoolController : Controller
    {
        // GET: School
        SchoolManager sm = new SchoolManager(new EfSchoolDal());

        public ActionResult Index()
        {
            var schoolvalues = sm.GetList();
            return View(schoolvalues);
        }

        [HttpGet]
        public ActionResult AddSchool()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddSchool(School p)
        {
            
            sm.SchoolAdd(p);
            return RedirectToAction("Index");
        }
    }
}