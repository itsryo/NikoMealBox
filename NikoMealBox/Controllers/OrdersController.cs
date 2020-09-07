using NikoMealBox.ViewModels;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string prodName,decimal price)
        {
            OrderViewModel.Index orderVM = new OrderViewModel.Index();
            orderVM.Name = prodName;
            orderVM.UnitPrice = price;

            return View(orderVM);
        }
    }
}