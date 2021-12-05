using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public int TipoUsuarioId { get; set; }

    }
}
