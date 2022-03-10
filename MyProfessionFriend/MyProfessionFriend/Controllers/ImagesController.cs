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
    public class ImagesController : Controller
    {
        MediaManager mm = new MediaManager(new EfMediaDal());
        PeopleManager pm = new PeopleManager(new EfPeopleDal());
        public ActionResult Index()
        {
            var medias = mm.GetList();
            return View(medias);
        }
    }
}