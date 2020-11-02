using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.Services;
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
            return RedirectToAction("PostToECPay");
        }

        //串金流  createOrder
        public ActionResult PostToECPay(OrderViewModels OVM)
        {
            ECPay model = new ECPay();
            //### 廠商應做基本的Molde檢查(自行撰寫)
            #region CreateOrder
            var userId = User.Identity.GetUserId();
            var orderId = _repository.CreateOrder(OVM, userId);
            var currentCart =  CartRepository.GetCurrentCart();
            //ViewData["orderId"] = orderId;
            //取得產品名稱
            var odProd = _repository.Get(x => x.Id == orderId); //orderId
            decimal totalAmount = 0;
            foreach (var prod in currentCart)
            {
                totalAmount += prod.UnitPrice * prod.Count;
            }
            //取產品名稱
            //var prodName = from prodname in OrderDetails
            //               join p in Products on p.Id equals 98
            //               where Id equals 60
            //               select new {p.ProductName}
            var ordId = "Niko" + orderId.ToString();
            model.MerchantTradeNo = ordId;//廠商訂單編號 
            model.MerchantTradeDate = odProd.CreateTime.ToString("yyyy/MM/dd HH:mm:ss");//廠商訂單日期 odProd.CreateTime.ToString()    
            model.TotalAmount = Math.Floor(totalAmount);//交易金額
            model.TradeDesc = "Niko商店ECPay訂單測試";
            model.ItemName = "商品名稱";
            model.ChoosePayment = "ALL";//選擇預設付款方式    
            
            #endregion

            //### 建立Service
            EcPayService _CommonService = new EcPayService();

            //### 組合檢查碼
            string PostURL = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut";
            string MerchantID = "2000132";
            string HashKey = "5294y06JbISpM5x9";
            string HashIV = "v77hoKGq4kWxNNIS";
            SortedDictionary<string, string> PostCollection = new SortedDictionary<string, string>();
            PostCollection.Add("MerchantID", MerchantID);
            PostCollection.Add("MerchantTradeNo", model.MerchantTradeNo); //廠商訂單編號
            PostCollection.Add("MerchantTradeDate", model.MerchantTradeDate);//廠商訂單日期      
            PostCollection.Add("PaymentType", "aio");//固定帶aio
            PostCollection.Add("TotalAmount", model.TotalAmount.ToString());
            PostCollection.Add("TradeDesc", model.TradeDesc);
            PostCollection.Add("ItemName", model.ItemName);
            PostCollection.Add("ReturnURL", "http://localhost:1234");//廠商通知付款結果API
            PostCollection.Add("ChoosePayment", model.ChoosePayment);
            PostCollection.Add("EncryptType", "1");//固定

            //壓碼
            string str = string.Empty;
            string str_pre = string.Empty;
            foreach (var item in PostCollection)
            {
                str += string.Format("&{0}={1}", item.Key, item.Value);
            }

            str_pre += string.Format("HashKey={0}" + str + "&HashIV={1}", HashKey, HashIV);

            string urlEncodeStrPost = HttpUtility.UrlEncode(str_pre);
            string ToLower = urlEncodeStrPost.ToLower();
            string sCheckMacValue = _CommonService.GetSHA256(ToLower);
            PostCollection.Add("CheckMacValue", sCheckMacValue);

            //### Form Post To ECPay
            string ParameterString = string.Join("&", PostCollection.Select(p => p.Key + "=" + p.Value));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<html><body>").AppendLine();
            sb.Append("<form name='ECPayAIO'  id='ECPayAIO' action='" + PostURL + "' method='POST'>").AppendLine();
            foreach (var item in PostCollection)
            {
                sb.Append("<input type='hidden' name='" + item.Key + "' value='" + item.Value + "'>").AppendLine();
            }

            sb.Append("</form>").AppendLine();
            sb.Append("<script> var theForm = document.forms['ECPayAIO'];  if (!theForm) { theForm = document.ECPayAIO; } theForm.submit(); </script>").AppendLine();
            sb.Append("<html><body>").AppendLine();

            TempData["PostForm"] = sb.ToString();


            CartRepository.GetCurrentCart().ClearCart();//訂單建立完移除購物車資料
            return View();
        }



        [Authorize]
        public ActionResult OrderCollect() 
        {
            var statusRepo = new OrderStatusRepository();
            var detailRepo = new OrderDetailsRepository();
            var productRepo = new ProductRepository();
            var userId = User.Identity.GetUserId();
            var allUserOrders = _repository.GetAll().Where(x => x.UserRefId.ToString() == userId && !x.IsDelete).AsEnumerable<Orders>();
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