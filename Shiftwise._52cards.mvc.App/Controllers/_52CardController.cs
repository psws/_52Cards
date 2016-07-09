using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shiftwise._52cards.mvc.App.Controllers
{
    public class _52CardController : Controller
    {
        // GET: _52Card
        public ActionResult _52card()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "ShiftWise 52 card Application";

            return View();
        }
    }


}