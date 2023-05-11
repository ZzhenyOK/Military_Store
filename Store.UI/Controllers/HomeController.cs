using Microsoft.AspNetCore.Mvc;
using Store.UI.Models;
using System.Diagnostics;

using Store.BLL.Services.Contracts;
using Store.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Store.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

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

        public async  Task<IActionResult> Index()
        {
            var dbmilitaryContext = _context.Products;
            return View(await dbmilitaryContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}