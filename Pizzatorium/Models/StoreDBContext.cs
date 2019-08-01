using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Pizzatorium.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext() : base("name = StoreDBContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreDBContext, Pizzatorium.Migrations.Configuration>("StoreDBContext"));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}