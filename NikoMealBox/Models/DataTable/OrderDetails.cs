namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails:BaseEntity
    {
        /// <summary>
        /// 訂購數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 總折扣
        /// </summary>
        public decimal Discount { get; set; }


        /// <summary>
        /// 所屬訂單
        /// </summary>
        [ForeignKey("Orders")]
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        /// <summary>
        /// 關聯產品項目
        /// </summary>
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
