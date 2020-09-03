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
        /// 產品項目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 所屬訂單
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 產品單價
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 訂購數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 總折扣
        /// </summary>
        public float Discount { get; set; }
    }
}
