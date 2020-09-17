using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NikoMealBox.Controllers.WebAPI
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class ChartController : ApiController
    {

        private ApplicationDbContext db;
        private ProductRepository _repository;

        public ChartController()
        {
            db = new ApplicationDbContext();
            _repository = new ProductRepository();
        }


        [AcceptVerbs("GET", "POST")]
        public ChartViewModels.ProductsResult Chart()
        {
            var chartVM = new ChartViewModels.ProductsResult
            {
                ProductName = new List<string>(),
                UnitStock = new List<int>()
            };
            var source = _repository.GetAll();
            foreach (var item in source)
            {
                chartVM.ProductName.Add(item.ProductName);
                chartVM.UnitStock.Add(item.UnitsInStock);
            }
            //var list = new List<int>();
            //list.Add(1);
            //list.Add(2);


            return chartVM;
        }
    }
}
