namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZeroHunger.EF.ZeroHungerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZeroHunger.EF.ZeroHungerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //for (int i = 0; i < 5; i++)
            //{
            //    context.Restaurants.AddOrUpdate(
            //        new EF.Models.Restaurant()
            //        {
            //            Name = Guid.NewGuid().ToString().Substring(0, 11),
            //            Location = "Dhaka"
            //        }
            //        );
            //}
            //Random random = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    context.Products.AddOrUpdate(
            //        new EF.Models.Product()
            //        {
            //            Name = Guid.NewGuid().ToString().Substring(0, 15),
            //            R_ID = random.Next(1, 6),
            //            Quantity = random.Next(5, 21)
            //        });
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    context.Employees.AddOrUpdate(
            //        new EF.Models.Employee()
            //        {
            //            Name = Guid.NewGuid().ToString().Substring(0, 21),
            //            Contact = Convert.ToInt32("01" + random.Next(100000000, 999999999).ToString())
            //        }
            //        );
            //}
        }
    }
}
