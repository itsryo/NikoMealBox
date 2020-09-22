using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikoMealBox.Models.DataTable
{
    public class OrderStatus:BaseEntity
    {
        /// <summary>
        /// 訂單的各階段集合
        /// </summary>
        [StringLength(50)]
        public string Description { get; set; }

        /// <summary>
        /// 一對多外鍵關聯
        /// </summary>
        //public ICollection<Orders> Orders { get; set; }
    }
}