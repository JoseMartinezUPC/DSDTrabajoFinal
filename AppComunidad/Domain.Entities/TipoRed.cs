using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoRed : Entity
    {
        public string Nombre { get; set; }
        public string Icon { get; set; }
    }
}
