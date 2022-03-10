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
    public class PeopleMessageController : Controller
    {

        MessageManager msm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        Context c = new Context();

        public ActionResult Inbox()
        {
            string p = (string)Session["PeopleMail"];
            var messagelist = msm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["PeopleMail"];
            var messagelist = msm.GetListSendbox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = msm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = msm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["PeopleMail"];
            
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                msm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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