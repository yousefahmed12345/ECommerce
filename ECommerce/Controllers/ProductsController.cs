using ECommerce.Data;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _services;
        private readonly ICategoryServices _Categoryservices;

        public ProductsController(IProductServices services, ICategoryServices Categoryservices)
        {
            _services = services;
            _Categoryservices = Categoryservices;
        }
        public async Task<IActionResult> Index(string searchTerm)
        {
            var Response = await _services.GetAllAsync(x =>x.Category);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Response = Response.Where(x => x.Name.Contains(searchTerm)).ToList();
            }
            return View(Response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Product = await _services.GetByIdAsync(id,x =>x.Category);
            
            return View(Product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = await _Categoryservices.GetAllAsync();
            return View();
        }
        [HttpPost,ActionName(nameof(Create))]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }

        public async Task<IActionResult> Edit(int id )
        {
            ViewBag.Category = await _Categoryservices.GetAllAsync();
            var productId = await _services.GetByIdAsync(id , x => x.Category);
            return View(productId);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                // Update
                await _services.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            ViewBag.Category = await _Categoryservices.GetAllAsync();
            return View(product);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _services.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
