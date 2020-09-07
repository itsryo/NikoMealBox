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
            //    new Products { ProductName = "���׫K��", CategoryId = 1, UnitPrice = 50, UnitsInStock = 15, Description = "�W�n�Y", 
            //        Materials = "���סB���J�B���B�a�ʸ��B�n�ʪd�B���a", Calories = 250, ImagePath = "/Assets/Images/bento/����M�����׺~���ƫK��.jpeg", 
            //        Carbohydrate=20, Protein=23, Fat=28, SaturatedFat=26, TransFat = 25, Sugar=30, Sodium =25, IsOvolacto = false, IsEnable =true,
            //        CreateUser = "��",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05") },
            //    new Products { ProductName = "�ư��K��", CategoryId = 2, UnitPrice = 50, UnitsInStock = 12, Description = "�W���Y",
            //        Materials = "�ư��B���J�B���B�a�ʸ��B�n�ʪd�B���a", Calories = 150, ImagePath = "/Assets/Images/bento/����M�����[���׺~���ƫK��.jpeg",
            //        Carbohydrate = 50, Protein = 28, Fat = 35, SaturatedFat = 26, TransFat = 28, Sugar = 30, Sodium = 25, IsOvolacto = true, IsEnable = true,
            //        CreateUser = "ޱ",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")},
            //    new Products { ProductName = "�K���K��", CategoryId = 2, UnitPrice = 50, UnitsInStock = 13, Description = "�٥i�H",
            //        Materials = "�ަסB���J�B���B�a�ʸ��B�n�ʪd�B���a", Calories = 240, ImagePath = "/Assets/Images/bento/����M���������Q���h�K��.jpeg",
            //        Carbohydrate = 40, Protein = 30, Fat = 48, SaturatedFat = 26, TransFat = 25, Sugar = 30, Sodium = 25, IsOvolacto = false, IsEnable = true,
            //        CreateUser = "�u",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")},
            //    new Products { ProductName = "���v�K��", CategoryId = 3, UnitPrice = 50, UnitsInStock = 12, Description = "���ݥ[�j",
            //        Materials = "���v�B���J�B���B�a�ʸ��B�n�ʪd�B���a", Calories = 290 , ImagePath = "/Assets/Images/bento/����M���������Q���ݫK��.jpeg",
            //        Carbohydrate = 26, Protein = 23, Fat = 39, SaturatedFat = 26, TransFat = 25, Sugar = 30, Sodium = 25, IsOvolacto = true, IsEnable = false,
            //        CreateUser = "ޱ",CreateTime = DateTime.Parse ("2020 - 09 - 04 07:31:05")}
            //);
            
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
