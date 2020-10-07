using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.Models
{
    public class OrderApiModels
    {
        public class PutOrdersStatusModel
        {
            public int id { get; set; }
            public int statusid { get; set; }
        }
    }
}