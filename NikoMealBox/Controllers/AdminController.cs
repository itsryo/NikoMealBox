using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NikoMealBox.Models;
using NikoMealBox.DataAccess.Repository;
using System.Net;

namespace NikoMealBox.Controllers
{
    [Authorize(Users = "Admin@gmail.com")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ProductRepository _repository;
        public AdminController()
        {
        }
        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _repository = new ProductRepository();
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
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
        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in UserManager.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.Name,
                                      Email = user.Email,
                                      Address = user.Address,
                                      Birthday = user.Birthday,
                                      Mobile = user.Mobile,
                                      Gender = user.Gender,
                                      Height = user.Height,
                                      Weight = user.Weight,

                                  }).ToList().Select(p => new Users_in_Role_ViewModel()
                                  {
                                      Name = p.Username,
                                      Address = p.Address,
                                      Birthday = p.Birthday,
                                      Mobile = p.Mobile,
                                      Gender = p.Gender,
                                      Height = p.Height,
                                      Weight = p.Weight,
                                      Email = p.Email
                                  });


            return View(usersWithRoles);
            var products = _repository.SelectAllProducts();
            ViewData["Products"] = products;
            return View();

            //return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}