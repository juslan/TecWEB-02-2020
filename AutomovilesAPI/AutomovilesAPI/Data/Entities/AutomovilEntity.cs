using AutomovilesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AutomovilesAPI.Data.Entities
{
    public enum ColorType
    {
        Rojo,
        Negro,
        Azul,
        Silver,
        Blanco
    }
    public class AutomovilEntity
    {
        public AutomovilEntity(AutomovilModel automovilModel)
        {
            this.Id = automovilModel.Id;
            this.Propietario = automovilModel.NombreCliente;
            this.Modelo = automovilModel.Modelo;
            this.Color = (ColorType)automovilModel.Color;
            this.NumeroDeAsientos = automovilModel.Asientos;
            this.VelocidadMaxima = automovilModel.Velocidad;
            this.Precio = automovilModel.Precio;
            this.Año = automovilModel.Año;
            this.Kilometraje = automovilModel.Kilometraje;
            this.Entregado = automovilModel.Entregado;
            this.MarcaId = automovilModel.Id;
        }
        public AutomovilEntity()
        {
        }
        public int Id { get; set; }
        public string Propietario { get; set; }
        public string Modelo { get; set; }
        public ColorType? Color { get; set; }
        public int? NumeroDeAsientos { get; set; }
        public int? VelocidadMaxima { get; set; }
        public decimal? Precio { get; set; }
        public int? Año { get; set; }
        public int? Kilometraje { get; set; }
        public bool? Entregado { get; set; }
        public int? MarcaId { get; set; }
    }
}
