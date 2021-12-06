using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class CategoriaModel:AuditoriaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Filter { get; set; }
    }
}
