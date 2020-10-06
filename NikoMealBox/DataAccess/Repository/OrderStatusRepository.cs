using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.DataAccess.Repository
{
    public class OrderStatusRepository:GenericRepository<OrderStatus>
    {
        public string GetDescription(int statusRefId)
        {
            return Get(x => x.Id == statusRefId).Description;
        }
    }
}