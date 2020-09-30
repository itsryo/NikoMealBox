using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;

namespace NikoMealBox.DataAccess.Repository
{
    public class OrderRepository:GenericRepository<Orders>
    {
        //Context
        //Set<Orders> 存在了

        /// <summary>
        /// 在db插入訂單
        /// </summary>
        /// <param name="OrderForm"></param>
        public int CreateOrder(OrderViewModels OrderForm, string UserId)
        {
            var currentCart = CartRepository.GetCurrentCart();
            List<OrderDetails> OrderDetailList = new List<OrderDetails>();
            var eachOrder = new Orders
            {
                //Id自產
                CreateUser = OrderForm.CreateUser,
                CreateTime = DateTime.Now,
                GetProductDate = OrderForm.GetProductDate,
                // 當初設定不為null，避免datetime2 to datetime問題，先這樣
                FinishDate = new DateTime(9999, 1, 1),
                PickUpCity = OrderForm.PickUpCity,
                PickUpRegion = OrderForm.PickUpRegion,
                PickUpAddress = OrderForm.PickUpAddress,
                ContactPhone = OrderForm.ContactPhone,
                ContactMail = OrderForm.ContactMail,
                Remark = OrderForm.Remark,
                Payment = OrderForm.Payment,
                OrderDetails = OrderDetailList,
                UserRefId = UserId,
                OrderStatusRefId = 4,
                // 訂單狀況
            };
            foreach (var item in currentCart)
            {
                var eachOrderDetail = new OrderDetails()
                {
                    Quantity = item.Count,
                    CreateUser = OrderForm.CreateUser,
                    CreateTime = DateTime.Now,
                    OrdersId = eachOrder.Id,
                    Orders = eachOrder,
                    ProductsId = item.Id,
                    Products = new ProductRepository().SelectAllProd().Where(x => x.Id == item.Id).FirstOrDefault(),
                };
                OrderDetailList.Add(eachOrderDetail);
            }

            Insert(eachOrder);
            SaveChanges();
            return eachOrder.Id;
        }
    }
}