using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class AdminProductTestViewModel
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品單價
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 產品庫存
        /// </summary>
        public int UnitsInStock { get; set; }
        /// <summary>
        /// 產品種類
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 商品簡述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 產品材料
        /// </summary>
        public string Materials { get; set; }
        /// <summary>
        /// 商品圖片路徑
        /// </summary>
        public string ImagePath { get; set; }

        public string CreateUser { get; set; }
    }
}