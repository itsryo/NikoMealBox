namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories:BaseEntity
    {
        /// <summary>
        /// ���~�����٩I
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }


        /// <summary>
        /// ���~��������
        /// </summary>
        [StringLength(60)]
        public string CategoryDescription { get; set; }

        /// <summary>
        /// �O�_���ѸӶ��������~
        /// </summary>
        [Required]
        public bool IsEnable { get; set; }
    }
}
