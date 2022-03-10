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
    public class FriendsController : Controller
    {
        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        public ActionResult Index()
        {
            var peoplevalues = pm.GetList();
            return View(peoplevalues);
        }
    }
}