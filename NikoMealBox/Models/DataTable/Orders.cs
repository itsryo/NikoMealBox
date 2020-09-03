namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    public partial class Orders:BaseEntity
    {   
        /// <summary>
        /// 該筆訂單狀態
        /// </summary>
        public int OrderStatusId { get; set; }

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
        /// 電話分機
        /// </summary>
        [StringLength(8)]
        public string TelephoneExtension { get; set; }

        /// <summary>
        /// 運費
        /// </summary>
        public decimal ShippingFee { get; set; }
    }
}
