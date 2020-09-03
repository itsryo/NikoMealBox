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
        /// ���~����
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ���ݭq��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ���~���
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// �q�ʼƶq
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// �`�馩
        /// </summary>
        public float Discount { get; set; }
    }
}
