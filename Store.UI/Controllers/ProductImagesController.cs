﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.DAL.DataContext;
using Store.DAL.Models;

namespace Store.UI.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly DbmilitaryContext _context;

        public ProductImagesController(DbmilitaryContext context)
        {
            _context = context;
        }

        // GET: ProductImages
        public async Task<IActionResult> Index()
        {
            var dbmilitaryContext = _context.ProductImages;
            return View(await dbmilitaryContext.ToListAsync());
        }

        // GET: ProductImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductImages == null)
            {
                return NotFound();
            }

            var productImages = await _context.ProductImages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImages == null)
            {
                return NotFound();
            }

            return View(productImages);
        }

        // GET: ProductImages/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Desctiption");
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Image")] ProductImages productImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Desctiption", productImages.ProductId);
            return View(productImages);
        }

        // GET: ProductImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductImages == null)
            {
                return NotFound();
            }

            var productImages = await _context.ProductImages.FindAsync(id);
            if (productImages == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Desctiption", productImages.ProductId);
            return View(productImages);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Image")] ProductImages productImages)
        {
            if (id != productImages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductImagesExists(productImages.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Desctiption", productImages.ProductId);
            return View(productImages);
        }

        // GET: ProductImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductImages == null)
            {
                return NotFound();
            }

            var productImages = await _context.ProductImages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImages == null)
            {
                return NotFound();
            }

            return View(productImages);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductImages == null)
            {
                return Problem("Entity set 'DbmilitaryContext.ProductImages'  is null.");
            }
            var productImages = await _context.ProductImages.FindAsync(id);
            if (productImages != null)
            {
                _context.ProductImages.Remove(productImages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductImagesExists(int id)
        {
          return (_context.ProductImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
