using NikoMealBox.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class AdminController : Controller
    {
        private ProductRepository _repository;
        public AdminController()
        {

            _repository = new ProductRepository();
        }
        // GET: Addmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin_SelectProducts()
        {
            var products = _repository.Select();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}