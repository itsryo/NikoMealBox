﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class ProductViewModels
    {
        public class Index
        {
            public int Id { get; set; }
            public string  Name { get; set; }

            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }

            public string Description { get; set; }
            public string ImagePath { get; set; }
        }
        public class Detail
        {
            public int Id { get; set; }
            /// <summary>
            /// 商品名稱
            /// </summary>
            [Required]
            [StringLength(20)]
            public string Name { get; set; }

            /// <summary>
            /// 商品單價
            /// </summary>
            public decimal UnitPrice { get; set; }

            /// <summary>
            /// 商品簡述
            /// </summary>
            [Required]
            [StringLength(50)]
            public string Description { get; set; }

            /// <summary>
            /// 商品材料
            /// </summary>
            [Required]
            [StringLength(50)]
            public string Materials { get; set; }

            /// <summary>
            /// 熱量
            /// </summary>
            public decimal Calories { get; set; }

            /// <summary>
            /// 碳水化合物
            /// </summary>
            public decimal Carbohydrate { get; set; }

            /// <summary>
            /// 蛋白質
            /// </summary>
            public decimal Protein { get; set; }

            /// <summary>
            /// 脂肪
            /// </summary>
            public decimal Fat { get; set; }

            /// <summary>
            /// 飽和脂肪
            /// </summary>
            public decimal SaturatedFat { get; set; }

            /// <summary>
            /// 反式脂肪
            /// </summary>
            public decimal TransFat { get; set; }

            /// <summary>
            /// 糖
            /// </summary>
            public decimal Sugar { get; set; }

            /// <summary>
            /// 鈉
            /// </summary>
            public decimal Sodium { get; set; }

            /// <summary>
            /// 商品圖片路徑
            /// </summary>
            [Required]
            [StringLength(256)]
            public string ImagePath { get; set; }

            /// <summary>
            /// 蛋奶素
            /// </summary>
            public bool IsOvolacto { get; set; }
        }
    }

    
}