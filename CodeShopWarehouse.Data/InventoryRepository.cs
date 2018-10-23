using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class InventoryRepository
    {
        private readonly CodeShopWarehouseDbContext _db;

        public InventoryRepository(CodeShopWarehouseDbContext db)
        {
            _db = db;
        }

        public Inventory GetInventoryById(int id)
        {
            return _db.Inventory.Find(id);
        }

        public void AddInventoryItem(Inventory item)
        {
            _db.Inventory.Add(item);
        }

        public void UpdateInventory(Inventory item)
        {
            _db.Inventory.Update(item);
        }

        public List<Inventory> GetInventory()
        {
            List<Inventory> inventory = new List<Inventory>();
            inventory.AddRange(_db.Inventory);
            return inventory;
        }
    }
}
