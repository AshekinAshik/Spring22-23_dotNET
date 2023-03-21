using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHunger.EF.Models;

namespace ZeroHunger.EF
{
    public class ZeroHungerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpProdReq> EmpProdReqs { get; set;}
        public DbSet<ProdReq> ProdReqs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Restaurant> Restaurants { get; set;}
    }
}