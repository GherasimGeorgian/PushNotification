using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PushNotification.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //INSERT INTO Contacts(ContactName,ContactNo,AddedOn)
        //Values('Geo','074444444', GETDATE())
        public JsonResult GetNotificationContacts()
        {
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            NotificationComponents NC = new NotificationComponents();
            var list = NC.GetContacts(notificationRegisterTime);
            // update session here for get only new added contacts (notification)
            Session["LastUpdate"] = DateTime.Now;
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}