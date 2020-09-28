using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    public class MarcasService : IMarcasService
    {
        private MarcaModel[] marcas = new MarcaModel[] 
            {
                new MarcaModel(){Id = 1, Name = "Ford", Founder = "Henry Ford", FoundationDate = new DateTime(1903,06,16)},
                new MarcaModel(){Id = 2, Name = "Volkswagen", Founder = "Frente Alemán del Trabajo", FoundationDate = new DateTime(1937,05,28)}
            };
        public IEnumerable<MarcaModel> GetMarcas()
        {
            return marcas;
        }
        public MarcaModel GetMarca(int marcaId)
        {
            return marcas.FirstOrDefault(m => m.Id == marcaId);
        }
    }
}
