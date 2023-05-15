using Microsoft.AspNetCore.Mvc;
using Store.UI.Models;
using System.Diagnostics;

using Store.BLL.Services.Contracts;
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
        private readonly ILogger<HomeController> _logger;
        private readonly DbmilitaryContext _context;

        public HomeController(ILogger<HomeController> logger, DbmilitaryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbmilitaryContext = _context.Products;
            return View(await dbmilitaryContext.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Title,Price,Rate,Desctiption")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}