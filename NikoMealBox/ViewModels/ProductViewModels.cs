using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class ProductViewModels
    {
        public class Index
        {
            public int Id { get; set; }
            public string  Name { get; set; }

            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }

            public string Description { get; set; }
            public string ImagePath { get; set; }
        }
    }

    
}