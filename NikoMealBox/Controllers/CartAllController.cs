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
            MemberCenterViewModel result = new MemberCenterViewModel
            {
                Name = user.Name,
                Address = user.Address,
                Birthday = user.Birthday,
                Mobile = user.Mobile,
                Gender = user.Gender,
                Email = user.Email
                //Height = user.Height,
                //Weight = user.Weight
            };
            return View(result);
            //return View();
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
            var db = new ApplicationDbContext();
            var set = db.Set<Orders>();
            var cart = CartRepository.GetCurrentCart();
            List<OrderDetails> orderDetailList = new List<OrderDetails>();
            var Order2 = new Orders
            {
                //Id自產
                CreateUser = OrderForm.CreateUser,
                CreateTime = DateTime.Now,
                GetProductDate = OrderForm.GetProductDate,
                // 當初設定不為null，避免datetime2 to datetime問題，先這樣
                FinishDate = new DateTime(9999,1,1),
                PickUpCity = OrderForm.PickUpCity,
                PickUpRegion = OrderForm.PickUpRegion,
                PickUpAddress = OrderForm.PickUpAddress,
                ContactPhone = OrderForm.ContactPhone,
                ContactMail = OrderForm.ContactMail,
                Remark = OrderForm.Remark,
                Payment = OrderForm.Payment,
                OrderDetails = orderDetailList,
                //userRefId 等一下再用
            };
            foreach (var item in cart)
            {
                var orderDetail = new OrderDetails()
                {
                    Quantity = item.Count,
                    CreateUser = OrderForm.CreateUser,
                    CreateTime = DateTime.Now,
                    OrdersId = Order2.Id,
                    Orders = Order2,
                    ProductsId = item.Id,
                    Products = new ProductRepository().SelectAllProducts().Where(x =>x.Id == item.Id).FirstOrDefault(),
                };
                orderDetailList.Add(orderDetail);
            }

            set.Add(Order2);
            db.SaveChanges();
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