using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities;
using CodeShopWarehouse.Business;

namespace CodeShopWarehouse.Web.Controllers
{
    [Route("inventory/[Controller]")]
    public class InventoriesController : Controller
    {
        private readonly InventoryService _inventoryService;
        public InventoriesController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_inventoryService.GetInventory());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return View(_inventoryService.GetInventoryById(id));
        }


    }
}
