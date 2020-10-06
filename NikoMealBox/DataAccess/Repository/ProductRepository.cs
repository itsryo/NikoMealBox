using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;
using NikoMealBox.ViewModels;

namespace NikoMealBox.DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Products>
    {

        /// <summary>
        /// 前台 取得所有產品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModels.Index> Select()
        {
            var products = GetAll().Where(x=>!x.IsDelete && x.IsEnable).Select(x => new ProductViewModels.Index
            {
                Id = x.Id,
                Name = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Description = x.Description,
                ImagePath = x.ImagePath
            }).AsEnumerable();

            return products;
        }

        /// <summary>
        /// 產品介紹&營養標示
        /// </summary>
        /// <param name="id">產品id</param>
        /// <returns></returns>
        public ProductViewModels.Detail ProductDetail(int? id)
        {
            var prodDeatil = Get(p => p.Id == id);//取回資料庫資料(看繼承就會了解 (DBSet))
            ProductViewModels.Detail prodDetailVM = new ProductViewModels.Detail
            {
                Id = prodDeatil.Id,
                Name = prodDeatil.ProductName,
                UnitPrice = prodDeatil.UnitPrice,
                Description = prodDeatil.Description,
                Materials = prodDeatil.Materials,//商品材料
                Calories = prodDeatil.Calories,//熱量
                Carbohydrate = prodDeatil.Carbohydrate,//碳水化合物
                Protein = prodDeatil.Protein,//蛋白質
                Fat = prodDeatil.Fat,//脂肪
                SaturatedFat = prodDeatil.SaturatedFat,//飽和脂肪
                TransFat = prodDeatil.TransFat,//反式脂肪
                Sugar = prodDeatil.Sugar,//糖
                Sodium = prodDeatil.Sodium,//納
                ImagePath = prodDeatil.ImagePath,//圖片路徑
                IsOvolacto = prodDeatil.IsOvolacto,//蛋奶素
            };
            return prodDetailVM;
        }



   

        /// <summary>
        /// 後台 查詢所有商品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Products> SelectAllProd()
        {
            var product = GetAll().ToList();
            //List<Products> prodLsit = new List<Products>();
            //for(int i =0; i< product.Count; i++)
            //{
            //    prodLsit.Add(new Products()
            //    {
            //        IsDelete.ToString() = product[i].IsDelete.ToString() =="true" ? "是":"否"
            //    });
            //}
            //product.Select(x => x.IsDelete == true ? "是" : "否");
            return product;
        }

        /// <summary>
        /// 後台 取得單一商品(編輯)
        /// </summary>
        /// <returns></returns>
        public Products SelectOneProd(int id)
        {
            var product = Get(p => p.Id == id);
            return product;
        }

        /// <summary>
        /// 後台產品軟刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool softDeleteProduct(int id ,ref Products oneProd)
        {
            try
            {
                //var product = GetAll();
                //var prod = from p in 
                //           where p.Id == id
                //           select p;
                //prod.IsDelete = true;


                var product = Get(x => x.Id == id);
                product.IsDelete = true;//軟刪除
                product.IsEnable = false;
                oneProd = product;
                SaveChanges();//將更新的欄位/資料儲存到DB
                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
            
        }

        /// <summary>
        /// 救回產品
        /// </summary>
        /// <param name="prodobj">產品Id&刪除欄位值</param>
        /// <param name="oneProd">回傳id一整筆資料</param>
        /// <returns></returns>
        public bool BackDelete(dynamic prodobj, ref Products oneProd)
        {
            int id = prodobj.id;
            //string isdel = prodobj.isdelete;
            try
            {
                var prod = Get(x => x.Id == id);
                prod.IsDelete = false;//救回
                prod.IsEnable = true;
                oneProd = prod;
                SaveChanges();//將更新的欄位/資料儲存到DB

                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }


        /// <summary>
        /// 編輯資料
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool EditProduct(Products product,ref Products prod)
        {
            try
            {
                Update(product);
                prod = Get(x => x.Id == product.Id);
                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }

        }

        /// <summary>
        /// 後台新增商品
        /// </summary>
        /// <returns></returns>
        public bool AddProduct(Products product)
        {
            //int ovlacto = product.IsOvolacto = "是" ? 1 : 0; 
            try
            {

                Insert(product);
                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }



        /// <summary>
        /// 搜尋商品
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IEnumerable<Products> Search(string keyWord)
        {
            return GetAll().Where(x => x.ProductName.Contains(keyWord));
        }
    }
}