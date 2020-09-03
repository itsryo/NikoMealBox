namespace NikoMealBox.Models.DataTable
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NikoMealBoxContext : DbContext
    {
        public NikoMealBoxContext()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
