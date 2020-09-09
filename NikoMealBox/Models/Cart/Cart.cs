using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models.DataTable;

namespace NikoMealBox.Models.Cart
{
    [Serializable]
    public class Cart : IEnumerable<CartItem>
    {
        private ProductRepository _repository;
        public Cart()
        {
            this.cartItems = new List<CartItem>();
            _repository = new ProductRepository();
        }

        private List<CartItem> cartItems;

        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }
        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        public bool AddProduct(int ProductId)
        {
            var findItem = this.cartItems
                .Where(x => x.Id == ProductId)
                .Select(x => x)
                .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Cart.CartItem))
            {   //不存在購物車內，則新增一筆
                //using (ViewModels.ProductViewModels productViewModels = new ProductViewModels())
                //{
                //Products products = _repository.;
                //var product = (from s in 
                //               where s.Id == ProductId
                //                   select s).FirstOrDefault();
                //    if (product != default(Models.Product))
                //    {
                //        this.AddProduct(product);
                //    }
                //}
            }
            else
            {   //存在購物車內，則將商品數量累加
                //findItem.Quantity += 1;
            }
            return true;
        }
        private bool AddProduct(ProductViewModels product)
        {
            //將Product轉為CartItem
            var cartItem = new Models.Cart.CartItem()
            {
            //    Id = product,
            //    Name = product.Name,
            //    Price = product.Price,
            //    Quantity = 1
            };

            //加入CartItem至購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        #region IEnumerator

        IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        #endregion
    }
}