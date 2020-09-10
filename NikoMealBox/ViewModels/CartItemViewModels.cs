using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    [Serializable]
    public class CartItemViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        public decimal Amount
        {
            get
            {
                return this.UnitPrice * this.Count;
            }
        }
        public string ImagePath { get; set; }
    }
}