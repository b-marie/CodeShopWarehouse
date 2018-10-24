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
            return View(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            
            return View(_productService.GetProductById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description, Title")] Product product)
        {
            product.CreatedAt = DateTimeOffset.Now;
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Product product)
        {
            _productService.UpdateProduct(product);
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            _productService.DeleteProduct(product);
            return View();
        }

        public IActionResult Process()
        {
            return null;
        }
    }
}