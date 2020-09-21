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

        [HttpPost]
        public ActionResult CheckOrder(string username,string sex,string phone,string mail,string city,string district,string detailaddress,string remark,string deliverydate,string deliverytime,string payment)
        {
            return RedirectToAction("OrderList", new 
                {   username = username, 
                    sex = sex, 
                    phone = phone,
                    mail = mail,
                    city = city,
                    district = district,
                    detailaddress = detailaddress,
                    remark = remark,
                    deliverydate = deliverydate,
                    deliverytime = deliverytime,
                    payment = payment
                }
            );
        }

        public ActionResult OrderList(string username,string sex,string phone, string mail,string city,string district,string detailaddress,string remark,string deliverydate,string deliverytime,string payment)
        {
            ViewData["username"] = username;
            ViewData["sex"] = sex;
            ViewData["phone"] = phone;
            ViewData["mail"] = mail;
            ViewData["city"] = city;
            ViewData["district"] = district;
            ViewData["detailaddress"] = detailaddress;
            ViewData["remark"] = remark;
            ViewData["deliverydate"] = deliverydate;
            ViewData["deliverytime"] = deliverytime;
            ViewData["payment"] = payment;

            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartAllPartial");
        }
    }
}