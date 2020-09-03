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
    }
}