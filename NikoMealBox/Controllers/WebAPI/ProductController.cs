using Microsoft.Ajax.Utilities;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NikoMealBox.WebAPI
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class ProductController : ApiController
    {
        private ApplicationDbContext db;
        private ProductRepository _repository;

        public ProductController()
        {
            db = new ApplicationDbContext();
            _repository = new ProductRepository();
        }

        [AcceptVerbs("GET","POST")]
        public IEnumerable<Products> SelectProducts()
        {
            IEnumerable<Products> prcoducts =  _repository.SelectAllProducts();
            //var test = db.Products.Select(x => x).ToList();

            return prcoducts;
            //return Json(CarSalesNumber,JsonRequestBehavior.AllowGet);
        }


        public string GetTime()
        {
            return DateTime.Now.ToString("R");
        }

        public bool AddProduct(Products query)
        {
            using(var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    _repository.Insert(query);
                    return true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            
        }
    }
}
