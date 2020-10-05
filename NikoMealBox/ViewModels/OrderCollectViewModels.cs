using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{

    public class OrderCollectViewModels
    {
        public Orders Order { get; set; }
        public string Status { get; set; }

        public List<OrderDetailExtend> products { get; set; }
    }

    public class OrderDetailExtend
    {
        public int Quantity { get; set; }
        public Products Product { get; set; }
    }
}