using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using appmascota.Data;
using appmascota.Models;

namespace appmascota.Controllers
{
    public class AdoptanteController : Controller
    {
        private readonly ILogger<AdoptanteController> _logger;
        private readonly ApplicationDbContext _context;

        public AdoptanteController(ILogger<AdoptanteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptante);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Se registro al adoptante correctamente";
                return RedirectToAction("Index", "Adoptante");
            }
            return View("Index", adoptante);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}