using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NikoMealBox.DataAccess.Repository
{
    public class CartRepository : GenericRepository<Products>
    {
        public CartViewModel cartVM = new CartViewModel();
        private ProductRepository _repository = new ProductRepository();

        [WebMethod(EnableSession = true)] //啟用Session
        public static CartViewModel GetCurrentCart() //取得目前Session中的Cart物件
        {
            if (System.Web.HttpContext.Current != null) //確認System.Web.HttpContext.Current是否為空
            {
                //如果Session["Cart"]不存在，則新增一個空的Cart物件
                if (System.Web.HttpContext.Current.Session["Cart"] == null)
                {
                    var order = new CartViewModel();
                    System.Web.HttpContext.Current.Session["Cart"] = order;
                }

                //回傳Session["Cart"]
                return (CartViewModel)System.Web.HttpContext.Current.Session["Cart"];
            }
            else
            {
                throw new InvalidOperationException("空的請檢查");
            }

        }

        public bool AddProduct(int ProductId)
        {
            var findItem = cartVM.cartItems
                .Where(x => x.Id == ProductId)
                .Select(x => x)
                .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(CartItem))
            {   //不存在購物車內，則新增一筆

                var product = (from s in _repository.GetAll()
                               where s.Id == ProductId
                               select s).FirstOrDefault();

                if (product != default(Products))
                {
                    this.AddProduct(product);
                }

            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.UnitsInStock += 1;
            }
            return true;
        }

        public bool AddProduct(Products products)
        {
            var cartItem = new ViewModels.Cart.CartItem()
            {
                Id = products.Id,
                Name = products.ProductName,
                UnitPrice = products.UnitPrice,
                UnitsInStock = 1
            };

            cartVM.cartItems.Add(cartItem);
            return true;
        }
    }
}