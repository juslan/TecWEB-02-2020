using AutoMapper;
using AutomovilesAPI.Data.Entities;
using AutomovilesAPI.Data.Repository;
using AutomovilesAPI.Exceptions;
using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    public class MarcasService : IMarcasService
    {
        ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        public HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "founder",
            "foundation-date"
        };

        public MarcasService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public IEnumerable<MarcaModel> GetMarcas(string orderBy)
        {
            if(!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"el parametro que ingreso: {orderBy}, no esta disponible, intente ingresando una de las siguientes {string.Join(",", allowedOrderByParameters)}");
            }
            var entityList= _libraryRepository.GetMarcas(orderBy);
            var modelList = _mapper.Map<IEnumerable<MarcaModel>>(entityList);
            return modelList;
        }
        public MarcaModel GetMarca(int marcaId)
        {
            //var marca = marcas.FirstOrDefault(m => m.Id == marcaId);
            var marca = _libraryRepository.GetMarca(marcaId);
            if(marca == null)
            {
                throw new NotFoundOperationException($"El id: {marcaId} no corresponde a ninguna marca");
            }
            return _mapper.Map<MarcaModel>(marca);
        }

        public MarcaModel CreateMarca(MarcaModel marcaModel)
        {
            var marcaEntity = _mapper.Map<MarcaEntity>(marcaModel);
            var returnedMarca = _libraryRepository.CreateMarca(marcaEntity);
            return _mapper.Map<MarcaModel>(returnedMarca);
        }

        public DeleteModel DeleteMarca(int marcaId)
        {
            var marcaToDelete = GetMarca(marcaId);
            var result = _libraryRepository.DeleteMarca(marcaId);
            if (result)
            {
                return new DeleteModel()
                {
                    IsSuccess = result,
                    Message = "La marca fue eliminada correctamente."
                };
            }
            else
            {
                return new DeleteModel()
                {
                    IsSuccess = result,
                    Message = "La marca fue eliminada correctamente."
                };
            }
            
        }

        public MarcaModel UpdateMarca(int marcaId, MarcaModel marcaModel)
        {
            var marcaEntity = _mapper.Map<MarcaEntity>(marcaModel);
            var returnedMarca = _libraryRepository.UpdateMarca(marcaId,marcaEntity);
            return _mapper.Map<MarcaModel>(returnedMarca);
        }
    }
}
