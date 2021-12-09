using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Imagen : Entity
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int TipoImagenId { get; set; }
        public string Extension { get; set; }
        public int UsuarioId { get; set; }
    }
}
