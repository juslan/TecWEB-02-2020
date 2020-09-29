using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Services
{
    public interface IAutomovilesService
    {
        AutomovilModel CreateAutomovil(int marcaId, AutomovilModel automovilModel);
        AutomovilModel GetAutomovil(int marcaId, int automovilId);
        IEnumerable<AutomovilModel> GetAutomoviles(int marcaId);
        AutomovilModel UpdateAutomovil(int marcaId, int automovilId, AutomovilModel automovilModel);
        bool DeleteAutomovil(int marcaId, int automovilId);
        
    }
}
