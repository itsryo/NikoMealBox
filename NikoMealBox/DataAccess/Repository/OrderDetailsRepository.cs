using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.DataAccess.Repository
{
    public class OrderDetailsRepository:GenericRepository<OrderDetails>
    {
        ProductRepository productRepo = new ProductRepository();

       public IEnumerable<int> GetAllProdId()
       {
            return GetAll().Select(x => x.ProductsId);
       }

        public IEnumerable<string> GetProdName(IEnumerable<int> ids)
        {
            return productRepo.GetAll()
                .Where(x => ids.Contains(x.Id))
                .Select(x => x.ProductName);
        }
        public IEnumerable<string> GetAllProdName()
       
         {
            //return GetProdName(GetAllProdId());
            //return productRepo.GetAll().Where(x => GetAll().Select(p => p.ProductsId).Contains(x.Id)).Select(x => x.ProductName);
            var orderDetails = GetAll();
            var productIdList=new List<int>();
            foreach (var item in orderDetails)
            {
                productIdList.Add(item.ProductsId);
            }
    
            var products = productRepo.GetAll();
            var productNameList = new List<string>();
            foreach (var item in products)
            {
                foreach (var id in productIdList)
                {
                    if (id == item.Id)
                    {
                        productNameList.Add(item.ProductName);
                    }
                }
            }
            return productNameList;
         }




    }


}