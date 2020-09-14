using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikoMealBox.DataAccess.Interface;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;

namespace NikoMealBox.Controllers
{

    public class CartController : Controller
    {
        private ProductRepository _repository;
     
        
        public CartController()
        {
            _repository = new ProductRepository();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //取得目前購物車頁面
        //public ActionResult GetCart()
        //{
        //    return PartialView("_CartPartial");
        //}

        //以id加入Product至購物車，並回傳購物車頁面
        public ActionResult AddToCart(int id,int quantity)
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.AddProduct(id, quantity);
            return PartialView("_CartPartial");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }

        public ActionResult ClearCart()
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.ClearCart();
            return PartialView("_CartPartial");
        }
    }
}