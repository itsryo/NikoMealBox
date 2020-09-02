namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders:BaseEntity
    {
        
        public int CustomID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ArrivedDate { get; set; }

        public bool GetProductMethod { get; set; }

        public int? EmployeeId { get; set; }

        public int? ShippingFee { get; set; }

        public bool IsFinishOrder { get; set; }

        public bool IsPaid { get; set; }

        public bool IsCustomGet { get; set; }
    }
}
