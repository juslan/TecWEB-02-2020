using AutomovilesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Controllers
{
    [Route("api/[controller]")]
    public class MarcasController : Controller
    {
        [HttpGet]
        public IEnumerable<MarcaModel> GetMarcas(){
            return marcas;
        }

        [HttpGet("{marcaId:int}")]
        public MarcaModel GetMarca(int marcaId)
        {
            return marcas.FirstOrDefault(m => m.Id == marcaId);
        }

    }
}
