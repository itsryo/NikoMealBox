using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NikoMealBox.Models.DataTable;

namespace NikoMealBox.DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Products>
    {
       public IEnumerable<Products> Search(string keyWord)
        {
            return GetAll().Where(x => x.ProductName.Contains(keyWord));
        }
       
    }
}