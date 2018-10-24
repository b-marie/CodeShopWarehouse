using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeShopWarehouse.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Web.Controllers
{
    [Route("orders/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderService _context;

        public OrdersController(OrderService context)
        {
            _context = context;
        }

        [HttpGet("OpenOrders")]
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(_context.GetOpenOrders());
        }

        [HttpGet("{id}")]
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = _context.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity,OrderType")] Order order)
        {
            order.CreatedAt = DateTimeOffset.Now;
            if (ModelState.IsValid && order.OrderType == "Customer Order")
            {
                _context.CreateCustomerOrder(order);
                return RedirectToAction(nameof(Index));
            }
            else if (ModelState.IsValid && order.OrderType == "Inventory Order")
            {
                _context.CreateInventoryOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpDelete]
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            _context.DeleteOrder(_context.GetOrderById(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Process(int id)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            _context.ProcessOrder(_context.GetOrderById(id), now);
            return RedirectToAction(nameof(ProcessedOrders));
        }

        [HttpGet("ProcessedOrders")]
        public IActionResult ProcessedOrders()
        {
            return View(_context.GetProcessedOrders());
        }

        [HttpGet("ClosedOrders")]
        public IActionResult ClosedOrders()
        {
            return View(_context.GetClosedOrders());
        }

        [HttpPut]
        public async Task<IActionResult> Close(int id)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            _context.CloseOrder(_context.GetOrderById(id), now);
            return RedirectToAction(nameof(ClosedOrders));
        }
    }
}
