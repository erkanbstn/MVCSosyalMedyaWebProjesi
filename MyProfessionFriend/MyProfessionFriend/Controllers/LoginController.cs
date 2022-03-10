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
using System.Web.Security;

namespace MyProfessionFriend.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        PeopleManager pm = new PeopleManager(new EfPeopleDal());

        PeopleLoginManager plm = new PeopleLoginManager(new EfPeopleDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if(adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminActivity");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }

        [HttpGet]
        public ActionResult PeopleLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PeopleLogin(People p)
        {
            //Context c = new Context();
            //var peopleuserinfo = c.Peoples.FirstOrDefault(x => x.PeopleMail == p.PeopleMail && x.PeoplePass == p.PeoplePass);
            var peopleuserinfo = plm.GetPeople(p.PeopleMail, p.PeoplePass);
            if (peopleuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(peopleuserinfo.PeopleMail, false);
                Session["PeopleMail"] = peopleuserinfo.PeopleMail;
                return RedirectToAction("Index", "NewsFeed");
            }
            else
            {
                return RedirectToAction("PeopleLogin", "Login");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(People p)
        {
            //am.ActivityAddBL(p);
            PeopleValidator peopleValidator = new PeopleValidator();
            ValidationResult results = peopleValidator.Validate(p);
            if (results.IsValid)
            {
                pm.PeopleAdd(p);
                return RedirectToAction("PeopleLogin", "Login");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("PeopleLogin","Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Register", "Login");
        }

    }
}