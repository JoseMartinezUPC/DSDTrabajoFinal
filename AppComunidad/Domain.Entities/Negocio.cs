using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Negocio: Entity
    {
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int SubCategoriaId { get; set; }
    }
}
