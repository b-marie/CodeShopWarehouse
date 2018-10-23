using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class ProductRepository
    {

        private readonly CodeShopWarehouseDbContext _db;

        public ProductRepository(CodeShopWarehouseDbContext db)
        {
            _db = db;
        }

        public Product GetProductById(int id)
        {
            return _db.Product.Find(id);
        }

        public void CreateProduct(Product product)
        {
            _db.Product.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _db.Product.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _db.Product.Update(product);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            products.AddRange(_db.Product);
            return products;
        }


    }
}
