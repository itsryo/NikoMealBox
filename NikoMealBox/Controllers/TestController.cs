using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetCart()
        {
            //取得目前購物車
            var cart = DataAccess.Repository.CartRepository.GetCurrentCart();
            cart.AddProduct(1);
            //if(cart.cartItems.Count == 0)
            //{
            //    cart.cartItems.Add(
            //            new ViewModels.CartItemViewModels()
            //            {
            //                Id = 1,
            //                Name = "測試",
            //                UnitsInStock = 1,
            //                UnitPrice = 100m

            //            }
            //        );
            //}
            //else
            //{
            //    cart.cartItems.First().UnitPrice += 1;
            //}
            //回傳目前購物車中的商品總價
            return Content(string.Format("目前購物車總共: {0}元", cart.TotalAmount));
        }

        public ActionResult TestBootStrap()
        {
            return View();
        }
    }
}