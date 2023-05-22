using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.BLL.Services;
using Store.DAL.DataContext;
using Store.DAL.Models;

namespace Store.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DbmilitaryContext _context;
        private readonly IProductService _service;

        public ProductsController(DbmilitaryContext context, IProductService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync();
            return View(allProducts);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            //Переробити
            ViewBag.Images = _context.ProductImages.Where(p => p.ProductId == id).ToList();
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Title,Price,Rate,Desctiption")] Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        } 

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Title,Price,Rate,Desctiption")] Product product)
        {
            if (id != product.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                return View(product);
            }

            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AddImages()
        {
            ViewBag.Product = new SelectList(_context.Products, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(ProductImages pimage, List<IFormFile> Image)
        {
            if (Image == null) return View();
            await _service.AddImagesAsync(pimage, Image);
            return RedirectToAction(nameof(Index));  
        }
    }
}
