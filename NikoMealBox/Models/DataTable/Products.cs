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
        /// °Ó«~¦WºÙ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string ProductDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductMaterials { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbohydrate { get; set; }

        public decimal Protein { get; set; }

        public decimal Fat { get; set; }

        public decimal? SaturatedFat { get; set; }

        public decimal? TransFat { get; set; }

        public decimal? Sugar { get; set; }

        public decimal? Sodium { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool IsOvolactin { get; set; }

        public bool IsEnable { get; set; }

    }
}
