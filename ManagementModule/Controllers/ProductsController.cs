using ManagementModule.EntityModel;
using ManagementModule.Models;
using ManagementModule.Pages.Products;
using ManagementModule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ManagementModule.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductsService _productsService;
    
        public ProductsController(
            ILogger<ProductsController> logger,
            ProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var filter = new ProductFilterModel() { Active = true };

            var result = new ProductIndexViewModel() {
                Products = await _productsService.GetFilteredList(filter),
                Filter = filter,
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ProductFilterModel filter) {
            var result = new ProductIndexViewModel() {
                Products = await _productsService.GetFilteredList(filter),
                Filter = filter
            };

            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var product = await _productsService.GetIfExists(id);

            if (product == null) {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Stock,IsActive")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productsService.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _productsService.GetIfExists(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock,IsActive")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _productsService.Update(product);
                if (result != null) {
                    return RedirectToAction(nameof(Index));
                }
                else {
                    return NotFound();
                }
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _productsService.GetIfExists(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
