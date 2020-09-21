namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products : BaseEntity
    {
        /// <summary>
        /// 產品名稱
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ProductName { get; set; }

        /// <summary>
        /// 產品種類
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// 產品單價
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 產品庫存
        /// </summary>
        [Required]
        public int UnitsInStock { get; set; }

        /// <summary>
        /// 產品簡述
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        /// <summary>
        /// 產品材料
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
        /// 產品圖片路徑
        /// </summary>
        [Required]
        [StringLength(256)]
        public string ImagePath { get; set; }

        /// <summary>
        /// 蛋奶素
        /// </summary>
        public bool IsOvolacto { get; set; }

        /// <summary>
        /// 產品/種類是否還有提供
        /// 前端仍舊顯示，但不能下單
        /// </summary>
        public bool IsEnable { get; set; }

        
    }

    
}
