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
        private List<MarcaModel> marcas = new List<MarcaModel> 
            {
                new MarcaModel(){Id = 1, Name = "Ford", Founder = "Henry Ford", FoundationDate = new DateTime(1903,06,16)},
                new MarcaModel(){Id = 2, Name = "Volkswagen", Founder = "Frente Alemán del Trabajo", FoundationDate = new DateTime(1937,05,28)}
            };
        public HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "founder",
            "foundation-date"
        };
        public IEnumerable<MarcaModel> GetMarcas(string orderBy)
        {
            if(!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"el parametro que ingreso: {orderBy}, no esta disponible, intente ingresando una de las siguientes {string.Join(",", allowedOrderByParameters)}");
            }
            switch (orderBy.ToLower())
            {
                case "id":
                    return marcas.OrderBy(m => m.Id);
                case "name":
                    return marcas.OrderBy(m => m.Name);
                case "founder":
                    return marcas.OrderBy(m => m.Founder);
                case "foundation-date":
                    return marcas.OrderBy(m => m.FoundationDate);
                default:
                    return marcas.OrderBy(m => m.Id);
            }
            return marcas;
        }
        public MarcaModel GetMarca(int marcaId)
        {
            var marca = marcas.FirstOrDefault(m => m.Id == marcaId);
            if(marca == null)
            {
                throw new NotFoundOperationException($"El id: {marcaId} no corresponde a ninguna marca");
            }
            return marca;
        }

        public MarcaModel CreateMarca(MarcaModel marcaModel)
        {
            int newId;
            if (marcas.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = marcas.OrderByDescending(m => m.Id).FirstOrDefault().Id + 1;
            }
            marcaModel.Id = newId;
            marcas.Add(marcaModel);
            return marcaModel;
        }

        public DeleteModel DeleteMarca(int marcaId)
        {
            var marcaToDelete = GetMarca(marcaId);
            var result = marcas.Remove(marcaToDelete);
            return new DeleteModel() { 
                IsSuccess = true,
                Message = "La marca fue eliminada correctamente."
            };
        }

        public MarcaModel UpdateMarca(int marcaId, MarcaModel marcaModel)
        {
            var marcaToUpdate = GetMarca(marcaId);
            marcaToUpdate.Name = marcaModel.Name ?? marcaToUpdate.Name;
            marcaToUpdate.Founder = marcaModel.Founder ?? marcaToUpdate.Founder;
            marcaToUpdate.FoundationDate = marcaModel.FoundationDate ?? marcaToUpdate.FoundationDate;
            return marcaToUpdate;
        }
    }
}
