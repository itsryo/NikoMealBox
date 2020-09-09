using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models.DataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NikoMealBox.ViewModels
{
    [Serializable]
    public class CartViewModels:IEnumerable<CartItemViewModels>
    {
        private ProductRepository _repository = new ProductRepository();
        //建構值
        public CartViewModels()
        {
            this.cartItems = new List<CartItemViewModels>();
        }

        //儲存所有商品
        private List<CartItemViewModels> cartItems;

        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach(var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }

        public bool AddProduct(int ProductId)
        {
            var findItem = this.cartItems
                .Where(x => x.Id == ProductId)
                .Select(x => x)
                .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(CartItemViewModels))
            {   //不存在購物車內，則新增一筆

                var product = (from s in _repository.GetAll()
                               where s.Id==ProductId
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
        private bool AddProduct(Products products)
        {
            var cartItem = new ViewModels.CartItemViewModels()
            {
                Id = products.Id,
                Name = products.ProductName,
                UnitPrice = products.UnitPrice,
                UnitsInStock = 1
            };

            this.cartItems.Add(cartItem);
            return true;
        }

        #region IEnumerator

        IEnumerator<CartItemViewModels> IEnumerable<CartItemViewModels>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        #endregion


        public bool RemoveProduct(int ProductId)
        {
            var findItem = this.cartItems
                .Where(s => s.Id == ProductId)
                .Select(s => s)
                .FirstOrDefault();

            if(findItem == default(CartItemViewModels))
            {
                //不存在購物車內，不須做任何動作
            }
            else
            {
                //存在購物車內，將商品移除
                this.cartItems.Remove(findItem);
            }
            return true;
        }

        public bool ClearCart()
        {
            this.cartItems.Clear();
            return true;
        }
    }
}