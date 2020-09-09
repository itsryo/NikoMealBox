using NikoMealBox.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        //以id加入Product至購物車，並回傳購物車頁面
        public ActionResult AddToCart(int id)
        {
            //CartRepository cartRepository = new CartRepository();
            var currentCart = CartRepository.GetCurrentCart();
           // currentCart.AddProduct(id);
            return PartialView("_CartPartial");
        }
    }
}