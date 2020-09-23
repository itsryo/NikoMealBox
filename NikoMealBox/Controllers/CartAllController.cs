using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
            ViewData["OrderForm"] = OrderForm;
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