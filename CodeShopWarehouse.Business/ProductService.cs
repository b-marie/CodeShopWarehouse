using System;
using System.Collections.Generic;
using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Business
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Get a product
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        //See all products
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        //Create a product
        public void CreateProduct(Product product)
        {
           _productRepository.CreateProduct(product);
        }

        //Update a product
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        //Delete a product
        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }
    }
}
