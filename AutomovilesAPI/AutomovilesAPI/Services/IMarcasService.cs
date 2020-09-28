using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    interface IMarcasService
    {
        IEnumerable<MarcaModel> GetMarcas();
        MarcaModel GetMarca(int marcaId);
    }
}
