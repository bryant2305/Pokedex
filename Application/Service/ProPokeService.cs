using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ProPokeService
    {
        private readonly ProPokeRepository _propokeRepository;
        private readonly TipoRepository _tipoRepository;
        private readonly RegionRepository _regionRepository;
       

        public ProPokeService(ApplicationContext dbContext)
        {
            _propokeRepository = new (dbContext);
            _tipoRepository = new(dbContext);
            _regionRepository = new(dbContext);
        }

        public async Task Update(ProPokeViewModel vm)
        {
            ProductPokemon product = new();
            product.Id = vm.Id;
            product.Name = vm.Name; 
            product.ImageUrl= vm.ImageUrl;
            product.TipoId = vm.TipoId;
            product.TipoIdSec = vm.TipoIdSec;
            product.RegionId = vm.RegionId;
            await _propokeRepository.UpdateAsync(product);
        }

        public async Task Add(ProPokeViewModel vm)
        {
            ProductPokemon product = new();
            product.Name = vm.Name;
            product.Id = vm.Id;
            product.ImageUrl = vm.ImageUrl;
            product.RegionId = vm.RegionId;
            product.TipoId = vm.TipoId;
            product.TipoIdSec = vm.TipoIdSec;
            await _propokeRepository.AddAsync(product);
        }
        public async Task Delete(int id)
        {
            var Product = await _propokeRepository.GetByIdAsync(id);
            await _propokeRepository.DeleteAsync(Product);
        }



        public async Task<ProPokeViewModel> GetByIdSaveProductViewModel(int id)
        {
          var product = await _propokeRepository.GetByIdAsync(id);
            ProPokeViewModel vm = new ();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.ImageUrl=product.ImageUrl;
            vm.RegionId = product.RegionId;
            vm.TipoId = product.TipoId;
             vm.TipoIdSec = product.TipoIdSec;
           

            return vm;
        }

        public async Task<List<ProPokeViewModel>> GetAllViewModel()
        {
            var proPokeList = await _propokeRepository.GetAllAsync();
            return proPokeList.Select(proPoke => new ProPokeViewModel
            {
                Name = proPoke.Name,
                Id = proPoke.Id,
                ImageUrl = proPoke.ImageUrl,
                RegionId=proPoke.RegionId,
                 TipoId = proPoke.TipoId,
                TipoIdSec = proPoke.TipoIdSec
            }).ToList();
        }

        public async Task<AllViewModel> GetAll()
        {
            var allPoke = await _propokeRepository.GetAllAsync();
            var allTipo = await _tipoRepository.GetAllTiposAsync();
            var allRegion = await _regionRepository.GetAllRegionAsync();
            AllViewModel vm = new();

            vm.Poke = allPoke.Select(pokemon => new ProPokeViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                RegionId = pokemon.RegionId,
                TipoId = pokemon.TipoId,
                TipoIdSec = pokemon.TipoIdSec
            }).ToList();

            vm.Region = allRegion.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,
               
            }).ToList();


            vm.Tipo = allTipo.Select(tipo => new TipoViewModel
            {
                Id = tipo.Id,
                Name = tipo.Name,
                
            }).ToList();

            return vm;

        }
    }
}
