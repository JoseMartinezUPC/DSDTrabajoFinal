using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Red : Entity
    {
        public int TipoRedId { get; set; }
        public string Recurso { get; set; }
        public int UsuarioId { get; set; }
    }
}
