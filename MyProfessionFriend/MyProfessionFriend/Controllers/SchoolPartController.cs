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
    public class SchoolPartController : Controller
    {
        // GET: SchoolPart
        SchoolPartManager spm = new SchoolPartManager(new EfSchoolPartDal());
        SchoolManager sm = new SchoolManager(new EfSchoolDal());

        public ActionResult Index()
        {
            var scpartvalues = spm.GetList();
            return View(scpartvalues);
        }

        [HttpGet]
        public ActionResult AddSchoolPart()
        {
            List<SelectListItem> valueschool = (from x in sm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.SchoolName,
                                                    Value = x.SchoolID.ToString()
                                                }).ToList();
            
            ViewBag.vls = valueschool;
            return View();
        }

        [HttpPost]
        public ActionResult AddSchoolPart(SchoolPart p)
        {

            spm.SchoolPartAdd(p);
            return RedirectToAction("Index");
        }

        
        public ActionResult SchoolPartBySchool(int id)
        {
            var schoolpartvalues = spm.GetListBySchoolID(id);
            return View(schoolpartvalues);
        }

        [HttpGet]
        public ActionResult EditSchoolPart(int id)
        {
            List<SelectListItem> valueschool = (from x in sm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.SchoolName,
                                                    Value = x.SchoolID.ToString()
                                                }).ToList();

            ViewBag.vls = valueschool;
            var SchoolPartValue = spm.GetByID(id);
            return View(SchoolPartValue);
        }

        [HttpPost]
        public ActionResult EditSchoolPart(SchoolPart p)
        {
            spm.SchoolPartUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSchoolPart(int id)
        {
            var SchoolPartValue = spm.GetByID(id);
            SchoolPartValue.ScpartStatus=false;
            spm.SchoolPartDelete(SchoolPartValue);
            return RedirectToAction("Index");
        }
    }
}