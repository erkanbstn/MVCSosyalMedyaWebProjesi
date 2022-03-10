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
    public class PeoplePanelController : Controller
    {

        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        Context c = new Context();


        //[HttpGet]
        public ActionResult MyProfile(string p)
        {
            p = (string)Session["PeopleMail"];
            var peopleidinfo = c.Peoples.Where(x => x.PeopleMail == p).Select(y => y.PeopleID).FirstOrDefault();
            var mediavalues = pm.GetByID(peopleidinfo);
            return View(mediavalues);
        }

        [HttpPost]
        public ActionResult EditPeople(People p)
        {
            PeopleValidator peoplevalidator = new PeopleValidator();

            ValidationResult results = peoplevalidator.Validate(p);
            if (results.IsValid)
            {
                pm.PeopleUpdate(p);
                return RedirectToAction("Index", "Default");
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