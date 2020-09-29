using AutomovilesAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Models
{
    public enum ColorType
    {
        Rojo,
        Negro,
        Azul,
        Silver,
        Blanco
    }
    public class AutomovilModel
    {
        public AutomovilModel(AutomovilEntity autoEntity)
        {
            this.Id = autoEntity.Id;
            this.NombreCliente = autoEntity.Propietario;
            this.Modelo = autoEntity.Modelo;
            this.Color = (ColorType)autoEntity.Color;
            this.Asientos = autoEntity.NumeroDeAsientos;
            this.Velocidad = autoEntity.VelocidadMaxima;
            this.Precio = autoEntity.Precio;
            this.Año = autoEntity.Año;
            this.Kilometraje = autoEntity.Kilometraje;
            this.Entregado = autoEntity.Entregado;
            this.MarcaId = autoEntity.MarcaId;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        public string Modelo { get; set; }
        public ColorType? Color { get; set; }
        public int? Asientos { get; set; }
        public int? Velocidad { get; set; }
        public decimal? Precio { get; set; }
        public int? Año { get; set; }
        public int? Kilometraje { get; set; }
        public bool? Entregado { get; set; }
        [Required]
        public int? MarcaId { get; set; }
    }
}
