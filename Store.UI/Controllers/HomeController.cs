using Microsoft.AspNetCore.Mvc;
using Store.UI.Models;
using System.Diagnostics;
using Store.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Store.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.BLL.Services;

namespace Store.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync();
            return View(allProducts);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Title,Price,Rate,Desctiption")] Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allProducts.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Desctiption.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResultNew);
            }
            return View("Index", allProducts);
        }
    }
}