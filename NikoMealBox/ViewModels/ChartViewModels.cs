﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class ChartViewModels
    {

        public class ProductsResult
        {
            public List<string> ProductName { get; set; }
            public List<int> UnitStock { get; set; }


        }

    }
   
}