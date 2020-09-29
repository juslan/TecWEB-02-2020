using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomovilesAPI.Data.Entities
{
    public class MarcaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Founder { get; set; }
        public DateTime? FoundationDate { get; set; }
    }
}
