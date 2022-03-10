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

namespace MyProfessionFriend.Controllers
{
    public class PartialController : Controller
    {

        [ChildActionOnly] // action cannot be requested directly via URL

        public ActionResult Cover()
        {
            string value = "layoutta model"; // assign value to adminName variable
                return Content(value);
            }
    }
}