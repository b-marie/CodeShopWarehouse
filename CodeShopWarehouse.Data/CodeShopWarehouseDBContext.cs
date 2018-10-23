using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeShopWarehouse.Data
{
    public class CodeShopWarehouseDbContext : DbContext
    {
        public CodeShopWarehouseDbContext(DbContextOptions<CodeShopWarehouseDbContext> options) : base(options)
        {

        }
        public DbSet<CodeShopWarehouse.Entities.Product> Product { get; set; }
        public DbSet<CodeShopWarehouse.Entities.Inventory> Inventory { get; set; }
        public DbSet<CodeShopWarehouse.Entities.Order> Order { get; set; }

    }
}
