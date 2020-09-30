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
        /// �w�p���f�ɶ�
        /// </summary>
        public DateTime GetProductDate { get; set; }

        /// <summary>
        /// �f���e�F����ɶ�
        /// </summary>
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// ���f�a�}: ����
        /// </summary>
        [StringLength(50)]
        public string PickUpCity { get; set; }

        /// <summary>
        /// ���f�a�}: ��
        /// </summary>
        [StringLength(50)]
        public string PickUpRegion { get; set; }

        /// <summary>
        /// ���f�a�}: ��l�a�}
        /// </summary>
        [StringLength(50)]
        public string PickUpAddress { get; set; }

        /// <summary>
        /// �s���q��
        /// </summary>
        [StringLength(15)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// �p���H�c
        /// </summary>
        public string ContactMail { get; set; }

        /// <summary>
        /// �q��Ƶ�
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// �I�ڤ覡
        /// </summary>
        public string Payment { get; set; }

        /// <summary>
        /// �B�O
        /// </summary>
        public decimal ShippingFee { get; set; }

        public int OrderStatusRefId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// ���p��h�ӭq��ԲӲ��~
        /// </summary>
        public ICollection<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// �q��O�Ѩ��ӱb���U��
        /// </summary>
        public string UserRefId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
