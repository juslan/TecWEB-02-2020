using AutomovilesAPI.Data.Entities;
using AutomovilesAPI.Data.Repository;
using AutomovilesAPI.Exceptions;
using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    public class AutomovilesService : IAutomovilesService
    {
        ILibraryRepository _libraryRepository;

        public AutomovilesService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public AutomovilModel CreateAutomovil(int marcaId, AutomovilModel automovilModel)
        {
            validateMarca(marcaId);
            return new AutomovilModel(_libraryRepository.CreateAutomovil(new AutomovilEntity(automovilModel)));
        }

        public bool DeleteAutomovil(int marcaId, int automovilId)
        {
            var automovil = GetAutomovil(marcaId, automovilId);
            return _libraryRepository.DeleteAutomovil(automovilId);
        }

        public AutomovilModel GetAutomovil(int marcaId, int automovilId)
        {
            validateMarca(marcaId);
            validateAutomovil(automovilId);
            return new AutomovilModel(_libraryRepository.GetAutomovil(automovilId));       
        }
        private void validateMarca(int marcaId)
        {
            var marca = _libraryRepository.GetMarca(marcaId);
            if (marca == null)
            {
                throw new NotFoundOperationException($"La marca con el id:{marcaId} no existe");
            }
        }
        private void validateAutomovil(int automovilId)
        {
            var automovil = _libraryRepository.GetAutomovil(automovilId);
            if (automovil == null)
            {
                throw new NotFoundOperationException($"La marca con el id:{automovilId} no existe");
            }
        }

        public IEnumerable<AutomovilModel> GetAutomoviles(int marcaId)
        {
            validateMarca(marcaId);
            var returnedList = _libraryRepository.GetAutomoviles(marcaId);
            var ans = new List<AutomovilModel>();
            foreach (var item in returnedList)
            {
                var aux = new AutomovilModel(item);
                ans.Add(aux);
            }
            return ans;
        }

        public AutomovilModel UpdateAutomovil(int marcaId, int automovilId, AutomovilModel automovilModel)
        {
            GetAutomovil(marcaId, automovilId);
            automovilModel.Id = automovilId;
            return new AutomovilModel(_libraryRepository.UpdateAutomovil(new AutomovilEntity(automovilModel)));
        }
    }
}
