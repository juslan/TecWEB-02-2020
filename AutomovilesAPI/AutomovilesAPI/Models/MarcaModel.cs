using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AutomovilesAPI.Models
{
    public class MarcaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Founder { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}
