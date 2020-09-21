using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class CartAllController : Controller
    {
        private OrderRepository _repository;

        public CartAllController()
        {
            _repository = new OrderRepository();
        }

        // GET: CartAll
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOrderList(string username,string sex,string phone, string mail,string city,string district,string detailaddress,string remark,string deliverydate,string deliverytime,string payment)
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

        public ActionResult CreateOrder(string city,string region,string address)
        {
            //Orders order = new Orders();
            //order.PickUpCity = city;
            //order.PickUpRegion = region;
            //order.PickUpAddress = address;
            //DbContext dbContext = new ApplicationDbContext();
            //DbSet<Orders> Set = dbContext.Set<Orders>();
            //Set.Add(order);
            //dbContext.SaveChanges();

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