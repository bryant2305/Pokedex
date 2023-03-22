using Application.Repository;
using Application.ViewModels;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TipoService
    {
        private readonly TipoRepository _tipoRepository;

        public TipoService(ApplicationContext dbContext)
        {
            _tipoRepository = new(dbContext);
        }

        public async Task Add(TipoViewModel vm)
        {
            ProductTipo tipo = new();

            tipo.Name = vm.Name;


            await _tipoRepository.AddAsync(tipo);
        }

        public async Task Update(TipoViewModel vm)
        {
            ProductTipo tipo = new();
            tipo.Name = vm.Name;
            tipo.Id = vm.Id;
            await _tipoRepository.UpdateAsync(tipo);
        }

        public async Task Delete(int Id)
        {
            var Tipo = await _tipoRepository.GetByIdTipoAsync(Id);
            await _tipoRepository.DeleteAsync(Tipo);
        }

        public async Task<List<TipoViewModel>> GetTiposvm()
        {
            var TipoList = await _tipoRepository.GetAllTiposAsync();
            return TipoList.Select(tipo => new TipoViewModel
            {
                Id = tipo.Id,
                Name = tipo.Name
            }).ToList();
        }

        public async Task<TipoViewModel> GetByIdTipoViewModel(int Id)
        {
            var Tipo = await _tipoRepository.GetByIdTipoAsync(Id);
            TipoViewModel vm = new();
            vm.Id = Tipo.Id;
            vm.Name = Tipo.Name;
            return vm;
        }
    }
}
