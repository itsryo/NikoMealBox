using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using WebGrease;

namespace NikoMealBox.Controllers
{
    public class CartAllController : Controller
    {
        private OrderRepository _repository;
        private ApplicationUserManager _userManager;

        public CartAllController()
        {
            _repository = new OrderRepository();
        }
        public CartAllController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
           
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: CartAll
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            OrderViewModels result = new OrderViewModels
            {
                CreateUser = user.Name,
                PickUpAddress = user.Address,
                ContactPhone = user.Mobile,
                Sex = user.Gender,
                ContactMail = user.Email
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult CheckOrderList(OrderViewModels OrderForm)
        {
            if (ModelState.IsValid)
            {
                // 例外處理
            }
            return View(OrderForm);
        }

        public ActionResult CreateOrder(OrderViewModels OrderForm)
        {
            var userId = User.Identity.GetUserId();
            var orderId = _repository.CreateOrder(OrderForm, userId);
            CartRepository.GetCurrentCart().ClearCart();
            ViewData["orderId"] = orderId;
            return View();
        }

        [Authorize]
        public ActionResult OrderCollect() 
        {
            var statusRepo = new OrderStatusRepository();
            var detailRepo = new OrderDetailsRepository();
            var productRepo = new ProductRepository();
            var userId = User.Identity.GetUserId();
            var allUserOrders = _repository.GetAll().Where(x => x.UserRefId.ToString() == userId).AsEnumerable<Orders>();
            var orderCollectList = new List<OrderCollectViewModels>();

            foreach(var order in allUserOrders)
            {
                var details = detailRepo.GetAll().Where(x => x.OrdersId == order.Id);
                var products = new List<OrderDetailExtend>();
                foreach(var detail in details)
                {
                    var product = new OrderDetailExtend()
                    {
                        Quantity = detail.Quantity,
                        Product = productRepo.Get(x => x.Id == detail.ProductsId),
                    };
                    products.Add(product);
                }

                var orderCollect = new OrderCollectViewModels()
                {
                    Order = order,
                    Status = statusRepo.GetDescription(order.OrderStatusRefId),
                    products = products,
                };
                orderCollectList.Add(orderCollect);
            }
            
            return View(orderCollectList);
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = CartRepository.GetCurrentCart();
            currentCart.RemoveProduct(id);
            return PartialView("_CartAllPartial");
        }
    }
}