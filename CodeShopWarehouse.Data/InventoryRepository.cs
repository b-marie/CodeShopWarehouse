using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class InventoryRepository
    {
        private readonly IDbConnection _db;

        public InventoryRepository(IDbConnection db)
        {
            _db = db;
        }

        public Inventory GetInventoryById(int id)
        {
            return new Inventory()
            {
                Id = id,
            };
        }

        public void AddInventory(int id)
        {
            Console.WriteLine($"Inventory added for ID {id}");
        }

        public void RemoveInventory(int id)
        {
            Console.WriteLine($"Inventory removed for ID {id}");
        }
        public List<Inventory> GetInventory()
        {
            return new List<Inventory>
            {
                GetInventoryById(1),
                GetInventoryById(2),
                GetInventoryById(3),
            };
        }
    }
}
