using Microsoft.AspNetCore.Mvc;
using Registro_de_Inscripciones___Talleres_de_Tecnología.Models;
using Registro_de_Inscripciones___Talleres_de_Tecnología.Data;
using System;
using System.Collections.Generic;

namespace Registro_de_Inscripciones___Talleres_de_Tecnología.Controllers
{
    public class InscripcionController : Controller
    {
        private void CargarListasParaVista()
        {
            ViewBag.Talleres = new List<string>
            {
                "C#",
                "Python",
                "Web",
                "Bases de Datos",
                "Otro"
            };

            ViewBag.Niveles = new List<string>
            {
                "Principiante",
                "Intermedio",
                "Avanzado"
            };
        }

        public IActionResult Index()
        {
            var lista = InscripcionRepository.ObtenerInscripciones();
            return View(lista);
        }

        public IActionResult Crear()
        {
            CargarListasParaVista();

            var model = new Inscripcion
            {
                FechaTaller = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Inscripcion inscripcion)
        {
            CargarListasParaVista();

            // Validación manual de fecha no pasada
            if (inscripcion.FechaTaller < DateTime.Today)
            {
                ModelState.AddModelError(nameof(inscripcion.FechaTaller), "La fecha del taller no puede ser anterior a hoy.");
            }

            if (!ModelState.IsValid)
            {
                return View(inscripcion);
            }

            InscripcionRepository.AgregarInscripcion(inscripcion);

            TempData["SuccessMessage"] = $"Inscripción registrada correctamente para {inscripcion.Nombre} {inscripcion.Apellidos}.";

            return RedirectToAction(nameof(Index));
        }
    }
}
