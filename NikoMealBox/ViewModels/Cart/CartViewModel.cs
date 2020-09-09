using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NikoMealBox.ViewModels.Cart
{
    [Serializable]
    public class CartViewModel : IEnumerable<CartItem>
    {
        private ProductRepository _repository = new ProductRepository();
        private CartRepository _Cartrepository = new CartRepository();

        public CartViewModel cartVM = new CartViewModel();
        //建構值
        public CartViewModel()
        {
            this.cartItems = new List<CartItem>();
        }

        //儲存所有商品
        public List<CartItem> cartItems;

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
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
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
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Amount
        {
            get
            {
                return this.UnitPrice * this.UnitsInStock;
            }
        }
    }
}
