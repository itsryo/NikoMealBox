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

        public IEnumerable<OrderDetailExtend> OrderDetailExtends { get; set; }
    }

    /// <summary>
    /// 因為OrderDetail有參考到Product
    /// 需要顯示 Quantity和Product部分屬性
    /// </summary>

    public class OrderDetailExtend
    {
        public int Quantity { get; set; }
        public Products product { get; set; }
    }
}