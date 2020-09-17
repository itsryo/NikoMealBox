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
        public List<ChartViewModels.ProductsResult> Chart()
        {
            var chartVM = new List<ChartViewModels.ProductsResult>();
            var source = _repository.GetAll();
            foreach (var item in source)
            {
                chartVM.Add(new ChartViewModels.ProductsResult
                {
                    ProductName = item.ProductName,
                    UnitStock = item.UnitsInStock
                });
            }

            return chartVM;
        }
    }
}
