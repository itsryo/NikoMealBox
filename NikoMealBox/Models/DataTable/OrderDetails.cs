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
        /// �q�ʼƶq
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// �`�馩
        /// </summary>
        public decimal Discount { get; set; }


        /// <summary>
        /// ���ݭq��
        /// </summary>
        [ForeignKey("Orders")]
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        /// <summary>
        /// ���p���~����
        /// </summary>
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
