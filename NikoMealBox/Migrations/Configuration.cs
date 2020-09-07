namespace NikoMealBox.Migrations
{
    using NikoMealBox.Models.DataTable;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NikoMealBox.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NikoMealBox.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //context.Products.AddOrUpdate(x => x.Id,
            //    new Products { ProductName = "雞肉便當", CategoryId = 1, UnitPrice = 50, UnitsInStock = 15, Description = "超好吃", 
            //        Materials = "雞肉、滷蛋、飯、地瓜葉、南瓜泥、海帶", Calories = 250, ImagePath = "/Assets/Images/bento/日光和風牛肉漢堡排便當.jpeg", 
            //        Carbohydrate=20, Protein=23, Fat=28, SaturatedFat=26, TransFat = 25, Sugar=30, Sodium =25, IsOvolacto = false, IsEnable =true,
            //        CreateUser = "萍",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05") },
            //    new Products { ProductName = "排骨便當", CategoryId = 2, UnitPrice = 50, UnitsInStock = 12, Description = "超難吃",
            //        Materials = "排骨、滷蛋、飯、地瓜葉、南瓜泥、海帶", Calories = 150, ImagePath = "/Assets/Images/bento/日光和風香蒜牛肉漢堡排便當.jpeg",
            //        Carbohydrate = 50, Protein = 28, Fat = 35, SaturatedFat = 26, TransFat = 28, Sugar = 30, Sodium = 25, IsOvolacto = true, IsEnable = true,
            //        CreateUser = "瑄",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")},
            //    new Products { ProductName = "鐵路便當", CategoryId = 2, UnitPrice = 50, UnitsInStock = 13, Description = "還可以",
            //        Materials = "豬肉、滷蛋、飯、地瓜葉、南瓜泥、海帶", Calories = 240, ImagePath = "/Assets/Images/bento/日光和風極嫩薄鹽雞柳便當.jpeg",
            //        Carbohydrate = 40, Protein = 30, Fat = 48, SaturatedFat = 26, TransFat = 25, Sugar = 30, Sodium = 25, IsOvolacto = false, IsEnable = true,
            //        CreateUser = "泉",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")},
            //    new Products { ProductName = "牛腩便當", CategoryId = 3, UnitPrice = 50, UnitsInStock = 12, Description = "有待加強",
            //        Materials = "牛腩、滷蛋、飯、地瓜葉、南瓜泥、海帶", Calories = 290 , ImagePath = "/Assets/Images/bento/日光和風極嫩薄鹽雞胸便當.jpeg",
            //        Carbohydrate = 26, Protein = 23, Fat = 39, SaturatedFat = 26, TransFat = 25, Sugar = 30, Sodium = 25, IsOvolacto = true, IsEnable = false,
            //        CreateUser = "瑄",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")}
            //);
            
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
