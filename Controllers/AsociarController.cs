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
    public class AsociarController : Controller
    {
        private readonly ILogger<AsociarController> _logger;
        private readonly ApplicationDbContext _context;

        public AsociarController(ILogger<AsociarController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var adoptantes = await _context.DbSetAdoptante.ToListAsync();
            var mascotasDisponibles = await _context.DbSetMascota
                                        .Where(m => m.Estado == "Disponible")
                                        .ToListAsync();

            ViewBag.Adoptantes = adoptantes;
            ViewBag.MascotasDisponibles = mascotasDisponibles;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AsociarMascota(int mascotaId, int adoptanteId)
        {
            var mascota = await _context.DbSetMascota.FindAsync(mascotaId);
            var adoptante = await _context.DbSetAdoptante.FindAsync(adoptanteId);

            if (mascota == null || adoptante == null)
            {
                return NotFound();
            }

            mascota.Estado = "Adoptado";
            _context.Update(mascota);

            var adopcion = new MascotaAdoptante
            {
                MascotaId = mascotaId,
                AdoptanteId = adoptanteId
            };
            _context.Add(adopcion);

            await _context.SaveChangesAsync();

            TempData["Mensaje"] = $"Mascota '{mascota.Nombre}' asociada al adoptante '{adoptante.Nombre}'.";

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}