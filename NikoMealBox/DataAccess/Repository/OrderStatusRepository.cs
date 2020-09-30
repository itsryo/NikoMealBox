using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.DataAccess.Repository
{
    public class OrderStatusRepository:GenericRepository<OrderStatus>
    {
        public string GetDescription(int Id)
        {
            return GetAll().Where(x => x.Id == Id).FirstOrDefault().Description;
        }
    }
}