using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikoMealBox.ViewModels
{
    public class OrderViewModels
    {
        [Required]
        public string CreateUser { get; set; }
        public string Sex { get; set; }
        [Required]
        [RegularExpression(@"^\(?(\d{2})\)?[\s\-]?(\d{4})\-?(\d{4})$")]
        public string ContactPhone { get; set; }
        [EmailAddress]
        [Required]
        public string ContactMail { get; set; }
        [Required]
        public string PickUpCity { get; set; }
        [Required]
        public string PickUpRegion { get; set; }
        [Required]
        public string PickUpAddress { get; set; }
        [MaxLength(140)]
        public string Remark { get; set; }
        [Required]
        public DateTime GetProductDate { get; set; }
    }
}

// 儘量對應 model/order