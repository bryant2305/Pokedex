using Application.Service;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PokemonApp.Controllers
{
    public class RegionController : Controller
    {
      
            private readonly RegionService _regionService;

            public RegionController(ApplicationContext dbContext)
            {
                _regionService = new(dbContext);
            }

            public async Task<IActionResult> RegionForm()
            {
                return View(await _regionService.GetRegionvm());
            }

            public IActionResult Create()
            {
                return View("SaveRegion", new RegionViewModel());
            }

            [HttpPost]
            public async Task<IActionResult> Create(RegionViewModel vm)
            {
                if (!ModelState.IsValid)
                {
                    return View("SaveRegion", vm);
                }
                await _regionService.Add(vm);
                return RedirectToRoute(new { controller = "Region", Action = "RegionForm" });
            }

            public async Task<IActionResult> Edit(int Id)
            {
                return View("SaveRegion", await _regionService.GetByIdRegionViewModel(Id));
            }

            [HttpPost]
            public async Task<IActionResult> Edit(RegionViewModel vm)
            {
                if (!ModelState.IsValid)
                {
                    return View("SaveRegion", vm);
                }
                await _regionService.Update(vm);
                return RedirectToRoute(new { controller = "Region", Action = "RegionForm" });
            }


            public async Task<IActionResult> Delete(int Id)
            {
                return View(await _regionService.GetByIdRegionViewModel(Id));
            }

            [HttpPost]
            public async Task<IActionResult> DeletePost(int Id)
            {
                await _regionService.Delete(Id);
                return RedirectToRoute(new { controller = "Region", Action = "RegionForm" });
            }

        }
    }
