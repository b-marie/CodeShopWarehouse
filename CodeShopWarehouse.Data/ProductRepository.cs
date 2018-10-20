using System;
using System.Collections.Generic;
using System.Data;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class ProductRepository
    {

        private readonly IDbConnection _db;

        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public Product GetProductById(int id)
        {
            return new Product()
            {
                Id = id,
            };
        }

        public void CreateProduct(Product product)
        {
            Console.WriteLine($"Product {product.Title} created!");
        }

        public void DeleteProduct(Product product)
        {
            Console.WriteLine($"Product {product.Title} deleted!");
        }

        public void UpdateProduct(Product product)
        {
            Console.WriteLine($"Product {product.Title} updated!");
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                GetProductById(1),
                GetProductById(2),
                GetProductById(3),
            };
        }


    }
}
