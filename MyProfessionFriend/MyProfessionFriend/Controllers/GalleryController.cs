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
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}