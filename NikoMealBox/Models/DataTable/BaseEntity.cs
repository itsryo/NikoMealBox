using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikoMealBox.Models.DataTable
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 邏輯刪除
        /// 前端完全不出現
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 資料建立者
        /// </summary>
        [Required]
        public string CreateUser { get; set; }

        /// <summary>
        /// 資料建立時間
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 資料建立者
        /// </summary>
        public string EditUser { get; set; }

        /// <summary>
        /// 資料建立時間
        /// </summary>
        public DateTime? EditTime { get; set; }

    }
}