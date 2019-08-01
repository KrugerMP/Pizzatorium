namespace Pizzatorium.Migrations
{
    using Pizzatorium.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pizzatorium.Models.StoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pizzatorium.Models.StoreDBContext context)
        {
            context.Users.AddOrUpdate(new User
            {
                dName = "Marco",
                dUserName = "AdminAdmin",
                dPassword = "AdminAdmin",
                dPhone = "0148523694",
                dAddress = "Admin Home",
                dFavPizza = "hawaiian"
            });
            context.SaveChanges();
            context.Users.AddOrUpdate(new User
            {
                dName = "Susan",
                dUserName = "Admin123456",
                dPassword = "Admin123456",
                dPhone = "1234569870",
                dAddress = "Home Lane 89",
                dFavPizza = "Mexican"
            });
            context.SaveChanges();
            //Areas
            context.Areas.AddOrUpdate(new Area
            {
                dArea = "Hatfield"
            });
            context.SaveChanges();
            context.Areas.AddOrUpdate(new Area
            {
                dArea = "Centurion"
            });
            context.SaveChanges();
            context.Areas.AddOrUpdate(new Area
            {
                dArea = "Pretoria CBD"
            });
            context.SaveChanges();
            context.Areas.AddOrUpdate(new Area
            {
                dArea = "Soshanguve"
            });
            context.SaveChanges();
            //Ingredients
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Cheese",
                dPrice = 2
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Capers",
                dPrice = 3
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Banana",
                dPrice = 2
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Avocado",
                dPrice = 4
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Chicken",
                dPrice = 5
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Suasage",
                dPrice = 5
            });
            context.SaveChanges();
            context.Ingredients.AddOrUpdate(new Ingredient
            {
                dIngredient = "Mince",
                dPrice = 6
            });
            context.SaveChanges();
            //Delivery
            context.Deliveries.AddOrUpdate(new Delivery
            {
                dName = "Jack",
                dArea = "Hatfield",
                dPhoto = "~/DeliveryAssets/EmpImage/Jack.jpg"
            });
            context.SaveChanges();
            context.Deliveries.AddOrUpdate(new Delivery
            {
                dName = "Susan",
                dArea = "Centurion",
                dPhoto = "~/DeliveryAssets/EmpImage/Susan.jpg"
            });
            context.SaveChanges();
            context.Deliveries.AddOrUpdate(new Delivery
            {
                dName = "Jenny",
                dArea = "Pretoria CBD",
                dPhoto = "~/DeliveryAssets/EmpImage/Jenny.jpg"
            });
            context.SaveChanges();
            context.Deliveries.AddOrUpdate(new Delivery
            {
                dName = "Steve",
                dArea = "Soshanguve",
                dPhoto = "~/DeliveryAssets/EmpImage/Steve.jpg"
            });
            context.SaveChanges();
        }
    }
}
