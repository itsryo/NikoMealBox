using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class ChartViewModels
    {
        public class MonthSalesResult
        {
            public List<string> ThisMonthProductName { get; set; }
            public List<int> ThisMonthQuantity { get; set; }

            public List<string> LastMonthProductName { get; set; }
            public List<int> LastMonthQuantity { get; set; }

        }

        public class YearSalesResult
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }

        }







    }

}