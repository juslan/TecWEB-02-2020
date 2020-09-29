using AutomovilesAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        //MARCAS
        IEnumerable<MarcaEntity> GetMarcas(string orderBy);
        MarcaEntity GetMarca(int marcaId);
        MarcaEntity CreateMarca(MarcaEntity marcaModel);
        bool DeleteMarca(int marcaId);
        MarcaEntity UpdateMarca(int marcaId,MarcaEntity marcaModel);
        //Automoviles
        AutomovilEntity CreateAutomovil(AutomovilEntity automovil);
        AutomovilEntity GetAutomovil(int automovilId);
        IEnumerable<AutomovilEntity> GetAutomoviles(int marcaId);
        AutomovilEntity UpdateAutomovil( AutomovilEntity automovilModel);
        bool DeleteAutomovil(int automovilId);

    }
}
