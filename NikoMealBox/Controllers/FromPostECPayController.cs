using NikoMealBox.Models;
using NikoMealBox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers
{
    public class FromPostECPayController : Controller
    {
        // GET: FromPostECPay
        public ActionResult Index()
        {
            var currentCart = NikoMealBox.DataAccess.Repository.CartRepository.GetCurrentCart();
            /*此部分由廠自行決定，自己成是價購流程，並非制定化*/
            ECPay model = new ECPay();
            model.MerchantTradeNo = DateTime.Now.ToString("yyyyMMddHHmmss"); //廠商訂單編號
            model.MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); //廠商訂單日期           
            model.TotalAmount = 100;//交易金額
            model.TradeDesc = "ECPay訂單測試";
            model.ItemName = "手機 20 元 X2#隨身碟60 元 X1";
            model.ChoosePayment = "Credit";//選擇預設付款方式         

            return View(model);
        }

        [HttpPost]
        public ActionResult PostToECPay(ECPay model)
        {
            // ### 廠商應做基本的Model檢查

            // ### 建立Service
            EcPayService _ecPayService = new EcPayService();

            // ### 組合檢查碼
            string PostURL = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut";
            string MerchantID = "2000132";
            string HashKey = "5294y06JbISpM5x9";
            string HashIV = "v77hoKGq4kWxNNIS";

            SortedDictionary<string, string> PostCollection = new SortedDictionary<string, string>();
            PostCollection.Add("MerchantID", MerchantID);
            PostCollection.Add("MerchantTradeNo", model.MerchantTradeNo);
            PostCollection.Add("MerchantTradeDate", model.MerchantTradeDate);
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
            string sCheckMacValue = _ecPayService.GetSHA256(ToLower);
            PostCollection.Add("CheckMacValue", sCheckMacValue);

            //### Form Post To ECPay
            string ParameterString = string.Join("&", PostCollection.Select(p => p.Key + "=" + p.Value));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<html><body>").AppendLine();
            sb.Append("<form name='ECPayAIO'  id='ECPayAIO' action='" + PostURL + "' method='POST'>").AppendLine();
            foreach (var aa in PostCollection)
            {
                sb.Append("<input type='hidden' name='" + aa.Key + "' value='" + aa.Value + "'>").AppendLine();
            }

            sb.Append("</form>").AppendLine();
            sb.Append("<script> var theForm = document.forms['ECPayAIO'];  if (!theForm) { theForm = document.ECPayAIO; } theForm.submit(); </script>").AppendLine();
            sb.Append("<html><body>").AppendLine();

            TempData["PostForm"] = sb.ToString();
            return View();
        }
    }
}