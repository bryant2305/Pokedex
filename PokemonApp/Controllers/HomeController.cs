using Application.Service;
using Database;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;
using System.Diagnostics;

namespace PokemonApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProPokeService _propokeService;
        private readonly TipoService _tipoService;
        private readonly RegionService _regionService;

        public HomeController(ApplicationContext dbContext)
        {
            _propokeService = new (dbContext);
            _tipoService = new(dbContext);
            _regionService = new(dbContext);
        }
        //este es el filtro
        public async Task<IActionResult> Index(int Id = 0)
        {
            ViewBag.Region = await _regionService.GetRegionvm();
            ViewBag.Filtro = Id;
            return View(await _propokeService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(String Busqueda = null, int Id = 0)
        {
            ViewBag.Region = await _regionService.GetRegionvm();
            ViewBag.Filtro = Id;
            ViewBag.Busqueda = Busqueda;
            return View(await _propokeService.GetAll());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}