using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class PeliculasController : Controller
{
    private static List<Categoria> categorias = new List<Categoria>
    {
        new Categoria { Id = 1, Nombre = "Acción" },
        new Categoria { Id = 2, Nombre = "Comedia" },
        new Categoria { Id = 3, Nombre = "Ciencia Ficción" }
    };

    private static List<Pelicula> peliculas = new List<Pelicula>
    {
        new Pelicula { Id = 1, Titulo = "Mad Max: Fury Road", Descripcion = "Acción post-apocalíptica", CategoriaId = 1 },
        new Pelicula { Id = 2, Titulo = "John Wick", Descripcion = "Acción y venganza", CategoriaId = 1 },
        new Pelicula { Id = 3, Titulo = "La Máscara", Descripcion = "Comedia y locura", CategoriaId = 2 },
        new Pelicula { Id = 4, Titulo = "Volver al Futuro", Descripcion = "Viajes en el tiempo", CategoriaId = 3 }
    };

    // Vista principal con categorías
    public IActionResult Index()
    {
        return View(categorias);
    }

    // Lista de películas por categoría
    public IActionResult ListaPeliculas(int id)
    {
        var lista = peliculas.Where(p => p.CategoriaId == id).ToList();
        ViewBag.Categoria = categorias.FirstOrDefault(c => c.Id == id)?.Nombre;
        return View(lista);
    }

    // Formulario de película deseada
    [HttpGet]
    public IActionResult AgregarDeseada()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AgregarDeseada(Pelicula nueva)
    {
        if (string.IsNullOrEmpty(nueva.Titulo) || string.IsNullOrEmpty(nueva.Descripcion) || nueva.CategoriaId == 0)
        {
            ViewBag.Error = "Todos los campos son obligatorios.";
            return View(nueva);
        }

        // Aquí podrías guardar en base de datos o lista
        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }
}