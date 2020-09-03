namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories:BaseEntity
    {
        /// <summary>
        /// 產品種類稱呼
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }


        /// <summary>
        /// 產品種類介紹
        /// </summary>
        [StringLength(60)]
        public string CategoryDescription { get; set; }

        /// <summary>
        /// 是否提供該項種類產品
        /// </summary>
        [Required]
        public bool IsEnable { get; set; }
    }
}
