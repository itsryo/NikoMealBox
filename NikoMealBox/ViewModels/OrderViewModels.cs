using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class OrderViewModels
    {
        public class Index
        {
            public List<OrderDetails> OrderDetail { get; set; }
        }
    }
}