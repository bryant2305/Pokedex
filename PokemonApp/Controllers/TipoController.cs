using Application.Service;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApp.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoService _tipoService;

        public TipoController(ApplicationContext dbContext)
        {
            _tipoService = new(dbContext);
        }

        public async Task<IActionResult> TipoForm()
        {
            return View(await _tipoService.GetTiposvm());
        }

        public IActionResult Create()
        {
            return View("SaveTipo", new TipoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoService.Add(vm);
            return RedirectToRoute(new { controller = "Tipo", Action = "TipoForm" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveTipo", await _tipoService.GetByIdTipoViewModel(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoService.Update(vm);
            return RedirectToRoute(new { controller = "Tipo", Action = "TipoForm" });
        }


        public async Task<IActionResult> Delete(int Id)
        {
            return View(await _tipoService.GetByIdTipoViewModel(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _tipoService.Delete(Id);
            return RedirectToRoute(new { controller = "Tipo", Action = "TipoForm" });
        }

    }
}
