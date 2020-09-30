using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using static NikoMealBox.ViewModels.ChartViewModels;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace NikoMealBox.Controllers.WebAPI
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class ChartController : ApiController
    {

        private ApplicationDbContext db;
        private ProductRepository _repository;
        private OrderDetailsRepository _orderDetailsRepository;



        public ChartController()
        {
            db = new ApplicationDbContext();
            _repository = new ProductRepository();
            _orderDetailsRepository= new OrderDetailsRepository();
        }


        //[AcceptVerbs("GET", "POST")]
        //public ChartViewModels.MonthSalesResult MonthSalesResultChart()
        //{
        //    var result = new ChartViewModels.MonthSalesResult
        //    {
        //        ThisMonthProductName = new List<string>(),
        //        ThisMonthQuantity=new List<int>(),
        //        LastMonthProductName=new List<string>(),
        //        LastMonthQuantity=new List<int>(),
        //    };

        //    foreach (var item in SourceProductName)
        //    {
        //        result.ProductName.Add(item.ProductName);
        //    }
        //    //var list = new List<int>();
        //    //list.Add(1);
        //    //list.Add(2);


        //    return result;
        //}


       //[AcceptVerbs("GET","POST")]
       [HttpGet]
        public List<YearSalesResult> YearSalesResultChart()
        {
           // var viewModel = new ChartViewModels.YearSalesResult();
            //var yearSalesResultChart = new ChartViewModels.YearSalesResult
            //{
            //    ProductName = string,
            //    Quantity = new List<int>()
            //};

            //var yearProductName = _repository.GetAll();
            //foreach (var item in yearProductName)
            //{
            //    yearSalesResultChart.ProductName.Add(item.ProductName);
            //}

            //select p.Id,p.ProductName,Quantity from OrderDetails as od
            //inner join Products as p on p.Id = od.ProductsId

            //var result = _orderDetailsRepository.GetAllProdName();

            
                         //join p in db.Products
                         //on od.ProductsId equals p.Id
                         //select new ChartViewModels
                         //{
                         //    yearSalesResultChart.ProductName = p.ProductName,
                         //    Quantity = od.Quantity
                         //};
            //var yearQuantity = _orderDetailsRepository.GetAll();
        

            ///---------------------------

            var temp = from od in _orderDetailsRepository.GetAll().AsEnumerable()
                       join p in db.Products
                       on od.ProductsId equals p.Id
                       select new ChartViewModels.YearSalesResult
                       {
                          Quantity = od.Quantity,
                          ProductName = p.ProductName
                       };

            return temp.ToList();



            //var temp2 = _orderDetailsRepository.GetAllProdName();
            //foreach (var item in temp2)
            //{
            //    var a = db.OrderDetails.Where(x => x. == item);
            //}
            



            //foreach(var item in yearQuantity)
            //{
            //    yearSalesResultChart.Quantity.Add(item.Quantity);
            //}

            //return yearSalesResultChart;


       
        }


        //[AcceptVerbs("GET", "POST")]
        //public ChartViewModels.ProductsYearResult ChartYear()
        //{
        //    var chartVVMM = new ChartViewModels.ProductsYearResult
        //    {
        //        ProductName = new List<string>(),
        //        UnitStock = new List<int>()
        //    };
        //    var sourceyear = _repository.GetAll();
        //    foreach (var item in sourceyear)
        //    {
        //        chartVVMM.ProductName.Add(item.ProductName);
        //        chartVVMM.UnitStock.Add(item.UnitsInStock);
        //    }
        //    //var list = new List<int>();
        //    //list.Add(1);
        //    //list.Add(2);


        //    return chartVVMM;
        //}
    }
}
