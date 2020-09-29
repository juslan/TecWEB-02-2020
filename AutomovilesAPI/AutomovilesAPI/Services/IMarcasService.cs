using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    public interface IMarcasService
    {
        IEnumerable<MarcaModel> GetMarcas(string orderBy);
        MarcaModel GetMarca(int marcaId);
        MarcaModel CreateMarca(MarcaModel marcaModel);
        DeleteModel DeleteMarca(int marcaId);
        MarcaModel UpdateMarca(int marcaId, MarcaModel marcaModel);
    }
}
