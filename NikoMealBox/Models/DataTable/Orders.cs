namespace NikoMealBox.Models.DataTable
{
    using Microsoft.Ajax.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    public partial class Orders:BaseEntity
    {   
        /// <summary>
        /// 預計取貨時間
        /// </summary>
        public DateTime GetProductDate { get; set; }

        /// <summary>
        /// 貨物送達結單時間
        /// </summary>
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// 取貨地址: 城市
        /// </summary>
        [StringLength(50)]
        public string PickUpCity { get; set; }

        /// <summary>
        /// 取貨地址: 區
        /// </summary>
        [StringLength(50)]
        public string PickUpRegion { get; set; }

        /// <summary>
        /// 取貨地址: 其餘地址
        /// </summary>
        [StringLength(50)]
        public string PickUpAddress { get; set; }

        /// <summary>
        /// 連絡電話
        /// </summary>
        [StringLength(15)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 聯絡信箱
        /// </summary>
        public string ContactMail { get; set; }

        /// <summary>
        /// 訂單備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string Payment { get; set; }

        /// <summary>
        /// 運費
        /// </summary>
        public decimal ShippingFee { get; set; }

        public int OrderStatusRefId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// 關聯到多個訂單詳細產品
        /// </summary>
        public ICollection<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// 訂單是由那個帳號下單
        /// </summary>
        public string UserRefId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
