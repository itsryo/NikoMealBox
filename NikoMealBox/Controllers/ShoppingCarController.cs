using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class ShoppingCarController : Controller
    {
        // GET: ShoppingCar
        public ActionResult Index()
        {
            return View();
        }
    }
}