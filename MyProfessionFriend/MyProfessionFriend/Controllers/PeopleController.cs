using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfessionFriend.Controllers
{
    public class PeopleController : Controller
    {
        SchoolPartManager spm = new SchoolPartManager(new EfSchoolPartDal());
        ActivityManager am = new ActivityManager(new EfActivityDal());
        //GroupManager gm = new GroupManager(new EfGroupDal());

        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        PeopleValidator peoplevalidator = new PeopleValidator();
        public ActionResult Index()
        {
            var peoplevalues = pm.GetList();
            return View(peoplevalues);
        }

        public ActionResult GetAllPeople(string p)
        {
            var values = pm.GetList(p); 
            
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult AddPeople()
        {
            List<SelectListItem> valueschoolpart = (from x in spm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ScpartName,
                                                    Value = x.ScpartID.ToString()
                                                }).ToList();

            ViewBag.vlsp = valueschoolpart;

            //List<SelectListItem> valueactivity = (from x in am.GetList()
            //                                        select new SelectListItem
            //                                        {
            //                                            Text = x.ActivityName,
            //                                            Value = x.ActivityID.ToString()
            //                                        }).ToList();

            //ViewBag.vla = valueactivity;

            //List<SelectListItem> valuegroup = (from x in gm.GetList()
            //                                      select new SelectListItem
            //                                      {
            //                                          Text = x.GroupName,
            //                                          Value = x.GroupID.ToString()
            //                                      }).ToList();

            //ViewBag.vlg = valuegroup;
            return View();
        }

        [HttpPost]
        public ActionResult AddPeople(People p)
        {
            
            ValidationResult results = peoplevalidator.Validate(p);
            if(results.IsValid)
            {
                //if (Request.Files.Count > 0)
                //{
                //    var file = Request.Files[0];

                //    string dosyaAdi = Path.GetFileName(file.FileName);
                //    string uzanti = Path.GetExtension(file.FileName);
                //    string adres = "~/img/" + dosyaAdi + uzanti;
                //    Request.Files[0].SaveAs(Server.MapPath(adres));
                //    p.PeopleImage = "/img/" + dosyaAdi + uzanti;
                    
                    
                    
                //}

                    pm.PeopleAdd(p);
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

        [HttpGet]
        public ActionResult EditPeople(int id)
        {
            var peoplevalue = pm.GetByID(id);
            return View(peoplevalue);
        }

        [HttpPost]
        public ActionResult EditPeople(People p)
        {
            ValidationResult results = peoplevalidator.Validate(p);
            if (results.IsValid)
            {
                pm.PeopleUpdate(p);
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

        public ActionResult PeopleBySchoolPart(int id)
        {
            return View();
        }

        //public ActionResult PeopleByGroup(int id)
        //{
        //    return View();
        //}

        //public ActionResult PeopleByActivity(int id)
        //{
        //    return View();
        //}
    }
}