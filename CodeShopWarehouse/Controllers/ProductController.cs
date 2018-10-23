using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeShopWarehouse.Business;
using CodeShopWarehouse.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeShopWarehouse.Web.Controllers
{
    [Route("products/[Controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.CreateProduct(product);
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Product product)
        {
            _productService.UpdateProduct(product);
            return null;
        }

    }
}