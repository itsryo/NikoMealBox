using NikoMealBox.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class CartAllController : Controller
    {
        // GET: CartAll
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }
    }
}