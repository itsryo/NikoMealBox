using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NikoMealBox.DataAccess.Repository
{
    public class CartRepository
    {
        [WebMethod(EnableSession = true)] //啟用Session
        public static ViewModels.CartViewModels GetCurrentCart() //取得目前Session中的Cart物件
        {
            if (System.Web.HttpContext.Current != null) //確認System.Web.HttpContext.Current是否為空
            {
                //如果Session["Cart"]不存在，則新增一個空的Cart物件
                if (System.Web.HttpContext.Current.Session["Cart"] == null)
                {
                    var order = new CartViewModels();
                    System.Web.HttpContext.Current.Session["Cart"] = order;
                }

                //回傳Session["Cart"]
                return (CartViewModels)System.Web.HttpContext.Current.Session["Cart"];
            }
            else
            {
                throw new InvalidOperationException("空的請檢查");
            }
        }
    }
}