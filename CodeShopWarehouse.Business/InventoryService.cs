using System;
using System.Collections.Generic;
using System.Text;
using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Business
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        //Add inventory
        public void AddInventoryItem(Inventory item)
        {
            _inventoryRepository.AddInventoryItem(item);
        }

        //Add inventory
        public void AddInventory(Inventory item, int add)
        {
            item.Quantity = item.Quantity + add;
            _inventoryRepository.UpdateInventory(item);
        }

        //Remove inventory
        public void RemoveInventory(Inventory item, int remove)
        {
            item.Quantity = item.Quantity - remove;
            _inventoryRepository.UpdateInventory(item);
        }

        //Get all inventory
        public List<Inventory> GetInventory()
        {
            return _inventoryRepository.GetInventory();
        }

        //Get inventory by Id
        public Inventory GetInventoryById(int id)
        {
            return _inventoryRepository.GetInventoryById(id);
        }




    }
}
