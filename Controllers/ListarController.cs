using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using appmascota.Data;
using appmascota.Models;

namespace appmascota.Controllers
{
    public class ListarController : Controller
    {
        private readonly ILogger<ListarController> _logger;
        private readonly ApplicationDbContext _context;

        public ListarController(ILogger<ListarController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var adopciones = await _context.DbSetMascotaAdoptante
                .Include(ma => ma.Mascota)
                .Include(ma => ma.Adoptante)
                .ToListAsync();

            return View(adopciones);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}