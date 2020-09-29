using AutoMapper;
using AutomovilesAPI.Data.Entities;
using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<MarcaEntity, MarcaModel>()
                .ReverseMap();
        }
    }
}
