using AutomovilesAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AutomovilesAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<MarcaEntity> marcas = new List<MarcaEntity>
        {
            new MarcaEntity(){Id = 1, Name = "Ford", Founder = "Henry Ford", FoundationDate = new DateTime(1903,06,16)},
            new MarcaEntity(){Id = 2, Name = "Volkswagen", Founder = "Frente Alemán del Trabajo", FoundationDate = new DateTime(1937,05,28)}
        };
        private List<AutomovilEntity> automoviles = new List<AutomovilEntity>
        {
            new AutomovilEntity(){Id = 1, Modelo = "Transit", Propietario="Antonio Fuentes",Color = ColorType.Rojo, Año=2019, NumeroDeAsientos=15,Kilometraje=3564, Precio=42300.5m, VelocidadMaxima=180,Entregado=true,MarcaId=1},
            new AutomovilEntity(){Id = 2, Modelo = "Amarok", Propietario="Juslan Vargas",Color=ColorType.Silver, Año=2020, NumeroDeAsientos=5,Kilometraje=10530, Precio=35000.9m, VelocidadMaxima=195,Entregado=false,MarcaId=2},
            new AutomovilEntity(){Id = 3, Modelo = "Touareg", Propietario="Importadora Rayo McQueen",Color=ColorType.Azul, Año=2019, NumeroDeAsientos=8,Kilometraje=15000, Precio=34100.55m, VelocidadMaxima=180,Entregado=true,MarcaId=2}
        };
        public MarcaEntity CreateMarca(MarcaEntity marca)
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
            marca.Id = newId;
            marcas.Add(marca);
            return marca;

        }

        public bool DeleteMarca(int marcaId)
        {
            var marcaToDelete = marcas.FirstOrDefault(m => m.Id == marcaId);
            marcas.Remove(marcaToDelete);
            return true;
        }

        public MarcaEntity GetMarca(int marcaId)
        {
            return marcas.FirstOrDefault(m => m.Id == marcaId);
        }

        public IEnumerable<MarcaEntity> GetMarcas(string orderBy)
        {
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
        }

        public MarcaEntity UpdateMarca(int marcaId,MarcaEntity marcaModel)
        {
            var marcaToUpdate = GetMarca(marcaId);
            marcaToUpdate.Name = marcaModel.Name ?? marcaToUpdate.Name;
            marcaToUpdate.Founder = marcaModel.Founder ?? marcaToUpdate.Founder;
            marcaToUpdate.FoundationDate = marcaModel.FoundationDate ?? marcaToUpdate.FoundationDate;
            return marcaToUpdate;
        }
        public AutomovilEntity CreateAutomovil(AutomovilEntity automovil)
        {
            int newId;
            if (automoviles.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = automoviles.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            }
            automovil.Id = newId;
            automoviles.Add(automovil);
            return automovil;
        }

        public AutomovilEntity GetAutomovil(int automovilId)
        {
            return automoviles.FirstOrDefault(a => a.Id == automovilId);
        }

        public IEnumerable<AutomovilEntity> GetAutomoviles(int marcaId)
        {
            return automoviles.Where(a => a.MarcaId == marcaId);
        }
//        Id = 2, Modelo = "Amarok", Propietario="Juslan Vargas",Color="Silver", Año=2020, 
  //          NumeroDeAsientos=5,Kilometraje=10530, Precio=35000.9m, VelocidadMaxima=195,Entregado=false,MarcaId=2},
        public AutomovilEntity UpdateAutomovil( AutomovilEntity automovilModel)
        {
            var automovilToUpdate = GetAutomovil(automovilModel.Id);
            automovilToUpdate.Modelo = automovilModel.Modelo ?? automovilToUpdate.Modelo;
            automovilToUpdate.Propietario = automovilModel.Propietario ?? automovilToUpdate.Propietario;
            automovilToUpdate.Color = automovilModel.Color ?? automovilToUpdate.Color;
            automovilToUpdate.Año = automovilModel.Año ?? automovilToUpdate.Año;
            automovilToUpdate.NumeroDeAsientos = automovilModel.NumeroDeAsientos ?? automovilToUpdate.NumeroDeAsientos;
            automovilToUpdate.Kilometraje = automovilModel.Kilometraje ?? automovilToUpdate.Kilometraje;
            automovilToUpdate.Precio = automovilModel.Precio ?? automovilToUpdate.Precio;
            automovilToUpdate.VelocidadMaxima = automovilModel.VelocidadMaxima ?? automovilToUpdate.VelocidadMaxima;
            automovilToUpdate.Entregado = automovilModel.Entregado ?? automovilToUpdate.Entregado;
            automovilToUpdate.MarcaId= automovilModel.MarcaId ?? automovilToUpdate.MarcaId;
            return automovilToUpdate;
        }

        public bool DeleteAutomovil(int automovilId)
        {
            var automovilToDelete = automoviles.FirstOrDefault(a => a.Id == automovilId);
            automoviles.Remove(automovilToDelete);
            return true;
        }
        
    }
}
