using Application.Service;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProPokeService _propokeService;
        private readonly TipoService _tipoService;
        private readonly RegionService _regionService;

        public ProductController(ApplicationContext dbContext)
        {
            _propokeService = new(dbContext);
            _tipoService = new(dbContext);
            _regionService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _propokeService.GetAll());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Tipo = await _tipoService.GetTiposvm();
            ViewBag.Region = await _regionService.GetRegionvm();
            return View(new ProPokeViewModel());
                            
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProPokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Tipo = await _tipoService.GetTiposvm();
                ViewBag.Region = await _regionService.GetRegionvm();
                return View(vm);
                
            }
           await _propokeService.Add(vm);
            return RedirectToRoute(new {controller="Product", action="Index"});
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Tipo = await _tipoService.GetTiposvm();
            ViewBag.Region = await _regionService.GetRegionvm();
            return View(await _propokeService.GetByIdSaveProductViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProPokeViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Tipo = await _tipoService.GetTiposvm();
                ViewBag.Region = await _regionService.GetRegionvm();
                return View(vm);
            }
            await _propokeService.Update(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View( await _propokeService.GetByIdSaveProductViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _propokeService.Delete(id);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
    }
}

