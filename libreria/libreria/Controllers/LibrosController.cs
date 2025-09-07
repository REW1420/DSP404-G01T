using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using System.Collections.Generic;
using System.Linq;

namespace libreria.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libro> _libros = new List<Libro>
        {
            new Libro { Id = 1, Titulo = "Cien Años de Soledad", Autor = "Gabriel García Márquez", AnioPublicacion = 1967 },
            new Libro { Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", AnioPublicacion = 1605 }
        };

        public IActionResult Index()
        {
            return View(_libros);
        }

        public IActionResult Details(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.Id = _libros.Any() ? _libros.Max(l => l.Id) + 1 : 1;
                _libros.Add(libro);
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        public IActionResult Delete(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id);
            if (libro == null) return NotFound();

            _libros.Remove(libro);
            return RedirectToAction(nameof(Index));
        }
    }
}
