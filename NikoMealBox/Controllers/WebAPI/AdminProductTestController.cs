using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikoMealBox.Controllers.WebAPI
{
    public class AdminProductTestController : Controller
    {
        private ApplicationDbContext db;
        private ProductRepository _repository;

        public AdminProductTestController()
        {
            db = new ApplicationDbContext();
            _repository = new ProductRepository();
        }
        // GET: AdminProductTest
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductsList()
        {
            List<AdminProductTestViewModel> adminProductTestViewModels = db.Products.Where(x => x.IsDelete == false).Select(x => new AdminProductTestViewModel
            {
                
                Id = x.Id,
                Name = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Materials = x.Materials,
                ImagePath = x.ImagePath

            }).ToList();

            return Json(adminProductTestViewModels, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(int ProductId)
        {
            Products model = _repository.GetAll().Where(x => x.Id == ProductId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(AdminProductTestViewModel model)
        {
            var result = false;
            try
            {
                if(model.Id > 0)
                {
                    Products products = db.Products.SingleOrDefault(x => x.IsDelete == false && x.Id == model.Id);
                    products.Id = model.Id;
                    products.ProductName = model.Name;
                    products.UnitPrice = model.UnitPrice;
                    products.UnitsInStock = model.UnitsInStock;
                    products.CategoryId = model.CategoryId;
                    products.Description = model.Description;
                    products.Materials = model.Materials;
                    products.ImagePath = model.ImagePath;
                    products.CreateUser = model.CreateUser;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Products products = new Products();
                    products.ProductName = model.Name;
                    products.UnitPrice = model.UnitPrice;
                    products.UnitsInStock = model.UnitsInStock;
                    products.CategoryId = model.CategoryId;
                    products.Description = model.Description;
                    products.Materials = model.Materials;
                    products.ImagePath = model.ImagePath;
                    products.CreateUser = model.CreateUser;
                    products.CreateTime = DateTime.Now;
                    products.IsDelete = false;
                    db.Products.Add(products);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProduct(int ProductId)
        {
            bool result = false;
            Products products = db.Products.SingleOrDefault(x => x.IsDelete == false && x.Id == ProductId);
            if(products != null)
            {
                products.IsDelete = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}