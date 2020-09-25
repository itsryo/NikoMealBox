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

        public IEnumerable<Products> prcoducts { get; set; }

        /// <summary>
        /// 後台查詢所有商品&單一商品
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET","POST")]
        public IEnumerable<Products> SelectProducts()
        {
            //var test = db.Products.Select(x => x).ToList();
            //IEnumerable<Products> prcoducts =  _repository.SelectAllProducts();

            var products = _repository.SelectAllProd();
            return products;

            //return Json(CarSalesNumber,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查詢單一筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Products SelectOneProduct(int id)
        {
            //var test = db.Products.Select(x => x).ToList();
            //IEnumerable<Products> prcoducts =  _repository.SelectAllProducts();
            
                var Oneproduct = _repository.SelectOneProd(id);
                return Oneproduct;

            //return Json(CarSalesNumber,JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// 後台軟刪除產品 IHttpActionResult
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string DeleteConfirmed(int id)
        {
            bool result = _repository.softDeleteProduct(id);
            if(result == true) //刪除成功 
            {
                return "刪除成功";
                //return RedirectToAction("Product", "SelectProducts");

            }
            else
            {
                return "刪除失敗";
            }

        }


        /// <summary>
        /// 更新/編輯資料
        /// </summary>
        /// <param name="product">單一商品資料</param>
        /// <returns></returns>
        public string Edit(Products product)//int id,
        {
            //product.Id = id;
            bool result = _repository.EditProduct(product);
            if (result == true) //編輯成功 
            {
                return "編輯成功";
                //return RedirectToAction("Product", "SelectProducts");
                //Request.CreateResponse(HttpStatusCode.Created, product);
            }
            else
            {
                return "編輯失敗";


            }

        }

        

        /// <summary>
        /// 後台新增商品
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddProduct(Products prod) //IEnumerable<Products>  IHttpActionResult
        {

            bool result = _repository.AddProduct(prod);
            if (result == true) //新增成功 
            {

                //return SelectProducts();
                //return RedirectToRoute("", "");
                return "新增成功";
                //return RedirectToAction("Product", "SelectProducts");

            }
            else
            {
                //return NotFound();
                return "新增失敗";
            }

            //using (var transaction = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        _repository.Insert(query);
            //        return true;
            //    }
            //    catch(Exception ex)
            //    {
            //        transaction.Rollback();
            //        return false;
            //    }
            //}
            
        }

        public string GetTime()
        {
            return DateTime.Now.ToString("R");
        }
    }
}
