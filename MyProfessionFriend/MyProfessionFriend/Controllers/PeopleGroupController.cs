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
    public class PeopleGroupController : Controller
    {
        GroupManager mm = new GroupManager(new EfGroupDal());

        PeopleManager pm = new PeopleManager(new EfPeopleDal());

        public ActionResult MyGroup()
        {
            return View();
        }
    }
}