using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;

namespace NikoMealBox.DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Products>
    {
        
        //ProductViewModels.Index prodViewM = new ProductViewModels.Index();
        //public IEnumerable<Products> Select()
        //{
        //    return _repository.GetAll().Select(x => new ProductViewModels.Index
        //    {
        //        Id = x.Id,
        //        Name = x.ProductName,
        //        UnitPrice = x.UnitPrice,
        //        UnitsInStock = x.UnitsInStock,
        //        Description = x.Description,
        //        ImagePath = x.ImagePath
        //    }).AsEnumerable();
        //}
        public IEnumerable<Products> Search(string keyWord)
        {
            return GetAll().Where(x => x.ProductName.Contains(keyWord));
        }

    }
}